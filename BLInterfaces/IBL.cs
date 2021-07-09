using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLInterfaces
{
    public interface IBL
    {
        string CreateUser(string Email, string Login, string Password);
        string EntryAccount(string Login, string Password);
        string UpdateLogin(int Id, string Login);
        string GetUserLogin(int Id);
        List<ISkills> GetSkillsUser(int Id);
        List<string> GetListTypeSkills();
        List<ISkills> GetListSkills();
        void DeleteSkill(string name, string type, int Id);
        string AddSkill(string name, string type);
        void AddSkillUser(string name, string type, int Id);
        string HtmlListSkill(int Id);
    }
}
