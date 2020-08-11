using System;
using GerFin.Infrastructure.EntityConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GerFin.ApplicationCore.Entity
{
    public class GerFinContext : DbContext
    {
        public GerFinContext()
        {
        }

        public GerFinContext(DbContextOptions<GerFinContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Receita> Receitas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReceitaMap());
        }
    }
}
