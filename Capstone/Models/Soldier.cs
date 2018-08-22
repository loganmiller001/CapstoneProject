using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Soldier
    {
        [Key]
        public int SoldierId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Rank/Pay Grade")]
        public string Rank { get; set; }

        [DisplayName("Social Security Number")]
        public int? SocialSecurityNumber { get; set; }

        [DisplayName("DA-31")]
        public string LeaveForm{get; set;}

        [DisplayName("DA-31 Submission")]
        public bool LeaveFormSubmission { get; set; }

        [DisplayName("Leave and Earning Statement")]
        public string LES { get; set; }

        [DisplayName("LES Submission")]
        public bool LESSubmission { get; set; }

        [DisplayName("Assigned Unit")]
        public string UnitNumber { get; set; }

        [DisplayName("Division")]
        public string Division { get; set; }

        [DisplayName("First Line Supervisor")]
        public string Leadership { get; set; }

        [DisplayName("Travel Information")]
        public bool TravelInfo { get; set; }

        public string TravelFileName { get; set; }

        [DisplayName("Leave Status")]
        public bool PacketStatus { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<File> Files { get; set; }

        [DisplayName("Start Date")]
        public DateTime? StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }

        public double StartPoint { get; set; }

        public double EndPoint { get; set; }

    }
    
}