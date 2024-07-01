using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPartesGrafo
{
    public class GrafoLibros
    {
        public List<Vertice> ListaAdyacente = new List<Vertice>();

        public string AgregarVerice(Libro detLibro)
        {
            ListaAdyacente.Add(new Vertice(detLibro));
            return "Nuevo libro creado";
        }

        public string AgregarArista (int verticeOrig, int verticeDest, float costo3)
        {
            string msj = "";
            if(verticeOrig>=0 && verticeOrig <= (ListaAdyacente.Count - 1))
            {
                if(verticeDest >=0 && verticeDest <= (ListaAdyacente.Count - 1))
                {
                    ListaAdyacente[verticeOrig].AgregarArista(verticeDest, costo3);
                    msj = "Arista agregada";
                }
                else
                {
                    msj = "la posicion del vertice destino no existe en la lista adyacente";
                }
               
            }
            else
            {
                msj = "la posicion del vertice origen no existe en la lista adyacente";
            }
            return msj;
        }

        public string[] MostrarAristasVertice(int PosicionVert, ref string msj)
        {
            string[] salida = null;
            if(PosicionVert >= 0 && PosicionVert <= (ListaAdyacente.Count - 1))
            {
                salida = ListaAdyacente[PosicionVert].MuestraAristas();
            }
            else
            {
                msj = "La posicoon del vertice no existe en la lista de adyacencia";
            }
            return salida;
        }

        public List<string> MostrarAristasVerticeDest(int posicionVert, ref string msj)
        {
            VerticesLista temp = null; //ref para recorrer los nodo de lista de aristas

            List<string> salida = new List<string>();
            if (posicionVert >= 0 && posicionVert <= (ListaAdyacente.Count - 1))
            {
                temp = ListaAdyacente[posicionVert].ListaEnlaces.inicio;
                while (temp != null)
                {
                    salida.Add($"vertice destino =" +
                        $"{ListaAdyacente[temp.NumVertice].detalles.Titulo}" +
                        $" posicion enlace a:[ {temp.NumVertice}]" +
                        $"costo: {temp.costo}");
                    temp = temp.siguiente;
                }
                msj = "correcto";
            }
            else
            {
                msj = "la posicion del vestice no exite en " +
                                         "la lista de aduacencia";
            }
            return salida;
        }
        public string[] MostrarVertices()
        {
            string[] cads = new string[ListaAdyacente.Count];
            int h = 0;
            for (h = 0; h <= ListaAdyacente.Count - 1; h++)
            {
                cads[h] = ListaAdyacente[h].DetallesLibro();
            }
            return cads;
        }
    }
}
