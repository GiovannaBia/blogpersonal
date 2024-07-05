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

    <asp:GridView runat="server" ID="dgvEntradas" CssClass="table table-dark"  AutoGenerateColumns="false"  OnSelectedIndexChanged="dgvEntradas_SelectedIndexChanged"  DataKeyNames="Id" >
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="Id"  ItemStyle-CssClass="oculto"/>
            <asp:BoundField HeaderText="Titulo" DataField="Titulo" />
            <asp:BoundField HeaderText="Fecha de creación" DataField="FechaCreacion" />
            <asp:BoundField HeaderText="Texto" DataField="Texto"  />
            <asp:CommandField  HeaderText="Editar"  SelectText="✍" ShowSelectButton="true"/>
        </Columns> 
    </asp:GridView>
</asp:Content>
