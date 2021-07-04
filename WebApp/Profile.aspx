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
            <div id="LoginTop">
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
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
            

        </div>
    </form>
</body>
</html>
