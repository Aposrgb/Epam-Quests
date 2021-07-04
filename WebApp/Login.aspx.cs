using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessLayer;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private BL b = new BL();// Экземпляр класса логики
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] != null) {
                Response.Redirect("Profile.aspx");// Если в сессии есть запомненный логин то входить снова не требуется
            }
        }
        protected void Button1_Click(object sender, EventArgs e)//Войти 
        {
            Label4.Text = b.EntryAccount(TextBox1.Text, TextBox2.Text);//Метод вернет строку с фразой при неверных данных и вернет пустоту если все верно
            if (Label4.Text.Length == 0)// Если нет фразы заполните поля или неверные данные то аутентификация пройдена успешна
            {
                Session["Login"] = TextBox1.Text;// Запоминание логина пользователя в сессии(чуть позже сделаю по ID)
                Response.Redirect("Profile.aspx");// Переход к странице регистрации
            }
        }
        protected void Button2_Click(object sender, EventArgs e)//Регистрация
        {
            Response.Redirect("Reg.aspx");// Переход к странице регистрации
        }

       
    }
}