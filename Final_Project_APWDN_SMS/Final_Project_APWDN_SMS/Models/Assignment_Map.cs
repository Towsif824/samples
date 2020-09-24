using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final_Project_APWDN_SMS.Models
{
    public class Assignment_Map
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "int")]
        [Required(ErrorMessage = "sectionid can not be empty")]
        public int assignmentid_t { get; set; }

        [Column(TypeName = "int")]
        [Required(ErrorMessage = "sectionid can not be empty")]
        public int assignmentid_s { get; set; }
    }
}