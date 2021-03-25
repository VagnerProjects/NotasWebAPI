using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NotasWebAPI.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasWebAPI.Contexto
{
    public class CelinaDbContext:DbContext
    {
      

        public CelinaDbContext(DbContextOptions<CelinaDbContext> options)
            :base(options)
        {
            
        }

        public CelinaDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("CelinaBaseDB");
            optionsBuilder.UseSqlServer(connectionString);
        }




        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        public override int SaveChanges()
        {
            var cetZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataDeCadastro") != null))
            {

                if (entry.State == EntityState.Added)
                    entry.Property("DataDeCadastro").CurrentValue = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cetZone);

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataDeCadastro").IsModified = false;
                    entry.Property("DataDeAlteracao").CurrentValue = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cetZone);

                }
            }
            return base.SaveChanges();
        }

    }
}
