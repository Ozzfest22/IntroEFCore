namespace IntroEFCore.Entidades
{
    public class Comentario
    {
        public int Id { get; set; }

        public string? Contenido { get; set; }

        public bool Recomendar { get; set; }

        //Se configura automaticamente como llave foranea por convencio,
        //ya que lleva el nombre de la tabla foranea + Id (Pelicula + Id = PeliculaId)
        public int PeliculaId { get; set; }

        public Pelicula Pelicula { get; set; } = null!;
    }
}
