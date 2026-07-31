// Data/CrmDbContextFactory.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AutoescolaReisSite.Crm.Data
{
    public class CrmDbContextFactory : IDesignTimeDbContextFactory<CrmDbContext>
    {
        public CrmDbContext CreateDbContext(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__CrmDb");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException(
                    "Variável de ambiente ConnectionStrings__CrmDb não encontrada. " +
                    "Rode 'set ConnectionStrings__CrmDb=...' (cmd) antes de usar o dotnet ef.");
            }

            var optionsBuilder = new DbContextOptionsBuilder<CrmDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new CrmDbContext(optionsBuilder.Options);
        }
    }
}