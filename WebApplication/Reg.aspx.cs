using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessLayer;
using Dependecy;

namespace WebApplication1
{
    public partial class Reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] != null)// Если в сессии есть запомненный логин то входить снова не требуется
            {
                Response.Redirect("Profile.aspx");
            }
        }

        protected void ButtonReg_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label4.Text= DependecyResolver.Instance.b.CreateUser(TextBox1.Text, TextBox2.Text, TextBox3.Text);//Метод вернет строку с фразой при неверных данных и вернет пустоту если все верно
            if (Label4.Text.Length==0)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}