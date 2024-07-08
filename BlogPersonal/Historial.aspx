<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Historial.aspx.cs" Inherits="BlogPersonal.Historial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .oculto {
            display: none;
        }
        .container {
           
        }
        h1 {
            margin-top: 20px;
            margin-bottom: 40px;
        }
        .tabla {
            border: 1px solid #D5164D;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="container" style="width:100%"; margin: 0; padding: 0 ; >
        <h1>Historial de Entradas</h1>

        <asp:GridView runat="server" ID="dgvEntradas" class="tabla" CssClass="table"  AutoGenerateColumns="false" OnRowCommand="dgvEntradas_RowCommand" DataKeyNames="Id">
            <Columns>
                <asp:BoundField HeaderText="Titulo" DataField="Titulo" />
                <asp:BoundField HeaderText="Fecha de creación" DataField="FechaCreacion" />
                <asp:BoundField HeaderText="Texto" DataField="ResumenTexto"  />
                <asp:ButtonField HeaderText="Editar"  Text="✍" CommandName="Editar" ButtonType="Button"/>
                <asp:ButtonField HeaderText="Agregar a favoritos" Text="❤" CommandName="AgregarFavoritos" ButtonType="Button"/>

            </Columns> 
        </asp:GridView>
   </div>
</asp:Content>
