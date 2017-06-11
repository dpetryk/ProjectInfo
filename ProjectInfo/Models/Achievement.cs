using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectInfo.Models
{
    public class Achievement
    {

        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Comment")]
        public string Name { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Update { get; set; }

        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project SelectedProject { get; set; }

    }
}