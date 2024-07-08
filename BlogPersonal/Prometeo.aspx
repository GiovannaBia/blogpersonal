<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Prometeo.aspx.cs" Inherits="BlogPersonal.Prometeo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .prometeo {
            height: 100%;               
        }

        .card {          
            margin: 50px auto; 
            padding: 20px;
            box-sizing: border-box; 
            border: 0px solid #ddd; 
            background-color: #fff; 
            height:contain;
        }

        h5 {
            font-size: 30px;
        }
         h6 {
            font-size: 15px;
        }
         p {
             font-size: 20px;
         }

         .btn {
             width: 100px;
             background-color: #C70039; 
             margin-top:20px;
         }
         .btn:hover {
              background-color: #D5164D;
         }
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="prometeo">
        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="card" style="width: 90%;">
                    <h5 class="card-title"><%#Eval("Titulo")%></h5>
                    <h6 class="card-subtitle mb-2 text-body-secondary"><%#Eval("FechaCreacion")%></h6>
                    <p class="card-text"><%#Eval("Texto")%></p>
                    <img src=" <%#Eval("UrlImagenEntrada")%> " class="card-img-top" alt="">
                    <asp:Button text="Editar" class="btn" runat="server" Id="btnEditar" CommandArgument='<%#Eval("Id")%>' CommandName="EntradaId"  OnClick="btnEditar_Click"/>
                </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
