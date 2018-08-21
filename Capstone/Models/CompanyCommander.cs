using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class CompanyCommander
    {
        [Key]
        public int CommanderId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Rank/Pay Grade")]
        public string Rank { get; set; }

        [DisplayName("Social Security Number")]
        public int? SocialSecurityNumber { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [DisplayName("Start Date")]
        public DateTime? StartLeave { get; set; }

        [DisplayName("End Date")]
        public DateTime? EndLeave { get; set; }
    }
}