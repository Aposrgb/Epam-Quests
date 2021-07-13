using System;
using Dependecy;

namespace WebApplication1
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Label1.Text = "Привет " + DependecyResolver.Instance.b.GetUserLogin((int)Session["Id"]);
            Label3.Text ="Ваш статус:</br>"+ DependecyResolver.Instance.b.GetStatus((int)Session["Id"]);
            GridView1.DataSource = DependecyResolver.Instance.b.GetSkillsUser((int)Session["Id"]);
            GridView1.DataBind();
            if (GridView1.Rows.Count == 0)
            {
                Label2.Text = "Похоже вы не добавили ни единого навыка. </br> Навыки можно добавить на странице навыков.";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Role"] = DependecyResolver.Instance.b.GetRole((int)Session["Id"]);
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
                TextBox1.Text = DependecyResolver.Instance.b.GetUserLogin((int)Session["Id"]);
                TextBox1.Visible = true;
                Label1.Visible = false;
                Button3.Text = "Закончить";
            }
            else
            {
                Label1.Text = DependecyResolver.Instance.b.UpdateLogin((int)Session["Id"], TextBox1.Text);
                Label1.Visible = true;
                if (Label1.Text == "")
                {
                    Label1.Text = "Привет " + DependecyResolver.Instance.b.GetUserLogin((int)Session["Id"]);
                    TextBox1.Visible = false;
                    Label1.Visible = true;
                    Button3.Text = "Изменить логин";
                }

            }
        }
        protected void Button4_Click(object sender, EventArgs e) {
            if (!TextBox2.Visible)
            {
                TextBox2.Visible = true;
                Button3.Visible = false;
                Button2.Visible = false;
                Button5.Visible = true;
            }
            else {
                Label3.Text = DependecyResolver.Instance.b.SetStatus((int)Session["Id"], TextBox2.Text);
                if (Label3.Text == "") {
                    Label3.Text = "Ваш статус:</br>" + DependecyResolver.Instance.b.GetStatus((int)Session["Id"]);
                    Button5.Visible = false;
                    Button3.Visible = true;
                    Button2.Visible = true;
                    TextBox2.Visible = false;
                }
            }
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            Button5.Visible = false;
            Button3.Visible = true;
            Button2.Visible = true;
            TextBox2.Visible = false;
        }
        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePass.aspx");
        }
    }
}