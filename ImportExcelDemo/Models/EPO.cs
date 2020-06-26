using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImportExcelDemo.Models
{
  
    public class EPO
    {
        #region Constructor
        public EPO()
        {
        }
        #endregion

        #region Instance Variables
        [Key]
/*        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]*/
        [Required]
        public int? EpoID { get; set; }
        [StringLength(50)]
        [Name("System Name")]
        public string SystemName { get; set; }
        [StringLength(50)]
        [Name("Managed State")]
        public string ManagedState { get; set; }
        [StringLength(150)]
        [Name("Tags")]        
        public string Tags{ get; set; }
        [StringLength(50)]
        [Name("IP address")]
        public string IpAddress { get; set; }
        [StringLength(150)]
        [Name("User Name")]
        public string UserName { get; set; }
        
        // Issue: DateTime needs to be parsed correctly
        
        /*[Name("Last Communication")] //might not need since we're parsing each field individually
        public DateTime? LastCommunication { get; set; }*/


        /*[StringLength(50)]
        public string UniqueIdentifier { get; set; }*/
        #endregion
    }




}
