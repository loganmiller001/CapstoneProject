﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Email
    {
        [Required, Display(Name ="Name")]
        public string FromName { get; set; }

        [Required, Display(Name ="Email Address"), EmailAddress]
        public string FromEmail { get; set; }

        [Required]
        public string Message { get; set; }

    }
}