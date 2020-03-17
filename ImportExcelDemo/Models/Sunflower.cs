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
        public string Status { get; set; }
        [StringLength(50)]
        public string OfficialName { get; set; }
        [StringLength(50)]
        public string Manufacturer { get; set; }
        [StringLength(50)]
        public string Model { get; set; }
        [StringLength(50)]
        public string ModelName { get; set; }
        [StringLength(50)]
        public string SerialNumber { get; set; }
        [StringLength(59)]
        public string AssetValue { get; set; }
        public DateTime EffectiveDate { get; set; }
        [StringLength(50)]
        public string CustArea { get; set; }
        [StringLength(50)]
        public string BureauOrRegion { get; set; }
        [StringLength(50)]
        public string PropertyContact { get; set; }
        [StringLength(50)]
        public string CurrentUser { get; set; }
        [StringLength(50)]
        public string FedSupplyGroup { get; set; }
        [StringLength(50)]
        public string UtilizationCode { get; set; }
        [StringLength(50)]
        public string AssetCondition { get; set; }
        #endregion
    }
}
