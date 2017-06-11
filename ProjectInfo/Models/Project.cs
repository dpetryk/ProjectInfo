using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectInfo.Models
{
    public class Project
    {

        [Key]
        public int Id { get; set; }
            
        [Required(ErrorMessage = "Project name is required")]
        [StringLength(50, ErrorMessage = "Project name requires at lesat {2} characters", MinimumLength = 3)]
        [Display(Name = "Project")]
        public string Name { get; set; }


        public int TeamId { get; set; }

        [ForeignKey("TeamId")]
      //  [Required(ErrorMessage = "Project Team is required")]
      //  [StringLength(25, ErrorMessage = "Project name requires at lesat {2} characters", MinimumLength = 3)]
        public virtual Team SelectedTeam { get; set; }

        [Display(Name = "Responsible")]
        public int ProjectManagerId { get; set; }

        [ForeignKey("ProjectManagerId")]
        //[Required(ErrorMessage = "Person responsible is required")]
        //[StringLength(25, ErrorMessage = "Project name requires at lesat {2} characters", MinimumLength = 3)]
        [Display(Name = "Responsible")]
        public virtual ProjectManager SelectedPM { get; set; }

        [Display(Name = "Start date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Delivery date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Required(ErrorMessage = "Delivery date is required")]
        public DateTime DeliveryDate { get; set; }

        [Display(Name = "Project status")]
        [StringLength(20, ErrorMessage = "Choose project status")]
        [Required(ErrorMessage = "Choose project status")]
        public string Status { get; set; }

        [Display(Name = "Priority")]
        [StringLength(10, ErrorMessage = "Choose project priority")]
        [Required(ErrorMessage = "Choose project priority")]
        public string Priority { get; set; }

        [Display(Name = "Effort")]
        [StringLength(30, ErrorMessage = "Choose project effort")]
        [Required(ErrorMessage = "Choose project effort")]
        public string Effort { get; set; }


        [Display(Name = "Delivery Status")]
        [StringLength(10, ErrorMessage = "Choose delivery status")]
        [Required(ErrorMessage = "Choose delivery status")]
        public string DeliveryStatus { get; set; }

        [Display(Name = "Overview")]
        [DataType(DataType.MultilineText)]
        [StringLength(200, ErrorMessage = "Overview is max 200 characters")]
        [Required(ErrorMessage = "Write project overview")]
        public string Overview { get; set; }

        [Display(Name = "Risks")]
        [DataType(DataType.MultilineText)]
        [StringLength(200, ErrorMessage = "Risks are max 200 characters")]
        [Required(ErrorMessage = "Identify project risks")]
        public string Risks { get; set; }

        [Display(Name = "Achievements")]
        [StringLength(200, ErrorMessage = "Achievements are max 200 characters")]
        public virtual List<Achievement> Achievements { get; set; }


        //[Display(Name = "Next Steps")]
        //[StringLength(200, ErrorMessage = "Next Steps are max 200 characters")]
        //public virtual ICollection<NextStep> NextSteps { get; set; }


    }
}