<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="BlogPersonal.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Regístrate</h1>
    <!-- Debo validar los campos requeridos etc -->
    <asp:Label Text="Email" runat="server" Font-Size="Larger" Font-Bold="true" />
    <asp:TextBox runat="server" Id="txtUsuario" CssClass="form-control" />
    
    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
    <br />
     <asp:Label Text="Contraseña" runat="server" Font-Size="Larger" Font-Bold="true" />
    <asp:TextBox runat="server" ID="txtPass" CssClass="form-control"  TextMode="Password"/>
     <br />
    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar"  CssClass="btn btn-dark"  OnClick="btnIngresar_Click" />
</asp:Content>
