using System.Collections.Generic;

namespace Factory.Models
{
    public class Machine
    {
         public Machine()
        {
        this.JoinEntities = new HashSet<EngineerMachine>();
        }        
 
        public int MachineId { get; set; }
        public string Name { get; set; }

        public List<Engineer> Engineers = new List<Engineer>();
        public virtual ICollection<EngineerMachine> JoinEntities { get; set; }
    }
}