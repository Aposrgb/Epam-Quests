<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WebApplication1.Profile" %>

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
             <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
             <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
             </br>
             <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
             <asp:TextBox ID="TextBox2" runat="server" Visible="false"></asp:TextBox>
            <div id="LoginTop">
                
                <asp:Button ID="Button3" runat="server" Text="Изменить логин" OnClick="Button3_Click"/>
                <asp:Button ID="Button4" runat="server" Text="Задать статус?" OnClick="Button4_Click"/>
                <asp:Button ID="Button5" runat="server" Visible="false" Text="Отмена" OnClick="Button5_Click"/>
            </div>
            
            <div>
                <div id="NameList">Ваш список навыков</div>
               <div>
                   <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
               </div>
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
            </div>
            <asp:Button ID="Button1" runat="server" Text="Страница навыков" OnClick="Button1_Click" />
            <div id="LoginTop">
                <asp:Button ID="Button6" runat="server" Text="Сменить пароль?" OnClick="Button6_Click" />
                <asp:Button ID="Button2" runat="server" Text="Выйти из аккаунта" OnClick="Button2_Click" />
            </div>
           </div>
    </form>
</body>
</html>
