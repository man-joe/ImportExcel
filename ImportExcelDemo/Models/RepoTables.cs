using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImportExcelDemo.Models
{
    public class RepoTables
    {
        #region Constructor
        public RepoTables()
        {
        }
        #endregion

        #region Instance Variables
        [Key]
        public string UniqueIdentifier { get; set; }
        
        public Cmdb Cmdb { get; set; }
        public Sunflower Sunflower { get; set; }
        public AD_Computer Ad { get; set; }
        public EPO Epo { get; set; }
       /* public ECMO Ecmo { get; set; }
        public SCCM Sccm { get; set; }*/

        #endregion
    }
}
