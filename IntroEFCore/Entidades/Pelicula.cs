namespace IntroEFCore.Entidades
{
    public class Pelicula
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = null!;

        public bool EnCines { get; set; }

        public DateTime FechaEstreno { get; set; }

        //No garantiza que los resultados vengan de manera ordenada
        public HashSet<Comentario> Comentarios { get; set; } = new HashSet<Comentario>();

        public HashSet<Genero> Generos { get; set; } = new HashSet<Genero>();

        public List<PeliculaActor> PeliculasActores { get; set; } = new List<PeliculaActor>();
    }
}
