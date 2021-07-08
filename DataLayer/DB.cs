using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class DB:IDL
    {
        private SqlConnection db;
        private string str="";

        public DB(string url)
        {
            str = url;
            db = new SqlConnection(url);
        }
        public DataTable GetTypeSkill()
        {
            db = new SqlConnection(str);
            DataTable table = new DataTable();
            using (db)
            {
                SqlCommand c1 = new SqlCommand("Exec GetAllTypeSkill ", db);
                db.Open();
                SqlDataAdapter ad = new SqlDataAdapter(c1);
                ad.Fill(table);
            }
            return table;
        }
        public DataTable GetTypeSkill(int Id)
        {
            db = new SqlConnection(str);
            DataTable table = new DataTable();
            using (db)
            {
                SqlCommand c1 = new SqlCommand("Exec GetTypeSkill " + Id, db);
                db.Open();
                SqlDataAdapter ad = new SqlDataAdapter(c1);
                ad.Fill(table);
            }
            return table;
        }
        public DataTable GetSkills(int Id)
        {
            db = new SqlConnection(str);
            DataTable table = new DataTable();
            using (db)
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
            db = new SqlConnection(str);
            DataTable table = new DataTable();
            using (db)
            {
                SqlCommand c1 = new SqlCommand("Exec GetSkills", db);
                db.Open();
                SqlDataAdapter ad = new SqlDataAdapter(c1);
                ad.Fill(table);
            }
            return table;
        }
        public DataTable GetSkill_Id()
        {
            db = new SqlConnection(str);
            DataTable table = new DataTable();
            using (db)
            {
                SqlCommand c1 = new SqlCommand("Exec GetSkill_id", db);
                db.Open();
                SqlDataAdapter ad = new SqlDataAdapter(c1);
                ad.Fill(table);
            }
            return table;
        }
        public void UserInsert(string Email, string Login, string Password) {
            db = new SqlConnection(str);
            using (db)
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
            db = new SqlConnection(str);
            using (db)
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
            db = new SqlConnection(str);
            using (db)
            {
                SqlCommand c1 = new SqlCommand("Exec DelSkill " + Id_skill+","+Id_user, db);
                db.Open();
                c1.ExecuteNonQuery();
            }
        }
        public DataTable GetProfiles()
        {
            db = new SqlConnection(str);
            DataTable table = new DataTable();
            using (db)
            {
                SqlCommand c1 = new SqlCommand("Exec GetProfiles", db);
                db.Open();
                SqlDataAdapter ad = new SqlDataAdapter(c1);
                ad.Fill(table);
            }
            return table;
        }
        public void UpdateLoginUser(int Id, string Login) {
            db = new SqlConnection(str);
            using (db)
            {
                SqlCommand c1 = new SqlCommand("Exec UpdLogin @log," + Id, db);
                c1.Parameters.Add(new SqlParameter("@log",Login));
                db.Open();
                c1.ExecuteNonQuery();
            }
        }
        public void AddSkill(string name, int Id)
        {
            db = new SqlConnection(str);
            using (db)
            {
                SqlCommand c1 = new SqlCommand("Exec AddSkill @name,@Id", db);
                db.Open();
                c1.Parameters.Add(new SqlParameter("@name", name));
                c1.Parameters.Add(new SqlParameter("@Id", Id));
                c1.ExecuteNonQuery();
            }
        }
        public void AddSkill(string name,string type) {
            db = new SqlConnection(str);
            using (db)
            {
                SqlCommand c1 = new SqlCommand("Exec InsertNewType @type", db);
                db.Open();
                c1.Parameters.Add(new SqlParameter("@type", type));
                c1.ExecuteNonQuery();

                c1 = new SqlCommand("Exec GetInsertId", db);
                DataTable table = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(c1);
                ad.Fill(table);
                
                c1 = new SqlCommand("Exec AddSkill @name,@Id", db);
                c1.Parameters.Add(new SqlParameter("@name", name));
                c1.Parameters.Add(new SqlParameter("@Id", table.Rows[0]["Id"]));
                c1.ExecuteNonQuery();
                ;
            }
        }
        public static void Main() { }
    }
}
