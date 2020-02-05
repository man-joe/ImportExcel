using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImportExcelDemo.Models
{
    public class Cmdb
    {
        public int CmdbID { get; set; }
        [StringLength(50)]
        public string CDTag { get; set; }
        [StringLength(50)]
        public string AdUser{ get; set; }
        [StringLength(50)]
        public string Location { get; set; }

    }
}
