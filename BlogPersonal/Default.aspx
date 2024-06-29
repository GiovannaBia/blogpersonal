<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BlogPersonal.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Prometeo</h1>
    <h2></h2>
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
