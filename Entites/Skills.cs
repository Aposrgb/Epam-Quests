using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLInterfaces;

namespace Entites
{
    public class Skills:ISkills
    {
        private IDL db;
        private string str;
        public Skills() {}
        public Skills(string url)
        {
            str = url;
            db = new DB(url);
        }
        override
       public List<string> GetListTypeSkills()
        {
            List<string> l = new List<string>();
            DataTable table = db.GetTypeSkill();
            foreach (DataRow row in table.Rows)
            {
                string s = row["Название"].ToString();
                l.Add(s);
            }
            return l;
        }
        override
       public string AddSkill(string name, string type)
        {
            if (name == "" || type == "")
            {
                return "Неверные данные";
            }
            DataTable table = db.GetSkills();
            foreach (DataRow row in table.Rows)
            {
                if (row["Название"].ToString() == name)
                {
                    return "Уже есть такой навык";
                }
            }
            foreach (DataRow row in table.Rows)
            {
                if (db.GetTypeSkill((int)row["Id_Вида"]).Rows[0]["Название"].ToString() == type)
                {
                    db.AddSkill(name, (int)row["Id_Вида"]);
                    return "";
                }
            }
            db.AddSkill(name, type);
            return "";
        } override
        public void DeleteSkill(string name, string type, int Id)
        {
            DataTable table = db.GetSkills();
            foreach (DataRow row in table.Rows)
            {
                if (row["Название"].ToString() == name && db.GetTypeSkill((int)row["Id_Вида"]).Rows[0]["Название"].ToString() == type)
                {
                    db.DeleteSkillUser((int)row["Id"], Id);
                }
            }
        }
        override
      public List<ISkills> GetListSkills()
        {
            List<ISkills> l = new List<ISkills>();
            DataTable table = db.GetSkills();
            foreach (DataRow row in table.Rows)
            {
                Skills s = new Skills();
                s.Name = (string)row["Название"];
                s.Type = db.GetTypeSkill((int)row["Id_Вида"]).Rows[0]["Название"].ToString();//Получение вида навыка черезе DL
                l.Add(s);
            }
            return l;
        }
    }
}
