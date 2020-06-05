using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace ImportExcelDemo.Models
{
    public class AD_User
    {
        #region Constructor
        public AD_User()
        {
        }
        #endregion

        #region Instance Variables

        [Required]
        [Key]
        public int ADUserId { get; set; }

        [StringLength(200)]
        public string ProgramOffice { get; set; }

        [StringLength(200)]
        public string CACexemptionreason { get; set; }

        public bool SmartCardRequired { get; set; }

        [StringLength(200)]
        public string UserEmailAddress { get; set;}

        [StringLength(200)]
        public string EmployeeType { get; set; }

        [StringLength(200)]
        public string SAMAccountName { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [StringLength(200)]
        public string UserPrincipalName { get; set; }

        public bool AccountDisabled { get; set; }

        public bool PasswordDoesNotExpire { get; set; }

        public bool PasswordCannotChange { get; set; }

        public bool PasswordExpired { get; set; }

        public bool AccountLockedOut { get; set; }

        public string CACExtendedInfo { get; set; }

        public int UAC { get; set; }

        [StringLength(200)]
        public string UserName { get; set; }

        public string DN { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Changed { get; set; }

        #endregion
    }
}
