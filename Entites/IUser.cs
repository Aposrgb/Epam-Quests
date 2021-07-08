using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public abstract class IUser
    {
        public int session_id;
        public abstract string EntryAccount(string Login, string Password);
        public abstract List<Skills> GetSkillsUser(int Id);
        public abstract string GetUserLogin(int Id);
        public abstract void AddSkillUser(string name, string type, int Id);
        public abstract string CreateUser(string Email, string Login, string Password);
        public abstract string UpdateLogin(int Id, string Login);
    }
}
