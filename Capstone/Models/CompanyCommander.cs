using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class CompanyCommander
    {
        [Key]
        public int CommanderId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Rank { get; set; }

        public string SocialSecurityNumber { get; set; }
    }
}