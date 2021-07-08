<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Skill.aspx.cs" Inherits="WebApplication.Skill" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="StyleProfile.css"/> 
</head>
<body>

    <form id="form1" runat="server">
        <div id="root">
            <h2>Навыки которые можно добавить</h2>
            <asp:Button ID="Button1" runat="server" Text="Вернутся к профилю" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Добавить свои навыки" OnClick="Button2_Click" />

            <asp:Label ID="Label2" runat="server" Text="Название" Visible="false"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="Тип" Visible="false" ></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" Visible="false"></asp:TextBox>

            <asp:Button ID="Button3" runat="server" Text="Отменить" Visible="false" OnClick="Button3_Click" />
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>

            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
        
    </form>
</body>
</html>
