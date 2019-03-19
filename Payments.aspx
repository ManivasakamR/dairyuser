<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Payments.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <div style="margin-left:2%; margin-right:2%;">
    <asp:Label ID="LblPayments" runat="server" Style="font-size:24px; margin-left:33%;" Text="Payments" CssClass="text-primary"></asp:Label><br />
    <div class="cls" runat="server" id="MyServerControlDiv"></div>
    <asp:Button ID="BtnPay" runat="server" Text="Continue to pay" OnClick="BtnPay_Click" Style="margin-top:3px;" CssClass="btn btn-primary btn-block" />
        </div>
</asp:Content>

