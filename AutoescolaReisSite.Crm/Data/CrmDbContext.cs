// Data/CrmDbContext.cs
using AutoescolaReisSite.Crm.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoescolaReisSite.Crm.Data
{
    public class CrmDbContext : DbContext
    {
        public CrmDbContext(DbContextOptions<CrmDbContext> options) : base(options) { }

        public DbSet<Lead> Leads => Set<Lead>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<ConfiguracaoRetencao> ConfiguracoesRetencao => Set<ConfiguracaoRetencao>();
        public DbSet<LeadExpurgoLog> LeadExpurgoLogs => Set<LeadExpurgoLog>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}