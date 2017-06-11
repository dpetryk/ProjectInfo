using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectInfo.Models
{
    public class NextStep
    {

        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }

        [Display(Name = "Update")]
        [DataType(DataType.DateTime)]
        public DateTime Update { get; set; }

        public virtual Project SelectedProject { get; set; }

    }
}