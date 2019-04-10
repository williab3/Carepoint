<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyWebform.aspx.cs" Inherits="Carepoint.MyWebform" %>
<%@ Import Namespace=" System.Web.Optimization" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-3.3.1.js"></script>
    <script src="Scripts/bootstrap3.3.7.js"></script>
    <script src="Scripts/jquery.unobtrusive-ajax.js"></script>
    <script src="Scripts/jquery.validate.unobtrusive.js"></script>
    <link href="Content/Darkly3.3.7.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Login ID="Login1" runat="server">
            </asp:Login>
        </div>
    </form>
</body>
</html>
