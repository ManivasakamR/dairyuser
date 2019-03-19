<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Showqr.aspx.cs" Inherits="_Default" %>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
  <div style="margin-left:2%; margin-right:2%;">
    <asp:Image ID="imgQRCode" style="display: block;  margin-top:20px; margin-left:auto; margin-right: auto; width: 80%;" runat="server" Visible="false" />                                  
  <div style="text-align:center; margin-top:30px;" class="cls text-primary" runat="server" id="MyServerControlDiv"></div>
      </div>
</asp:Content>

