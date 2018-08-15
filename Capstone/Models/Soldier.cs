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

        [DisplayName("Leave and Earning Statement")]
        public string LES { get; set; }

        [DisplayName("Assigned Unit")]
        public string UnitNumber { get; set; }

        [DisplayName("Division")]
        public string Division { get; set; }

        [DisplayName("First Line Supervisor")]
        public string Leadership { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
    
}