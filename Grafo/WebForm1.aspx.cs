using ClassPartesGrafo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Grafo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        GrafoLibros grafo1 = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                grafo1 = new GrafoLibros();
                Session["grafo1"] = grafo1;
            }
            else
            {
                grafo1 = (GrafoLibros)Session["grafo1"];
            }
        }

        protected void btnAgregaVerticeGrafo_Click(object sender, EventArgs e)
        {
            try
            {
                Libro nuevo = new Libro
                {
                    IdLibro = Convert.ToInt16(txtId.Text),
                    Titulo = txtTitulo.Text,
                    Editorial = txtEditorial.Text,
                    Autor = txtAutor.Text,
                    Genero = txtGenero.Text,
                    Precio = Convert.ToDouble(txtPrecio.Text)
                };

                // recuperar el grafo 
                GrafoLibros grafo1 = (GrafoLibros)Session["grafo1"];

                grafo1.AgregarVerice(nuevo);

                // crea aristas automáticas
                Random rand = new Random();
                int nuevoVerticeIndex = grafo1.ListaAdyacente.Count - 1;
                for (int i = 0; i < nuevoVerticeIndex; i++)
                {
                    // crea un costo aleatorio para la arista
                    float costo = (float)(rand.NextDouble() * 100);

                    // inserta arista desde el nuevo vertice a los existentes
                    grafo1.AgregarArista(nuevoVerticeIndex, i, costo);

                    // inserta arista desde los existentes al nuevo vertice
                    grafo1.AgregarArista(i, nuevoVerticeIndex, costo);
                }

                // guardar el grafo reciente en la sesión
                Session["grafo1"] = grafo1;

                // muestra mensjae de exito
                lblMensaje.Text = "Vértice y aristas agregados exitosamente.";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al agregar el vértice: " + ex.Message;
            }
        }
    }
}