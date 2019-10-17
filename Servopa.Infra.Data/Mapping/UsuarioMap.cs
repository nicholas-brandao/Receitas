using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Servopa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servopa.Infra.Data.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(c => c.UsuarioId);

            builder.Property(c => c.Login)
                .IsRequired()
                .HasColumnName("Login");

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnName("Nome");
        }
    }
}
