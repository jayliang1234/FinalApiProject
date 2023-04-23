using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using FinalProjectAPI.Models;

namespace FinalProjectAPI.Models
{
    public class FinalProjectDBContext : DbContext
    {

        protected readonly IConfiguration Configuration;

        public FinalProjectDBContext(DbContextOptions<FinalProjectDBContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("FinalProject");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Champion> Champions { get; set; } = null!;
        public DbSet<Abilities> Abilities { get; set; } = null!;
    }
}
