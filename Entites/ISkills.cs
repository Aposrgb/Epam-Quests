using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public interface ISkills
    {
        List<string> GetListTypeSkills();
        string AddSkill(string name, string type);
        void DeleteSkill(string name, string type, int Id);
        List<Skills> GetListSkills();
    }
}
