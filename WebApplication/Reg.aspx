<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reg.aspx.cs" Inherits="WebApplication1.Reg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="Style.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div id="root">
            <asp:Button ID="ButtonReg" runat="server" Text="Назад" OnClick="ButtonReg_Click" />
            <div>
                <asp:Label ID="Label1" runat="server" Text="Почта"></asp:Label>
                <br />
                <asp:TextBox TextMode="Email" ID="TextBox1" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Логин"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Пароль"></asp:Label>
                <br />
                <asp:TextBox TextMode="Password" ID="TextBox3" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                <asp:Button ID="Button1" runat="server" Text="Зарегистрироваться" OnClick="Button1_Click" />
            </div>
        </div>
    </form>
</body>
</html>
