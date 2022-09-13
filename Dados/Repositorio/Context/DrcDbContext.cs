using Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Repositorio.Context
{
    public class DrcDbContext : DbContext
    {
        public DrcDbContext() { }
        public DrcDbContext(DbContextOptions<DrcDbContext> options) : base(options) { }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<UnidadeMedida> UnidadeMedida { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile($"appsettings.json");

            var config = builder.Build();

            var str = config.GetConnectionString("DefaultConnection");

            optionsBuilder.UseMySql(str, ServerVersion.AutoDetect(str));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
