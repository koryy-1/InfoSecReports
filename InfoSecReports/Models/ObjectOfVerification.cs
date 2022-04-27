using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InfoSecReports.Models
{
    public class ObjectOfVerification
    {
        [Required]
        [Key]
        public string Name { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DateOfStart { get; set; }
        [Required]
        public DateTime DateOfEnd { get; set; }
        [Required]
        public string Notes { get; set; }
        public string Owner { get; set; }
        public ICollection<Achievement> Achievement { get; set; }
        public ICollection<WorkingGroup> WorkingGroup { get; set; }
        public ICollection<ScriptOfObject> ScriptOfObject { get; set; }
        public ICollection<FlawOfObject> FlawOfObjects { get; set; }
        public ICollection<EventOfObject> EventOfObjects { get; set; }
    }
}
