using GerFin.ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerFin.Infrastructure.EntityConfig
{
    public class ReceitaMap : IEntityTypeConfiguration<Receita>
    {
        public void Configure(EntityTypeBuilder<Receita> builder)
        {
            builder.ToTable("Receita");

            builder.HasKey(r => r.ReceitaId);
            builder.Property(r => r.Descricao).HasColumnType("varchar(300)").HasMaxLength(300).IsRequired();
            builder.Property(r => r.Valor).HasColumnType("decimal(14, 2)").IsRequired();
            builder.Property(r => r.Recebido).HasColumnType("bit").HasDefaultValueSql("0");
            builder.Property(r => r.DataRecebido).HasColumnType("datetime");
            builder.Property(r => r.Recorrente).HasColumnType("bit").HasDefaultValueSql("0");

        }
    }
}
