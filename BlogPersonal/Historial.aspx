<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Historial.aspx.cs" Inherits="BlogPersonal.Historial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .oculto {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Historial de Entradas</h1>

    <asp:GridView runat="server" ID="dgvEntradas" CssClass="table table-dark" AutoGenerateColumns="false" OnRowCommand="dgvEntradas_RowCommand" DataKeyNames="Id">
        <Columns>
            <asp:BoundField HeaderText="Titulo" DataField="Titulo" />
            <asp:BoundField HeaderText="Fecha de creación" DataField="FechaCreacion" />
            <asp:BoundField HeaderText="Texto" DataField="Texto"  />
            <asp:ButtonField HeaderText="Editar"  Text="✍" CommandName="Editar" ButtonType="Button"/>
            <asp:ButtonField HeaderText="Agregar a favoritos" Text="❤" CommandName="AgregarFavoritos" ButtonType="Button"/>

        </Columns> 
    </asp:GridView>
</asp:Content>
