using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessLayer;

namespace WebApplication
{
    public partial class Skill : System.Web.UI.Page
    {
        private BL b = new BL();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = b.GetListSkills();
            GridView1.DataBind();
        }
    }
}