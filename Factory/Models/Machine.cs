using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
    public class Machine
    {

        public int MachineId { get; set; }
        [Display(Name = "Machine Name: ")]
        [Required(ErrorMessage = "The name field can't be blank.")]
        public string MachineName { get; set; }
        [Display(Name = "Manufacture Date: ")]
        [Required(ErrorMessage = "The date can't be blank.")]
        public string ManufactureDate { get; set; }
        public int EngineerId { get; set; }
        public List<EngineerMachine> JoinEntities { get; }

    }
}