<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="Style.css"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="root">
            <asp:Label ID="LabelLog" runat="server" Text="Логин"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Пароль"></asp:Label>
            <br />
            <asp:TextBox TextMode="Password" ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Войти" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Регистрация" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>
