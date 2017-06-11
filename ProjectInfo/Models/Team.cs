using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectInfo.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        [Display(Name = "Team")]
        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}