using Microsoft.EntityFrameworkCore;
using Servopa.Domain.Entities;
using Servopa.Infra.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servopa.Infra.Data.Context
{
    public class ServopaSqlServerContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public ServopaSqlServerContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);
        }
    }
}
