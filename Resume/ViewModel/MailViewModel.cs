using Resume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resume.ViewModel
{
    public class MailViewModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public Document Attachment { get; set; }
        public int SelectedValue { get; set; }
        public virtual ICollection<User> users { get; set; }
    }
}