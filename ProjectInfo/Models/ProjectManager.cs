using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectInfo.Models
{
    public class ProjectManager
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        [Display(Name = "Project Manager")]
        public string Name { get; set; }

        [MaxLength(30)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string Email { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}