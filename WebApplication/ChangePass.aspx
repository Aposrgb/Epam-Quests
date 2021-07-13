<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePass.aspx.cs" Inherits="WebApplication.ChangePass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="Style.css">
</head>
<body>
    <form id="form1" runat="server">
        <div id="root">
            <asp:Label ID="LabelLog" runat="server" Text="Логин"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Старый пароль"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" ></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server"  Text="Новый пароль"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server" TextMode="Password" ></asp:TextBox>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Подтвердите пароль"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server" TextMode="Password" ></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Смена" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Войти в аккаунт" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>
