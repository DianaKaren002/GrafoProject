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

        protected void btnDFS_Click(object sender, EventArgs e)
        {
            int vert = Convert.ToInt16(txtSelectVertice.Text);
            List<string> resultadoDFS = grafo1.DFS(vert); // empieza desde vertice 0
            DropDownResultado.Items.Clear();
            foreach (var libro in resultadoDFS)
            {
                DropDownResultado.Items.Add(libro);
            }
        }

        protected void btnMostrarVertices_Click(object sender, EventArgs e)
        {
            string[] vertx = null;
            vertx = grafo1.MostrarVertices();
            DropDownMostrarVertices.Items.Clear();
            foreach (string s in vertx)
            {
                DropDownMostrarVertices.Items.Add(s);
            }

        }

        protected void btnBFS_Click(object sender, EventArgs e)
        {
            try
            {
                int vert = Convert.ToInt16(txtSelectVertice.Text);
                List<string> resultadoBFS = grafo1.BFS(vert); // Empieza desde el vértice 0
                foreach (var libro in resultadoBFS)
                {
                    DropDownResultado.Items.Add(libro);
                }
            }
            catch (FormatException ex)
            {
                lblMensaje.Text = "Error: Ingrese un número válido para el vértice.";
            }
            catch (Exception ex)
            {
                lblMensaje.Text=$"Error: {ex.Message}";
            }
        }

        protected void btnDibujarGrafo_Click(object sender, EventArgs e)
        {
            try
            {
                PanelGrafo.Controls.Clear(); // Limpiar el panel antes de dibujar de nuevo

                string[] vertices = grafo1.MostrarVertices();

                // Calcular posiciones para dibujar vértices en círculo
                int radio = 250; // Radio del círculo
                int centerX = (int)(PanelGrafo.Width.Value / 2); // Obtener el ancho del panel en píxeles
                int centerY = (int)(PanelGrafo.Height.Value / 2); // Obtener el alto del panel en píxeles
                int numVertices = vertices.Length;
                double angleIncrement = 2 * Math.PI / numVertices;

                for (int i = 0; i < numVertices; i++)
                {
                    // Calcular posición del vértice
                    int x = (int)(centerX + radio * Math.Cos(i * angleIncrement));
                    int y = (int)(centerY + radio * Math.Sin(i * angleIncrement));

                    // Crear etiqueta HTML para el vértice
                    Label vertice = new Label();
                    vertice.CssClass = "vertice";
                    vertice.Text = vertices[i];
                    vertice.ToolTip = "Vértice " + vertices[i];
                    vertice.Style.Add("left", x + "px");
                    vertice.Style.Add("top", y + "px");

                    // Agregar el vértice al panel
                    PanelGrafo.Controls.Add(vertice);
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al dibujar el grafo: " + ex.Message;
            }
        }
    }
}