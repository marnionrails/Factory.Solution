using System.Collections.Generic;

namespace Factory.Models
{
    public class Engineer
    {
         public Engineer()
        {
        this.JoinEntities = new HashSet<EngineerMachine>();
        }        
 
        public int EngineerId { get; set; }
        public string Name { get; set; }

        public List<Machine> Machines = new List<Machine>();
        public virtual ICollection<EngineerMachine> JoinEntities { get; set; }
    }
}