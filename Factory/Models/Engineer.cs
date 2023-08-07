using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
    public class Engineer
    {

        public int EngineerId { get; set; }
        [Display(Name = "Engineer Name: ")]
        [Required(ErrorMessage = "The name field can't be blank.")]
        public string EngineerName { get; set; }
        [Display(Name = "Job Title: ")]
        [Required(ErrorMessage = "The job title field can't be blank.")]
        public string JobTitle { get; set; }
        public int MachineId { get; set; }
        public List<EngineerMachine> JoinEntities { get; }
    }
}