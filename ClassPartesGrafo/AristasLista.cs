using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPartesGrafo
{
    public class AristasLista
    {
        internal VerticesLista inicio = null;
        private int contElements = 0;

        public string InsertaObjeto(int numV, float cost)
        {
            string msj = "";
            VerticesLista nuevo = new VerticesLista();
            nuevo.NumVertice = numV;
            nuevo.costo = cost;
            if(inicio == null)
            {
                inicio = nuevo;
                contElements++;
                msj = "Primer elemento (libro) en la coleccion";
            }
            else
            {
                VerticesLista temp = null;
                temp = inicio;
                while(temp.siguiente != null)
                {
                    temp = temp.siguiente;
                }
                temp.siguiente = nuevo;
                contElements++;
                msj = "Ya hay elementos, este no es el primero";
            }
            return msj;
        }

        public string[] MostrarColeccion()
        {
            string[] cads = new string[contElements];
            VerticesLista z = null;
            z = inicio;
            int w = 0;
            while(z != null)
            {
                cads[w] = $"Posicion enlace a: [{z.NumVertice}]" +
                    $"costo: {z.costo}";
                z = z.siguiente;
                w++;
            }
            return cads;
        } 
    }
}
