using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace IntroEFCore.Entidades.Configuraciones
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            //modelBuilder.Entity<Actor>().Property(a => a.Nombre).HasMaxLength(150);
            builder.Property(a => a.FechaNacimiento).HasColumnType("date");
            builder.Property(a => a.Fortuna).HasPrecision(18, 2);
        }
    }
}
