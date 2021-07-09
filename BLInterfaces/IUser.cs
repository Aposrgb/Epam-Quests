using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLInterfaces
{
    public interface IUser
    {
        string EntryAccount(string Login, string Password);
        List<ISkills> GetSkillsUser(int Id);
        string GetUserLogin(int Id);
        void AddSkillUser(string name, string type, int Id);
        string CreateUser(string Email, string Login, string Password);
        string UpdateLogin(int Id, string Login);
    }
}
