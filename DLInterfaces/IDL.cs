
using System.Collections.Generic;
using System.Data;

namespace DataLayer
{
    public interface IDL
    {
        DataTable GetTypeSkill();
        DataTable GetTypeSkillonID(int Id);
        DataTable GetSkillsonID(int Id);
        DataTable GetSkills();
        DataTable GetSkillWithId();
        DataTable GetProfiles();
        string AddSkillOnType(string name, string type);
        void AddSkillOnID(string name, int Id);
        void UpdateLoginUser(int Id, string Login);
        void UserInsert(string Email, string Login, string Password);
        void InsertSkillUser(int Id_skill, int Id_user);
        void DeleteSkillUser(int Id_skill, int Id_user);
        List<Entites.Skills> GetListSkills();
        void DeleteSkill(string name, string type, int Id);
        List<string> GetListTypeSkills();
        string EntryAccount(string Login, string Password);
        List<Entites.Skills> GetSkillsUser(int Id);
        string GetUserLogin(int Id);
        void AddSkillUser(string name, string type, int Id);
        string CreateUser(string Email, string Login, string Password);
        string UpdateLogin(int Id, string Login);
        string GetStatus(int Id);
        string SetStatus(int Id,string text);
        string ChangePass(string Login, string old_pass, string new_pass);
        string GetRole(int Id);
        string DeleteAllSkill(string name, string type);
        void UpdateSkillName(string new_name,string name, string type);
    }
}
