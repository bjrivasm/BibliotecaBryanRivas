namespace BibliotecaBryanRivas;

public class Libro
{

    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Editorial { get; set; }
    public string Portada { get; set; }

    public Libro()
    {
    }

    public Libro(string titulo, string autor, string editorial, string imagenPortada)
    {
        Titulo = titulo;
        Autor = autor;
        Editorial = editorial;
        Portada = imagenPortada;
    }

}
