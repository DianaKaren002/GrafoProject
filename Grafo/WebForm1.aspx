<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Grafo.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <h1>Grafo Libros</h1>
            <asp:Panel ID="Panel1" runat="server">
                 <h4>Agregar vertice Grafo</h4>
                
                <asp:Label ID="Label2" runat="server" Text="Id"></asp:Label> <br />
                <asp:TextBox ID="txtId" runat="server"></asp:TextBox> <br />
                <asp:Label ID="Label1" runat="server" Text="Titulo"></asp:Label> <br />
                <asp:TextBox ID="txtTitulo" runat="server"></asp:TextBox> <br />
                <asp:Label ID="Label3" runat="server" Text="Editorial"></asp:Label> <br />
                <asp:TextBox ID="txtEditorial" runat="server"></asp:TextBox> <br />
                <asp:Label ID="Label4" runat="server" Text="Autor"></asp:Label> <br />
                <asp:TextBox ID="txtAutor" runat="server"></asp:TextBox> <br />
                <asp:Label ID="Label5" runat="server" Text="Genero"></asp:Label> <br />
                <asp:TextBox ID="txtGenero" runat="server"></asp:TextBox> <br />
                <asp:Label ID="Label6" runat="server" Text="Precio"></asp:Label> <br />
                <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox> <br />
                <asp:Button ID="btnAgregaVerticeGrafo" runat="server" Text="Crear Grafo (vertices)" OnClick="btnAgregaVerticeGrafo_Click" /> <br />
                <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
