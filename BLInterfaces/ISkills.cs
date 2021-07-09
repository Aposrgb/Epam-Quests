using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLInterfaces
{
    public abstract class ISkills
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public abstract List<string> GetListTypeSkills();
        public abstract string AddSkill(string name, string type);
        public abstract void DeleteSkill(string name, string type, int Id);
        public abstract List<ISkills> GetListSkills();
        
    }
}
