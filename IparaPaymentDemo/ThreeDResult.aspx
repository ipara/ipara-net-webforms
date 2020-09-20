<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ThreeDResult.aspx.cs" Inherits="IparaPaymentDemo.ThreeDResult1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteContent" runat="server">
    
    <div>
        <asp:Label ID="lblMessage" runat="server" Font-Size="14px" Font-Bold="true" BackColor="Maroon" ForeColor="White"></asp:Label>
    </div>
    
    <div id="result" runat="server"></div>
</asp:Content>
