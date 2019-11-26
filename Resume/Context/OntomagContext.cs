using Resume.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Resume.Context
{
    public class OntomagContext : DbContext
    {
        public OntomagContext() : base()
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Mail> Mails { get; set; }

        public System.Data.Entity.DbSet<Resume.ViewModel.MailViewModel> MailViewModels { get; set; }
    }
}