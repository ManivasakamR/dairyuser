<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Purchase.aspx.cs" Inherits="Default2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
   <div style="margin-left:2%; margin-right:2%;">
        <asp:Label ID="LblPurchase" runat="server" Style="font-size:24px; margin-left:43%;" Text="Requirement" CssClass="text-primary"></asp:Label><br />
        <asp:Label ID="LblReqMor" runat="server" Style="font-size:20px;" Text="Morning" CssClass="text-primary"></asp:Label>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" CssClass="valStyle" ErrorMessage="Required" ControlToValidate="TxtReqMor"></asp:RequiredFieldValidator> 
           <asp:RegularExpressionValidator ControlToValidate = "TxtReqMor" CssClass="valStyle" ID="RegularExpressionValidator4" ValidationExpression = "^-?([0-9]{0,9}(\.[0-9])?|100(\.00?)?)$" runat="server" ErrorMessage="Must be a number"></asp:RegularExpressionValidator>     
           <br />
        <asp:TextBox ID="TxtReqMor" runat="server"  CssClass="txtbx btn-block"></asp:TextBox>
        <asp:Label ID="LblReqEve" runat="server" Text="Evening" Style="font-size:20px;" CssClass="text-primary"></asp:Label>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="valStyle" ErrorMessage="Required" ControlToValidate="TxtReqEve"></asp:RequiredFieldValidator> 
           <asp:RegularExpressionValidator ControlToValidate = "TxtReqEve" CssClass="valStyle" ID="RegularExpressionValidator1" ValidationExpression = "^-?([0-9]{0,9}(\.[0-9])?|100(\.00?)?)$" runat="server" ErrorMessage="Must be a number"></asp:RegularExpressionValidator>            
            <br />
        <asp:TextBox ID="TxtReqEve" runat="server" CssClass="txtbx btn-block"></asp:TextBox>
        <div class="cls" runat="server" id="MyServerControlDiv"></div>
        <asp:Button ID="BtnCurrent" runat="server" Text="Current" OnClick="BtnCurrent_Click" CausesValidation="false" Style="margin-top:8px;" CssClass="btn btn-primary btn-block" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Update"  CausesValidation="true" OnClick="BtnUpdate_Click" Style="margin-top:3px;" CssClass="btn btn-primary btn-block" />
   </div>
</asp:Content>

