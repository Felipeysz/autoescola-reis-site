using AutoescolaReisSite.Crm.Data;
using AutoescolaReisSite.Crm.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoescolaReisSite.Crm.Services
{
    public class LeadExpurgoBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<LeadExpurgoBackgroundService> _logger;
        private static readonly TimeSpan Intervalo = TimeSpan.FromHours(24);

        public LeadExpurgoBackgroundService(
            IServiceScopeFactory scopeFactory,
            ILogger<LeadExpurgoBackgroundService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(Intervalo);

            // Roda uma vez já na subida do app, depois a cada 24h
            do
            {
                await ExecutarExpurgo(stoppingToken);
            }
            while (await timer.WaitForNextTickAsync(stoppingToken));
        }

        private async Task ExecutarExpurgo(CancellationToken stoppingToken)
        {
            using var scope = _scopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<CrmDbContext>();

            try
            {
                var config = await db.ConfiguracoesRetencao.FirstOrDefaultAsync(stoppingToken);
                var prazoDias = config?.PrazoDiasLeadPerdido ?? 180;
                var limite = DateTime.UtcNow.AddDays(-prazoDias);

                var leadsExpirados = await db.Leads
                    .Where(l => l.Status == PipelineStage.Perdido && l.DataUltimaInteracao < limite)
                    .ToListAsync(stoppingToken);

                if (leadsExpirados.Count == 0)
                {
                    _logger.LogInformation("Expurgo de leads: nenhum lead elegível.");
                    return;
                }

                foreach (var lead in leadsExpirados)
                {
                    db.LeadExpurgoLogs.Add(new LeadExpurgoLog
                    {
                        LeadIdOriginal = lead.Id,
                        TelefoneParcial = MascararTelefone(lead.Telefone),
                        StatusNoMomento = lead.Status,
                        DataUltimaInteracaoNoMomento = lead.DataUltimaInteracao,
                        ExcluidoEm = DateTime.UtcNow,
                        Motivo = "Retenção automática — LGPD"
                    });

                    db.Leads.Remove(lead);
                }

                await db.SaveChangesAsync(stoppingToken);

                _logger.LogInformation("Expurgo de leads: {Quantidade} lead(s) excluído(s).", leadsExpirados.Count);
            }
            catch (Exception ex)
            {
                // Nunca deixa o BackgroundService derrubar o app por causa de um erro no expurgo
                _logger.LogError(ex, "Erro ao executar expurgo automático de leads.");
            }
        }

        private static string MascararTelefone(string telefone)
        {
            if (telefone.Length <= 4)
            {
                return "****";
            }

            return new string('*', telefone.Length - 4) + telefone[^4..];
        }
    }
}