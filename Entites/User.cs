using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using BLInterfaces;

namespace Entites
{
    public class User:IUser
    {
        private IDL db;
        private string str;
        public User(string url) {
            str = url;
            db = new DB(url);
        }
        
        public string EntryAccount(string Login, string Password)
        {
            if (Login == "" || Password == "")
            {// Проверка на пустоту на страничке входа
                return "Заполните поля";
            }
            db = new DB(str);
            DataTable table = db.GetProfiles();//Получение всех профилей пользователей
            foreach (DataRow row in table.Rows)
            {
                if (Login == (string)row["Логин"] && Password == (string)row["Пароль"])
                {// Поиск по соответствиям
                    return row["Id"].ToString();
                }
            }
            return "Неверные данные";//Если система не нашла профиль пользователя на страницу возвращается такая фраза
        }
        
       public List<ISkills> GetSkillsUser(int Id)
        {
            List<ISkills> l = new List<ISkills>();
            DataTable table = db.GetSkill_Id();//Получение таблицы всех навыков, которые добавили пользователи  + с Id пользователя
            foreach (DataRow row in table.Rows)
            {
                if (Id == (int)row["Id_пользователя"])// Поиск пользователя по таблице
                {
                    DataTable table1 = db.GetSkills((int)row["Id_Навыка"]);// Получение таблицы всех навыков одного пользователя
                    foreach (DataRow row1 in table1.Rows)
                    {
                        ISkills s=new Skills();
                        s.Name = (string)row1["Название"];
                        s.Type = db.GetTypeSkill((int)row1["Id_Вида"]).Rows[0]["Название"].ToString();//Получение вида навыка черезе DL
                        l.Add(s);
                    }
                }
            }
            return l;// Возвращение списка навыков пользователя
        }
        
       public string GetUserLogin(int Id)
        {
            DataTable table = db.GetProfiles();//Получение всех профилей пользователей
            foreach (DataRow row in table.Rows)
            {
                if (Id == (int)row["Id"])
                {
                    return row["Логин"].ToString();
                }
            }
            return "что-то пошло не так";
        }
        
       public void AddSkillUser(string name, string type, int Id)
        {
            DataTable table = db.GetSkills();
            foreach (DataRow row in table.Rows)
            {
                if (row["Название"].ToString() == name && db.GetTypeSkill((int)row["Id_Вида"]).Rows[0]["Название"].ToString() == type)
                {
                    db.InsertSkillUser((int)row["Id"], Id);
                }
            }
            
            
        }
        
       public string CreateUser(string Email, string Login, string Password)
        {
            if (Email == "" || Login == "" || Password == "")
            {
                return "Заполните поля";
            }
            db.UserInsert(Email, Login, Password);
            return "";
        }
        
       public string UpdateLogin(int Id, string Login)
        {
            if (Login == "")
            {
                return "Неверные данные";
            }
            db.UpdateLoginUser(Id, Login);
            return "";
        }
        public static void Main() { }
    }
}
