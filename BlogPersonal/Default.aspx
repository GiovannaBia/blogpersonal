<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BlogPersonal.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .label {
            font-weight: 700;
            font-size: 30px;
            margin: 20px;
        }
        .labelTexto {
            font-size: 20px;
            margin-left: 20px;
            margin-bottom: 30px;
        }
        .labelfav {
            font-weight: 700;
            font-size: 30px;
            margin: 20px;
        }
          .labelTextofav {
            font-size: 20px;
            margin-left: 20px;
            margin-bottom: 30px;
        }
        .card-link {
            position:absolute;
            bottom: 20px;
            left: 35px;
            text-decoration: none;
            width: 100px;
            background-color: #C70039;
            border-radius: 10px;
            padding: 10px;
            color: white;  
        }
        .card-link:hover {
            background-color: #D5164D;
        }
        .card {
            position:relative;
            margin: 100px;
            padding: 20px;
        }

        .card h3 {
            margin: 20px;
        }

        h1 {
            margin: 40px;
            font-size: 50px;
        }

        .containerSinSesion {
            height: 500px;
            margin: 90px 0 !important;
            padding: 50px;
            text-align: center;
            color: #C70039;
            border-radius: 20px;
            position: relative;
            font-size: 20px;
           
        }
        .btnRegistro{
          border-radius: 10px;
          background-color: #C70039;
          text-decoration: none;
          padding: 15px;
          color: white;
          font-weight: 500;
          position: absolute;
          bottom: 70px;
          left: 50%; 
          transform: translateX(-50%);

        }
        .btnRegistro:hover {
            background-color: #D5164D ;
        }

       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <% if (Logica.Seguridad.SesionActiva(Session["usuario"])) { %>
    <div class="card sesion" id="cardUltimaEntrada" runat="server">  
            <asp:Label runat="server"  CssClass="label" ID="lblTitulo"></asp:Label>
            <br />
            <asp:Label runat="server"  CssClass="labelTexto" ID="lblTexto"/>
           <br />
            <a href="Prometeo.aspx" class="card-link btn" > Leer más.. </a>        
    </div>

    <div class="card sesion">       
            <h3>Tu entrada favorita ❤</h3>
            <asp:Label runat="server"  CssClass="labelfav" ID="LabelFavorita"></asp:Label>
            <br />
            <asp:Label runat="server"  CssClass="labelTextofav" ID="LabelFavoritaTexto"/>
           <br />
            <asp:Image  Visible="false" runat="server" id="img"/>
            <a href="Prometeo.aspx" class="card-link btn"> Leer más.. </a>        
    </div>
    <% } %>

     <% if (!Logica.Seguridad.SesionActiva(Session["usuario"]))
         { %>
            
    <div class="containerSinSesion">
        <h1>Registrate</h1>
        <h3> Expresa a tu manera lo que quieras </h3>
        <a href="Registro.aspx" class="btnRegistro">Registrarme</a>
    </div>

    <% } %>

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
