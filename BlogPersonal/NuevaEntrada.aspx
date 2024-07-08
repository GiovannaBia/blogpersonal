<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="NuevaEntrada.aspx.cs" Inherits="BlogPersonal.NuevaEntrada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            padding: 30px;
        }

        h1 {
            margin-bottom: 20px;
        }

        .btn {
            width: 100px;
            background-color: #C70039;
        }

        .btn:hover {
                background-color: #D5164D;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="width:100%; margin: 0; padding: 0"; > 
        <% if (Request.QueryString["id"] != null)
            { %>
        <h1>Editar entrada</h1>
        <% }
            else
            { %>
        <h1>Nueva Entrada</h1>
       <% } %>
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Titulo" runat="server" />
                <asp:TextBox runat="server" id="txtTitulo" cssclass="form-control"/>
            </div>
            <div class="mb-3">
                <asp:Label Text="Texto" runat="server" />
                <asp:TextBox runat="server" id="txtTexto" cssclass="form-control" TextMode="MultiLine"/>
            </div>
        
            <div class="mb-3">
                    <label class="form-label"></label>
                    <input type="file" ID="txtImagen" runat="server" class="form-control" />
             </div>
             <asp:Image ID="imgNuevoPerfil" ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg" runat="server" CssClass="img-fluid mb-3" Width="300px" Height="300px"/>
        </div>
        <asp:Button Text="Aceptar" runat="server"  ID="btnAceptar" class="btn" OnClick="btnAceptar_Click" />

    </div>
   

</asp:Content>
