using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class FirstSergeant
    {
        [Key]
        public int FirstSergeantID { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Social Security Number")]
        public int SocialSecurityNumber { get; set; }

        [DisplayName("Rank/Pay Grade")]
        public string Rank { get; set; }


    }
}