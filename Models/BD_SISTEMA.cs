namespace SistemaGestionDeConfiguracionSoftware.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BD_SISTEMA : DbContext
    {
        public BD_SISTEMA()
            : base("name=BD_SISTEMA")
        {
        }

        public virtual DbSet<METODOLOGIA> METODOLOGIA { get; set; }
        public virtual DbSet<PROYECTO> PROYECTO { get; set; }
        public virtual DbSet<TIPO_USUARIO> TIPO_USUARIO { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<METODOLOGIA>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<METODOLOGIA>()
                .HasMany(e => e.PROYECTO)
                .WithRequired(e => e.METODOLOGIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROYECTO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<PROYECTO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<TIPO_USUARIO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<TIPO_USUARIO>()
                .HasMany(e => e.USUARIO)
                .WithRequired(e => e.TIPO_USUARIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.APELLIDO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.CODIGO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.TELEFONO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.PROYECTO)
                .WithRequired(e => e.USUARIO)
                .HasForeignKey(e => e.ID_JEFEPROYECTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.PROYECTO1)
                .WithRequired(e => e.USUARIO1)
                .HasForeignKey(e => e.ID_CLIENTE)
                .WillCascadeOnDelete(false);
        }
    }
}
