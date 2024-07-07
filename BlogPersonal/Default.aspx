<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BlogPersonal.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .label {
            font-weight: 700;
            font-size: larger;
            margin: 20px;
        }
        .labelTexto {
            font-size: medium;
            margin-left: 20px;
            margin-bottom: 30px;
        }
        .card-link {
            position:absolute;
            bottom: 20px;
            left: 20px;
        }
        .card {
            position:relative;
            margin: 100px;
        }

        h3 {
            margin: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Prometeo</h1>

    <div class="card">  
            <asp:Label runat="server"  CssClass="label" ID="lblTitulo"></asp:Label>
            <br />
            <asp:Label runat="server"  CssClass="labelTexto" ID="lblTexto"/>
           <br />
            <a href="#" class="card-link"> Leer más.. </a>        
    </div>

    <div class="card">       
            <h3>Tu entrada favorita </h3>
            <asp:Label runat="server"  CssClass="label" ID="LabelFavorita"></asp:Label>
            <br />
            <asp:Label runat="server"  CssClass="labelTexto" ID="LabelFavoritaTexto"/>
           <br />
            <asp:Image  Visible="false" runat="server" id="img"/>
            <a href="#" class="card-link"> Leer más.. </a>        
    </div>

    <div class="card text-center" style="margin: 100px;  ">
        <div class="card-header" style="background-color:#FF5733 ; font-size:20px; font-weight:500; color:white;">
            ¿Cual es tu reflexión del día?
        </div>
        <div class="card-body">
            <h5 class="card-title">¡Comparte tus pensamientos aquí!</h5>
            <p class="card-text">Cuéntanos tus reflexiones.</p>
            <a href="NuevaEntrada.aspx" class="btn" style="background-color: #C70039; font-size: 15px; font-weight:600; color:white;">Nueva entrada</a>
        </div>
</div>
</asp:Content>
