<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
   <title>Login</title>
      <link href="Content/bootstrap.css" rel="stylesheet" />         
    <link rel="stylesheet" href="Site/site.css" type="text/css" />    
    <script src="Scripts/jquery-3.0.0.js" type="text/javascript"></script>                                     
    <script src="Scripts/bootstrap.js" type="text/javascript"></script>  
    <script src="Site/SomeeAdsRemover.js"  type="text/javascript"></script>
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
  <a class="navbar-brand" href="#">
     <img src="Images/logo1.png" width="30" height="30" class="rounded-circle" alt=""/>
    Divine milk 
  </a>
</nav>
    <div class="row">
        <div class=" container-fluid" style="margin-left:2%; margin-right:2%;">
        <form id="form1" runat="server">
        <asp:Label ID="LblLogin" runat="server" Style="font-size:24px; margin-left:43%;" Text="Register" CssClass="text-primary"></asp:Label><br />
        <asp:Label ID="LblUsername" runat="server" Style="font-size:20px;" Text="Username" CssClass="text-primary"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="valStyle" ErrorMessage="Required" ControlToValidate="TxtUsername"></asp:RequiredFieldValidator> 
            <br />
        <asp:TextBox ID="TxtUsername" runat="server"  CssClass="txtbx btn-block"></asp:TextBox>
        <asp:Label ID="LblEmail" runat="server" Text="Email" Style="font-size:20px;" CssClass="text-primary"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="valStyle" ErrorMessage="Required" ControlToValidate="TxtEmail"></asp:RequiredFieldValidator> 
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="valStyle" ErrorMessage="Invalid" ControlToValidate="TxtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>            
            <br />
        <asp:TextBox ID="TxtEmail" runat="server" CssClass="txtbx btn-block"></asp:TextBox>
        <asp:Label ID="LblMobile" runat="server" Style="font-size:20px;" Text="Mobile Number" CssClass="text-primary"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="valStyle" ErrorMessage="Required" ControlToValidate="TxtMobile"></asp:RequiredFieldValidator> 
            <asp:RegularExpressionValidator ControlToValidate = "TxtMobile" CssClass="valStyle" ID="RegularExpressionValidator2" ValidationExpression = "^[\s\S]{10,10}$" runat="server" ErrorMessage="Must be 10 digits"></asp:RegularExpressionValidator>
            <br />
        <asp:TextBox ID="TxtMobile" runat="server"  CssClass="txtbx btn-block"></asp:TextBox>
        <asp:Label ID="LblCity" runat="server" Text="City" Style="font-size:20px;" CssClass="text-primary"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="valStyle" ErrorMessage="Required" ControlToValidate="TxtCity"></asp:RequiredFieldValidator>             
            <br />
        <asp:TextBox ID="TxtCity" runat="server" CssClass="txtbx btn-block"></asp:TextBox>
        <asp:Label ID="LblArea" runat="server" Style="font-size:20px;" Text="Area" CssClass="text-primary"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="valStyle" ErrorMessage="Required" ControlToValidate="TxtArea"></asp:RequiredFieldValidator> 
            <br />
        <asp:TextBox ID="TxtArea" runat="server"  CssClass="txtbx btn-block"></asp:TextBox>
        <asp:Label ID="LblApartment" runat="server" Text="Apartment" Style="font-size:20px;" CssClass="text-primary"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" CssClass="valStyle" ErrorMessage="Required" ControlToValidate="TxtApartment"></asp:RequiredFieldValidator> 
            <br />
        <asp:TextBox ID="TxtApartment" runat="server" CssClass="txtbx btn-block"></asp:TextBox>
        <asp:Label ID="LblDoor" runat="server" Text="DoorNo" Style="font-size:20px;" CssClass="text-primary"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" CssClass="valStyle" ErrorMessage="Required" ControlToValidate="TxtDoor"></asp:RequiredFieldValidator> 
            <br />
        <asp:TextBox ID="TxtDoor" runat="server" CssClass="txtbx btn-block"></asp:TextBox>
        <asp:Label ID="LblReqMor" runat="server" Style="font-size:20px;" Text="Morning Requirement" CssClass="text-primary"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" CssClass="valStyle" ErrorMessage="Required" ControlToValidate="TxtRM"></asp:RequiredFieldValidator> 
            <asp:RegularExpressionValidator ControlToValidate = "TxtRM" CssClass="valStyle" ID="RegularExpressionValidator3" ValidationExpression = "^-?([0-9]{0,9}(\.[0-9])?|100(\.00?)?)$" runat="server" ErrorMessage="Must be a number"></asp:RegularExpressionValidator>
            <br />
        <asp:TextBox ID="TxtRM" runat="server"  CssClass="txtbx btn-block"></asp:TextBox>
        <asp:Label ID="LblReqEve" runat="server" Style="font-size:20px;" Text="Evening Requirement" CssClass="text-primary"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" CssClass="valStyle" ErrorMessage="Required" ControlToValidate="TxtRE"></asp:RequiredFieldValidator> 
            <asp:RegularExpressionValidator ControlToValidate = "TxtRE" CssClass="valStyle" ID="RegularExpressionValidator4" ValidationExpression = "^-?([0-9]{0,9}(\.[0-9])?|100(\.00?)?)$" runat="server" ErrorMessage="Must be a number"></asp:RegularExpressionValidator>
            <br />
        <asp:TextBox ID="TxtRE" runat="server"  CssClass="txtbx btn-block"></asp:TextBox>
        <asp:Label ID="LblPin" runat="server" Style="font-size:20px;" Text="Pincode" CssClass="text-primary"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" CssClass="valStyle" ErrorMessage="Required" ControlToValidate="TxtPin"></asp:RequiredFieldValidator> 
            <asp:RegularExpressionValidator ControlToValidate = "TxtPin" CssClass="valStyle" ID="RegularExpressionValidator5" ValidationExpression = "^[\s\S]{6,6}$" runat="server" ErrorMessage="Must be 6 disits"></asp:RegularExpressionValidator>
            <br />
        <asp:TextBox ID="TxtPin" runat="server"  CssClass="txtbx btn-block"></asp:TextBox>        
        <asp:Label ID="LblPassword" runat="server" Style="font-size:20px;" Text="Password" CssClass="text-primary"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" CssClass="valStyle" ErrorMessage="Required" ControlToValidate="TxtPassword"></asp:RequiredFieldValidator>            
                        <asp:RegularExpressionValidator ControlToValidate = "TxtPassword" CssClass="valStyle" ID="RegularExpressionValidator6" ValidationExpression = "^[\s\S]{8,16}$" runat="server" ErrorMessage="Minimum 8 characters"></asp:RegularExpressionValidator>
            <br />
        <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" CssClass="txtbx btn-block"></asp:TextBox>        
        <asp:Label ID="LblCpassword" runat="server" Style="font-size:20px;" Text="Confirm Password" CssClass="text-primary"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" CssClass="valStyle" ErrorMessage="Required" ControlToValidate="TxtCpassword"></asp:RequiredFieldValidator> 
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TxtCpassword" CssClass="valStyle" ControlToCompare="TxtPassword" ErrorMessage="No match" ToolTip="Password must be the same" />
            <br />
        <asp:TextBox ID="TxtCpassword" runat="server" TextMode="Password" CssClass="txtbx btn-block"></asp:TextBox>        
            <div class="cls" runat="server" id="MyServerControlDiv"></div>
        <asp:Button ID="BtnRegister" runat="server" Text="Register" CausesValidation="true" OnClick="BtnRegister_Click1" Style="margin-top:8px;" CssClass="btn btn-primary btn-block" />        
        <asp:Button ID="BtnBack" runat="server" Text="Back" CausesValidation="false" OnClick="BtnBack_Click" Style="margin-top:3px;" CssClass="btn btn-block btn-primary"/>
    </form>
        </div>
    </div>    
</body>
</html>
