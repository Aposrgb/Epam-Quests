using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessLayer;

namespace WebApplication1
{
    public partial class Profile : System.Web.UI.Page
    {
        private BL b = new BL();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "Привет "+(string)Session["Login"];
            GridView1.DataSource = b.GetSkillsUser((string)Session["Login"]);
            GridView1.DataBind();
            if (GridView1.Rows.Count == 0) {
                Label2.Text = "Похоже вы не добавили ни единого навыка. </br> Навыки можно добавить на странице навыков.";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Skill.aspx");
        }
    }
}