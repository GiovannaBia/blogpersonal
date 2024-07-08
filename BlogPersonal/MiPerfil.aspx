<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="BlogPersonal.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            padding: 30px;
        }
        h1 {
            margin-bottom: 20px;
        }
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="width: 100%; margin: 0; padding: 0 ; ">

        <h1>Mi perfil</h1>
        <br />
        <div class="row">
        <div class="col-6">        
            <div class="mb-3">
                <asp:Label Text="Email" runat="server" />
                <asp:TextBox runat="server" id="txtEmail" cssclass="form-control" ReadOnly="true" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Nombre" runat="server" />
                <asp:TextBox runat="server" id="txtNombre" cssclass="form-control" TextMode="MultiLine"/>
            </div>
            <div class="mb-3" >
                <asp:Label Text="Biografía" runat="server" />
                <asp:TextBox runat="server" id="txtBiografia" CssClass="form-control" TextMode="MultiLine" Height=150px />
            </div>
            <asp:Button Text="Guardar" runat="server" ID="btnGuardar"  CssClass="btn btn-dark" OnClick="btnGuardar_Click" />
            <asp:Label ID="lblSuccess" runat="server" CssClass="text-success" Visible="false" />
            <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false" />
        </div>
        <div class="col-6">
            <div class="mb-3">
                    <label class="form-label"></label>
                    <input type="file" ID="txtImagen" runat="server" class="form-control" />
             </div>
             <asp:Image ID="imgNuevoPerfil" ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg" runat="server" CssClass="img-fluid mb-3" Width="300px" Height="300px"/>
        </div>

        </div>
    </div>

</asp:Content>
