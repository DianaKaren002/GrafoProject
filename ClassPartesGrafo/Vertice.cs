using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPartesGrafo
{
    public class Vertice
    {
        internal Libro detalles = null;
        internal AristasLista ListaEnlaces = new AristasLista();

        public Vertice(Libro datos)
        {
            detalles = datos;
        }

        public string AgregarArista(int numVertices,float costo2)
        {
            return ListaEnlaces.InsertaObjeto(numVertices, costo2);
        }

        public string[] MuestraAristas()
        {
            return ListaEnlaces.MostrarColeccion();
        }

        public string DetallesLibro()
        {
            return $"Libro : {detalles.IdLibro} \n Titulo: {detalles.Titulo}\n" +
                $"Autor: {detalles.Autor} \n Precio: {detalles.Genero} \n Genero: {detalles.Genero}";
        }
    }
}
