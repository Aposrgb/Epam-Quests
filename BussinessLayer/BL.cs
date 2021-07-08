using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Entites;

namespace BussinessLayer
{
    public class BL
    {
        private const string URL = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\abbos\source\repos\WebApplication\DB_Epam.mdf;Integrated Security=True;Connect Timeout=30";
        private IUser u = new User(URL);
        private ISkills s = new Skills(URL);
        public string CreateUser(string Email,string Login,string Password) {
            return u.CreateUser(Email, Login, Password);
        }
        public int GetIDAccount() {
            return u.session_id; 
        }
        public string EntryAccount(string Login, string Password) {
            return u.EntryAccount(Login,Password);
        }
        public string UpdateLogin(int Id,string Login) {
            return u.UpdateLogin(Id,Login);
        }
        public string GetUserLogin(int Id) {
            return u.GetUserLogin(Id);
        }
        public List<Skills> GetSkillsUser(int Id){
            return u.GetSkillsUser(Id);
        }
        public List<string> GetListTypeSkills(){
            return s.GetListTypeSkills();
        }
        public List<Skills> GetListSkills() {
            return s.GetListSkills();
        }
        public void DeleteSkill(string name, string type, int Id){
            s.DeleteSkill(name,type,Id);
        }
        public string AddSkill(string name, string type) {
            return s.AddSkill(name, type);
        }
        public void AddSkillUser(string name, string type,int Id) {
            u.AddSkillUser(name, type,Id);
        }
        public string HtmlListSkill(int Id) {
            string str = "</br>";
            int j = 0;
            int m = 0;
            for (int i = 0; i < GetListTypeSkills().Count; i++) {
                str += "<h4>" + GetListTypeSkills()[i]+"</h4><table>";
                foreach(Skills s in GetListSkills()) {
                    if(s.Type== GetListTypeSkills()[i]) {
                        int tmp = str.Length;
                        foreach (Skills c in GetSkillsUser(Id)) {
                            if (c.Name == s.Name && s.Type==c.Type) {
                                str += "<tr><td class=\"Added\">" + s.Name + " (Навык добавлен)<form></form><form method=\"POST\" Action=\"\"><input class=\"Delete\" type=\"submit\" value=\"Удалить\"/><input name=\"Del\" type=\"hidden\" value=\"" + s.Name+ "\"/><input name=\"Type\" type=\"hidden\" value=\"" + s.Type + "\"/></form></td></tr>";
                                j++;
                            }
                        }
                        if (str.Length == tmp) {
                            str += "<tr><td>" + s.Name + "<form></form><form method=\"POST\" Action=\"\"><input class=\"Add\"  type=\"submit\" value=\"Добавить\"/><input name=\"Add\" type=\"hidden\" value=\"" + s.Name + "\"/><input name=\"Type\" type=\"hidden\" value=\"" + s.Type + "\"/></form></td></tr>";
                            m++;
                        }
                    }
                }
                str +="</table>";
            }
            return str;
        }
        public static void Main() { }
        
    }
}
