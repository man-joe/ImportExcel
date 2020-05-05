using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImportExcelDemo.Models
{
    public class Sunflower
    {

        #region Constructor
        public Sunflower()
        {
        }
        #endregion


        #region Instance Variables
        [Key]
        [Required]
        public int SunID { get; set; }
        [StringLength(50)]
        public string BarcodeNum { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        [StringLength(50)]
        public string OfficialName { get; set; }
        [StringLength(50)]
        public string Manufacturer { get; set; }
        [StringLength(100)]
        public string Model { get; set; }
        [StringLength(100)]
        public string ModelName { get; set; }
        [StringLength(50)]
        public string SerialNumber { get; set; }
        [StringLength(59)]
        public string AssetValue { get; set; }
        public DateTime? EffectiveDate { get; set; }
        [StringLength(50)]
        public string CustArea { get; set; }
        [StringLength(50)]
        public string BureauOrRegion { get; set; }
        [StringLength(50)]
        public string PropertyContact { get; set; }
        [StringLength(50)]
        public string CurrentUser { get; set; }
        [StringLength(500)]
        public string FedSupplyGroup { get; set; }
        [StringLength(50)]
        public string UtilizationCode { get; set; }
        [StringLength(50)]
        public string AssetCondition { get; set; }
        [StringLength(50)]
        public string ConditionDescription { get; set; }
        public DateTime? PhysicalInventoryDate { get; set; }        
        public DateTime? AcquisitionDate { get; set; }
        public DateTime? ResponsibilityDate { get;set; }
        [StringLength(50)]
        public string Site { get; set; }
        [StringLength(50)]
        public string Stlv1 { get; set; }
        [StringLength(50)]
        public string Stlv2 { get; set; }
        [StringLength(50)]
        public string Stlv3 { get; set; }
        [StringLength(50)]
        public string MailStop { get; set; }
        [StringLength(50)]
        public string Gps1 { get; set; }
        [StringLength(50)]
        public string Gps2 { get; set; }
        [StringLength(50)]
        public string Gps3 { get; set; }
        public DateTime? ResolutionDate { get; set; }
        [StringLength(50)]
        public string Resolution { get; set; }
        [StringLength(50)]
        public string FinalEvent { get; set; }
        public DateTime? Datetime { get; set; }
        [StringLength(50)]
        public string FinalEventUserDefinedLabel01 { get; set; }
        [StringLength(50)]
        public string FinalEventUserField01 { get; set; }
        #endregion
    }
}
