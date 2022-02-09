using LMS_002.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LMS_002.DbContext_db
{
    public class Dbcon_wan : DbContext
    {
        public Dbcon_wan() : base("amphawacontect")
        {
        }
        public DbSet<MD_Account> tb_account { get; set; }
        public DbSet<MD_catralog_book> tb_cattalog { get; set; }
        public DbSet<MD_customer> tb_customer { get; set; }
        public DbSet<MD_history> tb_his { get; set; }
        public DbSet<MD_search> tb_search { get; set; }
        public DbSet<MD_statusbook> tb_statusbooks { get; set; }
        public DbSet<MD_status_user> tb_statusbooks_type { get; set; }
        public DbSet<MD_type_book> tb_books_type { get; set; }
        public DbSet<MD_Dictionary> tb_dictionnary { get; set; }
    }
}