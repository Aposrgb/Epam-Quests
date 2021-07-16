using Entites;
using System.Collections.Generic;

namespace BLInterfaces
{
    public interface IBL
    {
        string CreateUser(string Email, string Login, string Password);
        string EntryAccount(string Login, string Password);
        string UpdateLogin(int Id, string Login);
        string GetUserLogin(int Id);
        List<Skills> GetSkillsUser(int Id);
        List<string> GetListTypeSkills();
        List<Skills> GetListSkills();
        void DeleteSkill(string name, string type, int Id);
        string AddSkill(string name, string type);
        void AddSkillUser(string name, string type, int Id);
        string GetStatus(int Id);
        string SetStatus(int Id,string text);
        string ChangePass(string Login,string old_pass,string new_pass, string check_pass);
        string GetRole(int Id);
        string DeleteAllSkill(string name, string type);
        void UpdateSkillName(string new_name,string name, string type);
    }
}
