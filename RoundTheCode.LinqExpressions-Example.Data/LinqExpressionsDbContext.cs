using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RoundTheCode.LinqExpressions_Example.Data.Models.Types;
using System;

namespace RoundTheCode.LinqExpressions_Example.Data
{
    public partial class LinqExpressionsDbContext : DbContext
    {
        public virtual DbSet<FilmEntity> FilmEntities { get; set; }

        public virtual DbSet<FilmTimeEntity> FilmTimeEntities { get; set; }

        public LinqExpressionsDbContext(DbContextOptions<LinqExpressionsDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("LinqExpressionsDbContext"));
        }
    }
}
