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
        <div>
            Навыки которые можно добавить
             <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </div>
        
    </form>
</body>
</html>
