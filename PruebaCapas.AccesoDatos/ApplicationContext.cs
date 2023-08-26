namespace PruebaCapas.AccesoDatos
{
    using Microsoft.EntityFrameworkCore;
    using PruebaCapas.Modelos;

    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<ColorPiel> ColoresPiel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configuramos el ID de persona
            modelBuilder.Entity<Persona>()
                        .HasKey(p => p.Id);

            //Configuramos la propiedad Nombre
            modelBuilder.Entity<Persona>()
                        .Property(p => p.Nombre)
                        .IsRequired();

            //Configuramos la propiedad Apellido
            modelBuilder.Entity<Persona>()
                        .Property(p => p.Apellido)
                        .IsRequired();

            //Configuramos la propiedad Fecha de nacimiento
            modelBuilder.Entity<Persona>()
                        .Property(p => p.FechaNacimiento)
                        .IsRequired();

            //Configuramos la propiedad DNI
            modelBuilder.Entity<Persona>()
                        .Property(p => p.Dni)
                        .HasMaxLength(99_999_999)
                        .IsRequired();

            //Configuramos la propiedad DNI
            modelBuilder.Entity<Persona>()
                        .Property(p => p.Nacionalidad)
                        .HasMaxLength(20);

            modelBuilder.Entity<ColorPiel>()
                        .HasKey(p => p.Id);

            modelBuilder.Entity<ColorPiel>()
                        .Property(p => p.Nombre)
                        .IsRequired();

            modelBuilder.Entity<Persona>()
                        .HasOne(persona => persona.ColorPiel)
                        .WithMany(colorPiel => colorPiel.Personas)
                        .HasForeignKey(persona => persona.IdColorPiel);
        }
    }
}
