using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Resume.Models
{
    public class Document
    {
        [Key]
        public int DocmuentId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentUrl { get; set; }
        public User DocumentUser { get; set; }
        //public virtual ICollection<Mail> Mails { get; set; } 
    }
}