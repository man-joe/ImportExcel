
using ImportExcelDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportExcelDemo.Data
{
    public class DemoContext : DbContext
    {
        #region Constructor
        public DemoContext()
        {
/*            DemoContext(Base64FormattingOptions);
*/        }

        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        {
        }

        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Map Entity names to DB table names
            modelBuilder.Entity<Cmdb>().ToTable("CMDB");
        }
        #endregion

        #region Properties
        public DbSet<Cmdb> Cmdbs { get; set; }
        public DbSet<Sunflower> Sunflowers { get; set; }
        public DbSet<EPO> Epos { get; set; }
        public DbSet<AD_User> AD_Users { get; set; }
        public DbSet<AD_Computer> AD_Computers { get; set; }
        public DbSet<SCCM> Sccms { get; set; }

        #endregion
    }
}
