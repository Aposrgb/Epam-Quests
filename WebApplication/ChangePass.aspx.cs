using System;

namespace WebApplication
{
    public partial class ChangePass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Id"] = null;

        }
        protected void Button1_Click(object sender, EventArgs e) {
            Label4.Text=Dependecy.DependecyResolver.Instance.b.ChangePass(TextBox1.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text);
            if (Label4.Text == "") {
                Label4.Text = "Успешно!";
            }
        }
        protected void Button2_Click(object sender, EventArgs e) {
            Response.Redirect("Login.aspx");
        }
    }
}