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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] != null) {
                Response.Redirect("Profile.aspx");// Если в сессии есть запомненный логин то входить снова не требуется
            }
            
        }
        protected void Button1_Click(object sender, EventArgs e)//Войти 
        {
            Label4.Text =DependecyResolver.Instance.b.EntryAccount(TextBox1.Text, TextBox2.Text);//Метод вернет строку с фразой при неверных данных и вернет пустоту если все верно
            if (Label4.Text != "Неверные данные" || Label4.Text != "Заполните поля")// Если нет фразы заполните поля или неверные данные то аутентификация пройдена успешна
            {
                Session["Id"] = int.Parse(Label4.Text);// Запоминание Id пользователя в сессии
                Response.Redirect("Profile.aspx");// Переход к странице регистрации
            }
        }
        protected void Button2_Click(object sender, EventArgs e)//Регистрация
        {
            Response.Redirect("Reg.aspx");// Переход к странице регистрации
        }

       
    }
}