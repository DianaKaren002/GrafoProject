using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPartesGrafo
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string Editorial { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public double Precio { get; set; }

        public Libro() { }
        public Libro(int idLibro,string titulo, string editorial, string autor,string genero, float precio)
        {
            IdLibro = idLibro;
            Titulo = titulo;
            Editorial = editorial;
            Autor = autor;
            Genero = genero;
            Precio = precio;
        }
    }
}
