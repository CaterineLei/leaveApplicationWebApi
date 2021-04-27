using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace LeaveApplication.Models
{
    public class LeaveApplicationForm
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public int ApplicantId { get; set; }
        [Required]
        public int ManagerId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }
        [Required]
        public int NumberOfDays { get; set; }
        [MaxLength(500)]
        public string Comments { get; set; }
    }
}