<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CargaArchivos.aspx.cs" Inherits="Rec2.CargaArchivos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True" />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cargar al servidor" />
             <div>
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
                  <br />
            <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:ButtonField ButtonType="Button" CommandName="Descargar" HeaderText="Descargar" ShowHeader="True" Text="Descargar" />
                </Columns>
            </asp:GridView>
                   <br />
                  <br />
                 <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <br />

      </div>
</asp:Content>
