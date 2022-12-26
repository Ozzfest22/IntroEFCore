using IntroEFCore.Entidades;
using IntroEFCore.Entidades.Seeding;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IntroEFCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);

            //Examina el proyecto y busca las clases que implementan la interfaz IEntityConfiguration y aplica las configuraciones aqui
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            
            SeedingInicial.Seed(modelBuilder);

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //Los campos de tipo string se van a configurar como nvarchar 150
            configurationBuilder.Properties<string>().HaveMaxLength(150);
        }

        public DbSet<Genero> Generos => Set<Genero>();
        public DbSet<Actor> Actores => Set<Actor>(); 
        public DbSet<Pelicula> Peliculas => Set<Pelicula>();
        public DbSet<Comentario> Comentarios => Set<Comentario>();

        public DbSet<PeliculaActor> PeliculasActores => Set<PeliculaActor>();
    }
}
