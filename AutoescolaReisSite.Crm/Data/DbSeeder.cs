// Data/DbSeeder.cs
using AutoescolaReisSite.Crm.Models;
using Microsoft.AspNetCore.Identity;

namespace AutoescolaReisSite.Crm.Data
{
    public static class DbSeeder
    {
        public static void SeedUsuarioInicial(CrmDbContext db, IConfiguration configuration)
        {
            if (db.Usuarios.Any())
            {
                return; // já existe pelo menos um usuário — não faz nada
            }

            var email = configuration["Crm:AdminEmail"];
            var senha = configuration["Crm:AdminPassword"];

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                return; // sem credenciais configuradas, pula o seed
            }

            var usuario = new Usuario
            {
                Nome = "Administrador",
                Email = email
            };

            var hasher = new PasswordHasher<Usuario>();
            usuario.SenhaHash = hasher.HashPassword(usuario, senha);

            db.Usuarios.Add(usuario);
            db.SaveChanges();
        }
    }
}