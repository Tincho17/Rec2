<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegistroUsuario.aspx.cs" Inherits="Rec2.RegistroUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Registro de Usuario</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div>
            <h3>Registro de Usuario</h3>

            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" EnableViewState="False"></asp:Label>

            <div>
                <label>Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </div>

            <div>
                <label>Apellido:</label>
                <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            </div>

            <div>
                <label>Dirección:</label>
                <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
            </div>

            <div>
                <label>Email:</label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </div>

            <div>
                <label>Confirmar Email:</label>
                <asp:TextBox ID="txtConfirmarEmail" runat="server"></asp:TextBox>
            </div>
            <br>
                                     <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />

            <br>
        </div>
</asp:Content>
