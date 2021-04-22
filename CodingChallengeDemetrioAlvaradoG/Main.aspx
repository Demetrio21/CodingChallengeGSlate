<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="CodingChallengeDemetrioAlvaradoG.Main" %>

<!DOCTYPE html>
<link href="css/bootstrap.min.css" rel="stylesheet">
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
<link href="Main.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CodingChallenge</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Coins Information</h1>
            <div>Get Drinks <asp:Label ID="lblMachineMoney" runat="server" Text=""></asp:Label></div>
            <div class="row">
                <% foreach(var item in coinLabels){ %>
                <div class="col-md-3">  
                <%= item.name %>
                </div>
                <% } %>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <asp:TextBox ID="txtCent" runat="server">0</asp:TextBox>
                    <asp:CompareValidator runat="server"
                         ControlToValidate="txtCent"
                        Operator="DataTypeCheck"
                        Type="Integer"
                        ErrorMessage="Enter a valid integer"
                        Display="Dynamic"
                        Text="Must be an integer"
                     />

                    <asp:CompareValidator runat="server"
                        ControlToValidate="txtCent"
                        Operator="GreaterThanEqual"
                        ValueToCompare="0"
                        Type="Integer"
                        ErrorMessage="The integer cannot be less than zero"
                        Display="Dynamic"
                        Text="Can't be less than 0"
                    />
                </div>
                <div class="col-md-3">
                   <asp:TextBox ID="txtPenny" runat="server">0</asp:TextBox>
                     <asp:CompareValidator runat="server"
                         ControlToValidate="txtPenny"
                        Operator="DataTypeCheck"
                        Type="Integer"
                        ErrorMessage="Enter a valid integer"
                        Display="Dynamic"
                        Text="Must be an integer"
                     />

                    <asp:CompareValidator runat="server"
                        ControlToValidate="txtPenny"
                        Operator="GreaterThanEqual"
                        ValueToCompare="0"
                        Type="Integer"
                        ErrorMessage="The integer cannot be less than zero"
                        Display="Dynamic"
                        Text="Can't be less than 0"
                    />
                </div>
                <div class="col-md-3">
                   <asp:TextBox ID="txtNickel" runat="server">0</asp:TextBox>
                    <asp:CompareValidator runat="server"
                         ControlToValidate="txtNickel"
                        Operator="DataTypeCheck"
                        Type="Integer"
                        ErrorMessage="Enter a valid integer"
                        Display="Dynamic"
                        Text="Must be an integer"
                     />

                    <asp:CompareValidator runat="server"
                        ControlToValidate="txtNickel"
                        Operator="GreaterThanEqual"
                        ValueToCompare="0"
                        Type="Integer"
                        ErrorMessage="The integer cannot be less than zero"
                        Display="Dynamic"
                        Text="Can't be less than 0"
                    />
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtQuarter" runat="server">0</asp:TextBox>
                    <asp:CompareValidator runat="server"
                         ControlToValidate="txtQuarter"
                        Operator="DataTypeCheck"
                        Type="Integer"
                        ErrorMessage="Enter a valid integer"
                        Display="Dynamic"
                        Text="Must be an integer"
                     />

                    <asp:CompareValidator runat="server"
                        ControlToValidate="txtQuarter"
                        Operator="GreaterThanEqual"
                        ValueToCompare="0"
                        Type="Integer"
                        ErrorMessage="The integer cannot be less than zero"
                        Display="Dynamic"
                        Text="Can't be less than 0"
                    />
                </div>
            </div>
            <h1>Products Information</h1>
            <div class="row">
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="row">
                            <div  class="col-md-6" >
                                <asp:Label ID="lblProd1" runat="server" Text="Label"></asp:Label>
                                <asp:Label ID="lblProd1Details" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div  class="col-md-6" >
                                 <asp:TextBox ID="txtProd1" runat="server" AutoPostBack="true" OnTextChanged="getTotal_TextChanged">0</asp:TextBox>
                            </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="row">
                            <div  class="col-md-6" >
                                <asp:Label ID="lblProd2" runat="server"  Text="Label"></asp:Label>
                                <asp:Label ID="lblProd2Details" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div  class="col-md-6" >
                                <asp:TextBox ID="txtProd2" runat="server" AutoPostBack="true" OnTextChanged="getTotal_TextChanged">0</asp:TextBox>
                            </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="row">
                            <div  class="col-md-6" >
                                <asp:Label ID="lblProd3" runat="server" Text="Label "></asp:Label>
                                <asp:Label ID="lblProd3Details" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div  class="col-md-6" >
                                <asp:TextBox ID="txtProd3" runat="server" AutoPostBack="true" OnTextChanged="getTotal_TextChanged">0</asp:TextBox>
                            </div>                           
                        </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div>
                        Order Total
                    </div>
                    <div>
                        <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblNoEnough" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
            <div> 
                <asp:Label ID="lblChange" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblOrder" runat="server" Text=""></asp:Label>
            </div>
            <asp:Button ID="btnGetDrinks" runat="server" Text="Get Drinks" OnClick="btnGetDrinks_Click" />
        </div>
    </form>

</body>
</html>
