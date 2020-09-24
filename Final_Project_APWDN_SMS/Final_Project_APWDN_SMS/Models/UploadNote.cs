using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final_Project_APWDN_SMS.Models
{
    public class UploadNote
    {
        [Key]
        public int uploadid { get; set; }

        [Column(TypeName = "varchar"), StringLength(100)]
        [Required(ErrorMessage = "directory can not be empty")]
        public string directory { get; set; }

        [Column(TypeName = "varchar"), StringLength(100)]
        [Required(ErrorMessage = "filename can not be empty")]
        public string filename { get; set; }

        [Column(TypeName = "datetime")]
        [Required(ErrorMessage = "datetime can not be empty")]
        public System.DateTime datetime { get; set; }

        [Column(TypeName = "int")]
        [Required(ErrorMessage = "sectionid can not be empty")]
        public int sectionid { get; set; }

        [Column(TypeName = "int")]
        [Required(ErrorMessage = "subjectid can not be empty")]
        public int subjectid { get; set; }
    }
}