using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImportExcelDemo.Models
{
    public class SCCM
    {
        #region Constructor
        public SCCM()
        {
        }
        #endregion

        #region Instance Variables
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int? SccmId { get; set; }
        [StringLength(50)]
        [Name("Details_Table0_ComputerName")]
        public string ComputerName { get; set; }
        [StringLength(50)]
        [Name("Details_Table0_DomainWorkgroup")]
        public string DomainWorkGroup { get; set; }
        [StringLength(50)]
        [Name("Details_Table0_SMSSiteName")]
        public string SiteName { get; set; }
        [StringLength(50)]
        [Name("Details_Table0_TopConsoleUser")]
        public string TopConsoleUser { get; set; }
        [StringLength(50)]
        [Name("Details_Table0_OperatingSystem")]
        public string OperatingSystem { get; set; }
        [StringLength(50)]
        [Name("Details_Table0_SerialNumber")]
        public string SerialNumber { get; set; }
        [StringLength(50)]
        [Name("Details_Table0_AssetTag")]
        public string AssetTag { get; set; }
        [StringLength(50)]
        [Name("Details_Table0_Manufacturer")]
        public string Manufacturer { get; set; }
        [Name("Release_Date")]
        public DateTime? ReleaseDate { get; set; }
        [StringLength(50)]
        [Name("SMBIOS_Version")]
        public string BiosVersion { get; set; }
        [StringLength(50)]
        [Name("Details_Table0_Model")]
        public string Model { get; set; }
        [Name("Details_Table0_MemoryKBytes")]
        public int? MemoryKBytes { get; set; }
        [Name("Details_Table0_ProcessorGHz")]
        public int? ProcessorGhz { get; set; }
        [Name("Details_Table0_DiskSpaceMB")]
        public int? DiskSpaceMB { get; set; }
        [Name("Details_Table0_FreeDiskSpaceMB")]
        public int? FreeDiskSpaceMB { get; set; }        
        #endregion
    }
}
