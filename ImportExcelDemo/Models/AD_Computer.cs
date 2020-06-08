using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImportExcelDemo.Models
{
    public class AD_Computer
    {
        #region Constructor
        public AD_Computer()
        {

        }
        #endregion

        #region Instance Variables
        [Key]
        [Required]
        [StringLength(200)]
        public string ADComputerName { get; set; }

        [StringLength(200)]
        public string ProgramOffice { get; set; }

        [StringLength(200)]
        public string OSType { get; set; }

        [StringLength(200)]
        public string OSVersion { get; set; }

        [StringLength(200)]
        public string ServicePack { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Changed { get; set; }

        public int UAC { get; set; }

        public bool AccountDisabled { get; set; }

        public bool SmartCardRequired { get; set; }

        public string Description { get; set; }

        public string DN { get; set; }

        public string Win7StatusExtendedinfo { get; set; }
        #endregion
    }
}
