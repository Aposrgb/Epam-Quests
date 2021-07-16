
using Entites;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class DB_SQL:IDL
    {
        private SqlConnection db;
        private string str="";
        public DB_SQL(string url)
        {
            str = url;
            db = new SqlConnection(url);
        }
        public void UpdateSkillName(string new_name,string name, string type)
        {
            using (db = new SqlConnection(str))
            {
                db.Open();
                SqlCommand c1 = new SqlCommand("Exec UpdateNameSkill @new_name,@name,@type", db);
                c1.Parameters.Add(new SqlParameter("@name", name));
                c1.Parameters.Add(new SqlParameter("@type", type));
                c1.Parameters.Add(new SqlParameter("@new_name", new_name));
                c1.ExecuteNonQuery();
            }
        }
        public string DeleteAllSkill(string name, string type) {
            using (db = new SqlConnection(str))
            {
                db.Open();
                SqlCommand c1 = new SqlCommand("Exec DeleteSkill_User @name,@type", db);
                c1.Parameters.Add(new SqlParameter("@name", name));
                c1.Parameters.Add(new SqlParameter("@type", type));
                c1.ExecuteNonQuery();

                c1 = new SqlCommand("Exec DeleteSkill @name,@type", db);
                c1.Parameters.Add(new SqlParameter("@name", name));
                c1.Parameters.Add(new SqlParameter("@type", type));
                c1.ExecuteNonQuery();

                int Id_temp=-1;
                int Id_typeskill=0;
                foreach (DataRow row in GetTypeSkill().Rows) {
                    if ((string)row["Name"] == type) {
                        Id_typeskill = (int)row["Id"];
                        foreach (DataRow rows in GetSkills().Rows) {
                            if ((int)row["Id"] == (int)rows["Id_Type"]) {
                                Id_temp = (int)row["Id"];
                            }
                        }
                        
                    }
                }
                db = new SqlConnection(str);
                db.Open();
                if (Id_temp == -1) {
                    c1 = new SqlCommand("Exec DeleteTypeSkill "+Id_typeskill, db);
                    c1.ExecuteNonQuery();
                }   
            }
            return "";
        }
        public string GetRole(int Id) {
            DataTable table = new DataTable();
            using (db = new SqlConnection(str))
            {
                db.Open();
                SqlCommand c1 = new SqlCommand("Exec GetProfiles_Id " + Id, db);
                SqlDataAdapter ad = new SqlDataAdapter(c1);
                ad.Fill(table);
            }
            return table.Rows[0]["Role"].ToString();
        }
        public string ChangePass(string Login, string old_pass, string new_pass) {
            int id_tmp = -1 ;
            DataTable table = GetProfiles();//Получение всех профилей пользователей
            foreach (DataRow row in table.Rows)
            {
                if (Login == (string)row["Login"] && old_pass == (string)row["Password"])
                {
                    id_tmp = (int)row["Id"];
                }
            }
            if (id_tmp == -1) {
                return "Неверный логин или пароль";
            }
            using (db = new SqlConnection(str))
            {
                db.Open();
                SqlCommand c1 = new SqlCommand("Exec SetNewPass "+id_tmp+",@newpass", db);
                c1.Parameters.Add(new SqlParameter("@newpass", new_pass));
                c1.ExecuteNonQuery();
            }
            return "";
        }
        public string SetStatus(int Id,string text)
        {
            using (db = new SqlConnection(str))
            {
                db.Open();
                SqlCommand c1 = new SqlCommand("Exec SetStatus "+Id+",@txt",db );
                c1.Parameters.Add(new SqlParameter("@txt", text));
                c1.ExecuteNonQuery();
            }
            return "";
        }
        public string GetStatus(int Id) {
            DataTable table = new DataTable();
            using (db = new SqlConnection(str))
            {
                db.Open();
                SqlCommand c1 = new SqlCommand("Exec GetProfiles_Id "+ Id, db);
                SqlDataAdapter ad = new SqlDataAdapter(c1);
                ad.Fill(table);
            }
            return table.Rows[0]["Status"].ToString();
        }
        
        public string UpdateLogin(int Id, string Login)
        {
            UpdateLoginUser(Id, Login);
            return "";
        }
        public string CreateUser(string Email, string Login, string Password)
        {
            UserInsert(Email, Login, Password);
            return "";
        }
        public void AddSkillUser(string name, string type, int Id)
        {
            DataTable table = GetSkills();
            foreach (DataRow row in table.Rows)
            {
                if (row["Name"].ToString() == name && GetTypeSkillonID((int)row["Id_Type"]).Rows[0]["Name"].ToString() == type)
                {
                    InsertSkillUser((int)row["Id"], Id);
                }
            }
        }
        public string GetUserLogin(int Id)
        {
            DataTable table = GetProfiles();//Получение всех профилей пользователей
            foreach (DataRow row in table.Rows)
            {
                if (Id == (int)row["Id"])
                {
                    return row["Login"].ToString();
                }
            }
            return "что-то пошло не так";
        }
        public List<Skills> GetSkillsUser(int Id)
        {
            List<Skills> l = new List<Skills>();
            DataTable table = GetSkillWithId();//Получение таблицы всех навыков, которые добавили пользователи  + с Id пользователя
            foreach (DataRow row in table.Rows)
            {
                if (Id == (int)row["Id_User"])// Поиск пользователя по таблице
                {
                    DataTable table1 = GetSkillsonID((int)row["Id_Skill"]);// Получение таблицы всех навыков одного пользователя
                    foreach (DataRow row1 in table1.Rows)
                    {
                        Skills s = new Skills();
                        s.Name = (string)row1["Name"];
                        s.Type = GetTypeSkillonID((int)row1["Id_Type"]).Rows[0]["Name"].ToString();//Получение вида навыка черезе DL
                        l.Add(s);
                    }
                }
            }
            return l;// Возвращение списка навыков пользователя
        }
        public string EntryAccount(string Login, string Password)
        {
            DataTable table = GetProfiles();//Получение всех профилей пользователей
            foreach (DataRow row in table.Rows)
            {
                if (Login == (string)row["Login"] && Password == (string)row["Password"])
                {// Поиск по соответствиям
                    return row["Id"].ToString();
                }
            }
            return "Неверные данные";//Если система не нашла профиль пользователя на страницу возвращается такая фраза
        }
        public List<string> GetListTypeSkills()
        {
            List<string> l = new List<string>();
            DataTable table = GetTypeSkill();
            foreach (DataRow row in table.Rows)
            {
                string s = row["Name"].ToString();
                l.Add(s);
            }
            return l;
        }
        public void DeleteSkill(string name, string type, int Id)
        {
            DataTable table = GetSkills();
            foreach (DataRow row in table.Rows)
            {
                if (row["Name"].ToString() == name && GetTypeSkillonID((int)row["Id_Type"]).Rows[0]["Name"].ToString() == type)
                {
                    DeleteSkillUser((int)row["Id"], Id);
                }
            }
        }
        public List<Skills> GetListSkills()
        {
            List<Skills> l = new List<Skills>();
            DataTable table = GetSkills();
            foreach (DataRow row in table.Rows)
            {
                Skills s = new Skills();
                s.Name = (string)row["Name"];
                s.Type = GetTypeSkillonID((int)row["Id_Type"]).Rows[0]["Name"].ToString();
                l.Add(s);
            }
            return l;
        }


        public DataTable GetTypeSkill()
        {
            DataTable table = new DataTable();
            using (db = new SqlConnection(str))
            {
                SqlCommand c1 = new SqlCommand("Exec GetAllTypeSkill ", db);
                db.Open();
                SqlDataAdapter ad = new SqlDataAdapter(c1);
                ad.Fill(table);
            }
            return table;
        }
        public DataTable GetTypeSkillonID(int Id)
        {
            DataTable table = new DataTable();
            using (db = new SqlConnection(str))
            {
                SqlCommand c1 = new SqlCommand("Exec GetTypeSkill " + Id, db);
                db.Open();
                SqlDataAdapter ad = new SqlDataAdapter(c1);
                ad.Fill(table);
            }
            return table;
        }
        public DataTable GetSkillsonID(int Id)
        {
            DataTable table = new DataTable();
            using (db = new SqlConnection(str))
            {
                SqlCommand c1 = new SqlCommand("Exec GetSkillOnID " + Id, db);
                db.Open();
                SqlDataAdapter ad = new SqlDataAdapter(c1);
                ad.Fill(table);
            }
            return table;
        }
        public DataTable GetSkills()
        {
            DataTable table = new DataTable();
            using (db = new SqlConnection(str))
            {
                SqlCommand c1 = new SqlCommand("Exec GetSkills", db);
                db.Open();
                SqlDataAdapter ad = new SqlDataAdapter(c1);
                ad.Fill(table);
            }
            return table;
        }
        public DataTable GetSkillWithId()
        {
            DataTable table = new DataTable();
            using (db = new SqlConnection(str))
            {
                SqlCommand c1 = new SqlCommand("Exec GetSkill_id", db);
                db.Open();
                SqlDataAdapter ad = new SqlDataAdapter(c1);
                ad.Fill(table);
            }
            return table;
        }
        public void UserInsert(string Email, string Login, string Password) {
            using (db = new SqlConnection(str))
            {
                SqlCommand c1 = new SqlCommand("Exec InsertNewUser @email,@login,@pass", db);
                db.Open();
                c1.Parameters.Add(new SqlParameter("@email",Email));
                c1.Parameters.Add(new SqlParameter("@login", Login));
                c1.Parameters.Add(new SqlParameter("@pass", Password));
                c1.ExecuteNonQuery();
            }
        }
        public void InsertSkillUser(int Id_skill, int Id_user)
        {
            using (db = new SqlConnection(str))
            {
                SqlCommand c1 = new SqlCommand("Exec InsertSkillUser @skill,@user", db);
                db.Open();
                c1.Parameters.Add(new SqlParameter("@skill", Id_skill));
                c1.Parameters.Add(new SqlParameter("@user", Id_user));
                c1.ExecuteNonQuery();
            }
        }
        public void DeleteSkillUser(int Id_skill, int Id_user)
        {
            using (db = new SqlConnection(str))
            {
                SqlCommand c1 = new SqlCommand("Exec DelSkill " + Id_skill+","+Id_user, db);
                db.Open();
                c1.ExecuteNonQuery();
            }
        }
        public DataTable GetProfiles()
        {
            DataTable table = new DataTable();
            using(db = new SqlConnection(str))
            {
                SqlCommand c1 = new SqlCommand("Exec GetProfiles", db);
                db.Open();
                SqlDataAdapter ad = new SqlDataAdapter(c1);
                ad.Fill(table);
            }
            return table;
        }
        public void UpdateLoginUser(int Id, string Login) {
            using(db = new SqlConnection(str))
            {
                SqlCommand c1 = new SqlCommand("Exec UpdLogin @log," + Id, db);
                c1.Parameters.Add(new SqlParameter("@log",Login));
                db.Open();
                c1.ExecuteNonQuery();
            }
        }
        public void AddSkillOnID(string name, int Id)
        {
            using(db = new SqlConnection(str))
            {
                SqlCommand c1 = new SqlCommand("Exec AddSkill @name,@Id", db);
                db.Open();
                c1.Parameters.Add(new SqlParameter("@name", name));
                c1.Parameters.Add(new SqlParameter("@Id", Id));
                c1.ExecuteNonQuery();
            }
        }
        public string AddSkillOnType(string name,string type) {
            DataTable table1 = GetSkills();
            foreach (DataRow row in table1.Rows)
            {
                if (row["Name"].ToString() == name)
                {
                    return "Уже есть такой навык";
                }
            }
            foreach (DataRow row in table1.Rows)
            {
                if (GetTypeSkillonID((int)row["Id_Type"]).Rows[0]["Name"].ToString() == type)
                {
                    AddSkillOnID(name, (int)row["Id_Type"]);
                    return "";
                }
            }
            using (db = new SqlConnection(str))
            {
                SqlCommand c1 = new SqlCommand("Exec InsertNewType @type", db);
                db.Open();
                c1.Parameters.Add(new SqlParameter("@type", type));
                c1.ExecuteNonQuery();

                c1 = new SqlCommand("Exec GetInsertId", db);
                DataTable table2 = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(c1);
                ad.Fill(table2);
                
                c1 = new SqlCommand("Exec AddSkill @name,@Id", db);
                c1.Parameters.Add(new SqlParameter("@name", name));
                c1.Parameters.Add(new SqlParameter("@Id", table2.Rows[0]["Id"]));
                c1.ExecuteNonQuery();
                ;
            }
            return "";
        }
    }
}
