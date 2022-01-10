using Amphawan_001.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amphawan_001.Dbcontext_model
{
    public class CL_dbContext : DbContext
    {
        protected  override void OnConfiguring(DbContextOptionsBuilder builder) 
        {
            builder.UseSqlServer(@"Server=DESKTOP-4T5AOLG\SQLEXPRESS;Database=Amphawan_LMS_db;Trusted_Connection=True");
        }

        public DbSet<MD_Account> tb_account { get; set; }
        public DbSet<MD_catralog_book> tb_cattalog { get; set; }
        public DbSet<MD_customer> tb_customer { get; set; }
        public DbSet<MD_history> tb_his { get; set; }
        public DbSet<MD_search> tb_search { get; set; }

    }
}
