using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImportExcelDemo.Models
{
    public class Cmdb
    {
        #region Constructor
        public Cmdb()
        {
        }
        #endregion

        #region Instance Variables
        [Key]
        [Required]
        public int CmdbID { get; set; }
        [StringLength(50)]
        public string CDTag { get; set; }
        [StringLength(50)]
        public string Org { get; set; }
        [StringLength(50)]
        public string HostName { get; set; }
        [StringLength(50)]
        public string Location { get; set; }
        [StringLength(50)]
        public string Floor { get; set; }
        [StringLength(50)]
        public string Room { get; set; }
        [StringLength(50)]
        public string IpAddress { get; set; }
        [StringLength(50)]
        public string SubnetMask { get; set; }
        [StringLength(50)]
        public string MacAddress { get; set; }
        [StringLength(50)]
        public string Manufacturer { get; set; }
        [StringLength(50)]
        public string Model { get; set; }
        [StringLength(50)]
        public string SerialNumber { get; set; }
        [StringLength(50)]
        public string OperatingSystem { get; set; }
        [StringLength(50)]
        public string AdUser { get; set; }
        [StringLength(50)]
        public string SunflowerUser { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        [StringLength(50)]
        public string ClassType { get; set; }
        public DateTime? AcquisitionDate { get; set; }
        public DateTime? WarrentyEndDate { get; set; }
        [StringLength(50)]
        public string Custodian { get; set; }
        [StringLength(50)]
        public string Comments { get; set; }
        [StringLength(50)]
        public string InventoriedBy { get; set; }
        public DateTime? InventoryDate { get; set; }
        public DateTime? LastScan { get; set; }
        [StringLength(50)]
        public string ModifiedBy { get; set; }
        public DateTime? Modified { get; set; }
        #endregion
    }
}
