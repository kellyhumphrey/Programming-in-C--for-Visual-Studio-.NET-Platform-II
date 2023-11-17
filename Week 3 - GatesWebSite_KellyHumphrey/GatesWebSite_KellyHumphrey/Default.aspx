<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Gates Cell Phones (Main Menu)</p>
        <p>
            <asp:HyperLink ID="InventoryHyperlink" runat="server" NavigateUrl="~/Inventory.aspx">Go to Inventory</asp:HyperLink>
        </p>
        <asp:HyperLink ID="CustomerHyperLink" runat="server" NavigateUrl="~/Customer.aspx">Go to Customer</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="OrderHyperLink" runat="server" NavigateUrl="~/Order.aspx">Go to Order</asp:HyperLink>
    </form>
</body>
</html>
