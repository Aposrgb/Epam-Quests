using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IDL
    {
        DataTable GetTypeSkill();
        DataTable GetTypeSkill(int Id);
        DataTable GetSkills(int Id);
        DataTable GetSkills();
        DataTable GetSkill_Id();
        DataTable GetProfiles();
        void AddSkill(string name, string type);
        void AddSkill(string name, int Id);
        void UpdateLoginUser(int Id, string Login);
        void UserInsert(string Email, string Login, string Password);
        void InsertSkillUser(int Id_skill, int Id_user);
        void DeleteSkillUser(int Id_skill, int Id_user);
    }
}
