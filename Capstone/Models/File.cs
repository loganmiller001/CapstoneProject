using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebGrease.Activities;

namespace Capstone.Models
{
    public class File
    {
        [Key]
        public int FileID { get; set; }

        [DisplayName("File Name")]
        [StringLength(255)]
        public string FileName { get; set; }

        [DisplayName("Content Type")]
        [StringLength(100)]
        public string ContentType { get; set; }

        public byte[] Content { get; set; }

        [DisplayName("File Type")]
        public FieldType FileType { get; set; }

        [ForeignKey("SoldierId")]
        public int SoliderId { get; set; }
        public virtual Soldier Soldier { get; set; }
    }
}