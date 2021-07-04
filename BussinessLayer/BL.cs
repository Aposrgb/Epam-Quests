using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BussinessLayer
{
    public class BL
    {
        private string URL = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\abbos\source\repos\WebApplication\DB_Epam.mdf;Integrated Security=True;Connect Timeout=30";
        private DB db;
        public BL() {
            db = new DB(URL);
        }
        public string CreateUser(string Email,string Login,string Password) {
            if (Email == "" || Login == "" || Password == "") {// Проверка на пустоту на страничке регистрации
                return "Заполните поля";
            }
            db = new DB(URL);
            db.UserInsert(Email, Login, Password);//
            return "";
        }
        public string EntryAccount(string Login, string Password) {
            if (Login == "" || Password == ""){// Проверка на пустоту на страничке входа
                return "Заполните поля";
            }
            db = new DB(URL);
            DataTable table =db.GetProfiles();//Получение всех профилей пользователей
            foreach(DataRow row in table.Rows) {
                if (Login == (string)row["Логин"] && Password == (string)row["Пароль"]) {// Поиск по соответствиям
                    return "";
                }
            }
            return "Неверные данные";//Если система не нашла профиль пользователя на страницу возвращается такая фраза
        }
        public List<Skills> GetSkillsUser(string Login)
        {
            List<Skills> l = new List<Skills>();
            db = new DB(URL);
            DataTable table = db.GetSkill_Id();//Получение таблицы всех навыков, которые добавили пользователи  + с Id пользователя
            foreach (DataRow row in table.Rows)
            {
                if (Login == (string)row["Логин_пользователя"])// Поиск пользователя по таблице
                {
                    db = new DB(URL);
                    DataTable table1 = db.GetSkills((int)row["Id_Навыка"]);// Получение таблицы всех навыков одного пользователя
                    foreach (DataRow row1 in table1.Rows)
                    {
                        db = new DB(URL);
                        Skills s = new Skills();
                        s.Name = (string)row1["Название"];
                        s.Type = db.GetTypeSkill((int)row1["Id_Вида"]).Rows[0]["Название"].ToString();//Получение вида навыка черезе DL
                        l.Add(s);
                    }
                }
            }
            return l;// Возвращение списка навыков пользователя
        }
        public List<Skills> GetListSkills() {
            List<Skills> l = new List<Skills>();
            db = new DB(URL);
            DataTable table = db.GetSkills();
            foreach (DataRow row in table.Rows)
            {
                db = new DB(URL);
                Skills s = new Skills();
                s.Name = (string)row["Название"];
                s.Type = db.GetTypeSkill((int)row["Id_Вида"]).Rows[0]["Название"].ToString();//Получение вида навыка черезе DL
                l.Add(s);
            }
            return l;
        }
        public static void Main() { }
        
    }
}
