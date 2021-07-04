using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class DB
    {
        private SqlConnection db;

        public DB(string url)
        {
            db = new SqlConnection(url);
        }
        public DataTable GetTypeSkill(int Id)
        {
            DataTable table = new DataTable();
            using (db)
            {//Крайне желательно все операции с БД реализовать с помощью хранимых процедур
                SqlCommand c1 = new SqlCommand("Select Название from Вид_навыков where Id=" + Id, db);
                // Чуть позже заменю на процедуры, сейчас пока так чтобы не заморачиваться
                db.Open();
                SqlDataAdapter ad = new SqlDataAdapter(c1);
                ad.Fill(table);
            }
            return table;
        }
        public DataTable GetSkills(int Id)
        {
            DataTable table = new DataTable();
            using (db)
            {
                SqlCommand c1 = new SqlCommand("Select Название,Id_Вида from Навыки where Id="+Id, db);
                db.Open();
                SqlDataAdapter ad = new SqlDataAdapter(c1);
                ad.Fill(table);
            }
            return table;
        }
        public DataTable GetSkills()
        {
            DataTable table = new DataTable();
            using (db)
            {
                SqlCommand c1 = new SqlCommand("Select Название,Id_Вида from Навыки", db);
                db.Open();
                SqlDataAdapter ad = new SqlDataAdapter(c1);
                ad.Fill(table);
            }
            return table;
        }
        public DataTable GetSkill_Id()
        {
            DataTable table = new DataTable();
            using (db)
            {
                SqlCommand c1 = new SqlCommand("Select Id_Навыка,Логин_пользователя from Навыки_пользователей", db);
                db.Open();
                SqlDataAdapter ad = new SqlDataAdapter(c1);
                ad.Fill(table);
            }
            return table;
        }
        public void UserInsert(string Email, string Login, string Password) {
            using (db)
            {
                SqlCommand c1 = new SqlCommand("Insert Into Пользователи (Email,Логин,Пароль) values(@email,@login,@pass)", db);
                db.Open();
                c1.Parameters.Add(new SqlParameter("@email",Email));
                c1.Parameters.Add(new SqlParameter("@login", Login));
                c1.Parameters.Add(new SqlParameter("@pass", Password));
                c1.ExecuteNonQuery();
            }
        }
        public DataTable GetProfiles()
        {
            DataTable table = new DataTable();
            using (db)
            {
                SqlCommand c1 = new SqlCommand("Select Логин, Пароль from Пользователи", db);
                db.Open();
                SqlDataAdapter ad = new SqlDataAdapter(c1);
                ad.Fill(table);
            }
            return table;
        }
        public static void Main() { }
    }
}
