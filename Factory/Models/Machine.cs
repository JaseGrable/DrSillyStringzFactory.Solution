using System.Collections.Generic;
using System.ComponentModel.DataAnnotation;

namespace Factory.Models
{
    public class Machine
    {
        public int MachineId { get; set; }

        [Required(ErrorMessage = "You must enter the name of the Machine")]
        public string MachineName { get; set; }

        [Required(ErrorMessage = "You cannot leave the Machine's details blank.")]
        public string MachineDescription { get; set; }
        public List<EngineerMachine> JoinEntities { get; }
    }
}