
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImportExcelDemo.Models
{
    
    public class ECMO
    {
        #region Constructor
        public ECMO()
        {

        }
        #endregion

        #region Instance Variables
        [Key]
        [Required]
        public int EcmoID { get; set; }
        [StringLength(50)]
        public string ComputerName { get; set; }
        [StringLength(200)]
        public string NoaaAssetTag { get; set; }
        [StringLength(500)]
        public string UserName { get; set; }
        [StringLength(200)]
        public string NoaaSerialNumber { get; set; }
        [StringLength(100)]
        public string IpAddress { get; set; }
        [StringLength(200)]
        public string IpAndMacAddress { get; set; }
        [StringLength(100)]
        public string OS { get; set; }
        [StringLength(50)]
        public string Cpu { get; set; }        
        public DateTime? LastReportTime { get; set; }        
        public DateTime? Bios { get; set; }
        #endregion
    }
}
