using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessLayer;
using Entites;

namespace WebApplication1
{
    public partial class Profile : System.Web.UI.Page
    {
        private BL b = new BL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Label1.Text = "Привет " + b.GetUserLogin((int)Session["Id"]);
            GridView1.DataSource = b.GetSkillsUser((int)Session["Id"]);
            GridView1.DataBind();
            if (GridView1.Rows.Count == 0)
            {
                Label2.Text = "Похоже вы не добавили ни единого навыка. </br> Навыки можно добавить на странице навыков.";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Skill.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["Id"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (!TextBox1.Visible)
            {
                TextBox1.Text = b.GetUserLogin((int)Session["Id"]);
                TextBox1.Visible = true;
                Label1.Visible = false;
                Button3.Text = "Закончить";
            }
            else
            {
                Label1.Text = b.UpdateLogin((int)Session["Id"], TextBox1.Text);
                Label1.Visible = true;
                if (Label1.Text == "")
                {
                    Label1.Text = "Привет " + b.GetUserLogin((int)Session["Id"]);
                    TextBox1.Visible = false;
                    Label1.Visible = true;
                    Button3.Text = "Изменить логин";
                }

            }
        }
    }
}