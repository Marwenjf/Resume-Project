using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Resume.Models
{
    public class Mail
    {
        [Key]
        public int MailId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public Document Attachment { get; set; }
        public virtual User To { get; set; }
        public User From { get; set; }
    }
}