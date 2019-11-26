using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Resume.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<Mail> Sended { get; set; }
        public virtual ICollection<Mail> Received { get; set; }
    }
}