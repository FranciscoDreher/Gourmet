using System;
using Microsoft.EntityFrameworkCore;

namespace Gourmet
{
    public class GourmetContext : DbContext
    {
        public DbSet<Recetario> Recetarios { get; set; }
        public DbSet<RecetarioComida> RecetarioComidas { get; set; }
        public DbSet<Comida> Comidas { get; set; }
        public DbSet<ComidaIngrediente> ComidaIngredientes { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Alimento> Alimentos { get; set; }

        public GourmetContext()
        { 

        }

        public GourmetContext(DbContextOptions<GourmetContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite("Data Source=gourmet.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecetarioComida>()
                .HasKey(rc => new { rc.RecetarioId, rc.ComidaId });

            modelBuilder.Entity<RecetarioComida>()
                .HasOne(rc => rc.Recetario)
                .WithMany(r => r.RecetarioComidas)
                .HasForeignKey(rc => rc.RecetarioId);

            modelBuilder.Entity<RecetarioComida>()
                .HasOne(rc => rc.Comida)
                .WithMany(c => c.RecetarioComidas)
                .HasForeignKey(rc => rc.ComidaId);


            modelBuilder.Entity<ComidaIngrediente>()
                .HasKey(ci => new { ci.ComidaId, ci.IngredienteId });

            modelBuilder.Entity<ComidaIngrediente>()
                .HasOne(ci => ci.Comida)
                .WithMany(c => c.ComidaIngredientes)
                .HasForeignKey(ci => ci.ComidaId);

            modelBuilder.Entity<ComidaIngrediente>()
                .HasOne(ci => ci.Ingrediente)
                .WithMany(i => i.ComidaIngredientes)
                .HasForeignKey(ci => ci.IngredienteId);

            modelBuilder.Entity<Ingrediente>()
                .HasOne(i => i.Alimento)
                .WithMany(a => a.Ingredientes)
                .HasForeignKey(i => i.AlimentoId);
        }
    }
}