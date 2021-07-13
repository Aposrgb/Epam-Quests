using System;
using Dependecy;

namespace WebApplication
{
    public partial class Skill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if ((string)Session["Role"] != "Админ") {
                Button4.Visible = false;
            }
            Label5.Text = "<h1>Вы "+(string)Session["Role"]+ "</h1>";
            Label1.Text = DependecyResolver.Instance.b.HtmlListSkill((int)Session["Id"]);
            if (!String.IsNullOrEmpty(Request["Add"]))
            {
                DependecyResolver.Instance.b.AddSkillUser(Request["Add"], Request["Type"],(int)Session["Id"]);
                Response.Redirect("Skill.aspx");
            }
            if (!String.IsNullOrEmpty(Request["Del"]))
            {
                DependecyResolver.Instance.b.DeleteSkill(Request["Del"], Request["Type"], (int)Session["Id"]);
                Response.Redirect("Skill.aspx");
            }
            if (!String.IsNullOrEmpty(Request["DeleteName"]))
            {
                DependecyResolver.Instance.b.DeleteAllSkill(Request["DeleteName"], Request["DeleteNameType"]);
                Response.Redirect("Skill.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (!TextBox1.Visible)
            {
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                Label2.Visible = true;
                Label3.Visible = true;
                Button2.Text = "Добавить";
                Button3.Visible = true;
                Button4.Visible = false;
            }
            else
            {
                Label4.Text = DependecyResolver.Instance.b.AddSkill(TextBox1.Text,TextBox2.Text);
                if (Label4.Text != "") {
                    return;
                }
                TextBox1.Visible = false;
                TextBox2.Visible = false;
                Label2.Visible = false;
                Label3.Visible = false;
                Button2.Text = "Добавить свои навыки";
                Button3.Visible = false;
                Response.Redirect("Skill.aspx");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Skill.aspx");
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (Button2.Visible)
            {
                Button2.Visible = false;
                Label1.Text = DependecyResolver.Instance.b.EditHtmlListSkill((int)Session["Id"]);
                Button4.Text = "Закончить редактирование";
            }
            else {
                Button4.Text = "Редактирование навыков";
                Button2.Visible =true;
            }
                
            
        }
    }
}