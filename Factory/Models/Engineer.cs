using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
    public class Engineer
    {
        public int EngineerId { get; set; }
        [Required(ErrorMessage = "You must enter the name of the Engineer.")]
        public string EngineerName { get; set; }

        [Required(ErrorMessage = "You cannot leave the Engineer's details blank.")]
        public string EngineerDetails { get; set; }
        public List<EngineerMachine> JoinEntities { get; }
    }
}