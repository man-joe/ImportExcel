using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImportExcelDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace ImportExcelDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SampleController : Controller
    {
        private readonly ImportExcelDemo.Data.DemoContext _context;

        public SampleController(ImportExcelDemo.Data.DemoContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [ActionName("GetCMDB")]
        public async Task<IActionResult> GetCMDB()
        {
            return Json(new { data = await _context.Cmdbs.ToListAsync() });
        }
        [HttpDelete]
        [ActionName("DeleteCMDB")]
        public async Task<IActionResult> Delete(int? id)
        {
            var cmdbFromDb = await _context.Cmdbs.FirstOrDefaultAsync(u => u.CmdbID == id);
            if(cmdbFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _context.Cmdbs.Remove(cmdbFromDb);
            await _context.SaveChangesAsync();
            return Json(new { success = true, Message = "Deletion of " + cmdbFromDb.CDTag + " was successful" });
        }


        [HttpGet]
        [ActionName("GetSun")]
        public async Task<IActionResult> GetSun()
        {
            return Json(new { data = await _context.Sunflowers.ToListAsync() });
        }

        [HttpGet]
        [ActionName("GetEPO")]
        public async Task<IActionResult> GetEPO()
        {
            return Json(new { data = await _context.Epos.ToListAsync() });
        }

        [HttpGet]
        [ActionName("GetSCCM")]
        public async Task<IActionResult> GetSCCM()
        {
            return Json(new { data = await _context.Sccms.ToListAsync() });
        }

        [HttpGet]
        [ActionName("GetAD_Computer")]
        public async Task<IActionResult> GetADComputer()
        {
            return Json(new { data = await _context.AD_Computers.ToListAsync() });
        }

        [HttpGet]
        [ActionName("GetAD_User")]
        public async Task<IActionResult> GetADUser()
        {
            return Json(new { data = await _context.AD_Users.ToListAsync() });
        }

        [HttpGet]
        [ActionName("GetADUser_CMDB")]
        public IActionResult GetADUser_CMDB()
        {
            var Cd_User = from u in _context.AD_Users
                          join d in _context.Cmdbs on u.UserName equals d.AdUser
                          orderby d.AdUser
                          select new
                          {
                              u.ADUserId,
                              u.ProgramOffice,
                              u.CACExemptionReason,
                              u.SmartCardRequired,
                              u.UserEmailAddress,
                              u.EmployeeType,
                              u.SAMAccountName,
                              u.Description,
                              u.UserPrincipalName,
                              u.AccountDisabled,
                              u.PasswordDoesNotExpire,
                              u.PasswordCannotChange,
                              u.PasswordExpired,
                              u.AccountLockedOut,
                              u.CACExtendedInfo,
                              u.UAC,
                              u.UserName,
                              u.DN,
                              u.Created,
                              u.Changed,
                              d.CmdbID,
                              d.CDTag,
                              d.Org,
                              d.HostName,
                              d.Location,
                              d.Floor,
                              d.Room,
                              d.IpAddress,
                              d.SubnetMask,
                              d.MacAddress,
                              d.Manufacturer,
                              d.Model,
                              d.SerialNumber,
                              d.OperatingSystem,
                              d.AdUser,
                              d.SunflowerUser,
                              d.Status,
                              d.ClassType,
                              d.AcquisitionDate,
                              d.WarrantyEndDate,
                              d.Custodian,
                              d.Comments,
                              d.InventoriedBy,
                              d.InventoryDate,
                              d.LastScan,
                              d.ModifiedBy,
                              d.Modified
                          };
            return Json(new { data = Cd_User.ToList() });
        }

        [HttpGet]
        [ActionName("GetADComputer_CMDB")]
        public IActionResult GetADComputer_CMDB()
        {
            var Cd_User = from c in _context.AD_Computers
                          join d in _context.Cmdbs on c.ADComputerName equals d.HostName
                          orderby d.AdUser
                          select new
                          {
                              c.ADComputerId,
                              c.ADComputerName,
                              c.ProgramOffice,
                              c.OSType,
                              c.OSVersion,
                              c.ServicePack,
                              c.Created,
                              c.Changed,
                              c.UAC,
                              c.AccountDisabled,
                              c.SmartCardRequired,
                              c.Description,
                              c.DN,
                              d.CmdbID,
                              d.CDTag,
                              d.Org,
                              d.HostName,
                              d.Location,
                              d.Floor,
                              d.Room,
                              d.IpAddress,
                              d.SubnetMask,
                              d.MacAddress,
                              d.Manufacturer,
                              d.Model,
                              d.SerialNumber,
                              d.OperatingSystem,
                              d.AdUser,
                              d.SunflowerUser,
                              d.Status,
                              d.ClassType,
                              d.AcquisitionDate,
                              d.WarrantyEndDate,
                              d.Custodian,
                              d.Comments,
                              d.InventoriedBy,
                              d.InventoryDate,
                              d.LastScan,
                              d.ModifiedBy,
                              d.Modified
                          };
            return Json(new { data = Cd_User.ToList() });
        }

        [HttpGet]
        [ActionName("GetAD_CMDB")]
        public IActionResult GetAD_CMDB()
        {

            var queryCD = from d in _context.Cmdbs
                          join u in _context.AD_Users on d.AdUser equals u.UserName
                          join c in _context.AD_Computers on d.HostName equals c.ADComputerName
                          orderby d.AdUser
                          select new
                          {
                              u.ADUserId,
                              u.ProgramOffice,
                              u.CACExemptionReason,
                              u.SmartCardRequired,
                              u.UserEmailAddress,
                              u.EmployeeType,
                              u.SAMAccountName,
                              u.Description,
                              u.UserPrincipalName,
                              u.AccountDisabled,
                              u.PasswordDoesNotExpire,
                              u.PasswordCannotChange,
                              u.PasswordExpired,
                              u.AccountLockedOut,
                              u.CACExtendedInfo,
                              u.UAC,
                              u.UserName,
                              u.DN,
                              u.Created,
                              u.Changed,
                              c.ADComputerId,
                              c.ADComputerName,
                              ComputerProgramOffice = c.ProgramOffice,
                              c.OSType,
                              c.OSVersion,
                              c.ServicePack,
                              ComputerCreated = c.Created,
                              ComputerChanged = c.Changed,
                              ComputerUAC = c.UAC,
                              ComputerAccount = c.AccountDisabled,
                              ComputerCard = c.SmartCardRequired,
                              ComputerDescription = c.Description,
                              ComputerDN = c.DN,
                              d.CmdbID,
                              d.CDTag,
                              d.Org,
                              d.HostName,
                              d.Location,
                              d.Floor,
                              d.Room,
                              d.IpAddress,
                              d.SubnetMask,
                              d.MacAddress,
                              d.Manufacturer,
                              d.Model,
                              d.SerialNumber,
                              d.OperatingSystem,
                              d.AdUser,
                              d.SunflowerUser,
                              d.Status,
                              d.ClassType,
                              d.AcquisitionDate,
                              d.WarrantyEndDate,
                              d.Custodian,
                              d.Comments,
                              d.InventoriedBy,
                              d.InventoryDate,
                              d.LastScan,
                              d.ModifiedBy,
                              d.Modified
                          };
            return Json(new { data = queryCD.ToList() });
        }

        [HttpGet]
        [ActionName("GetCMDB_Sunflower")]
        public IActionResult GetCMDB_Sunflower()
        {
            var Cd_Sunflower = from s in _context.Sunflowers
                          join d in _context.Cmdbs on s.BarcodeNum equals d.CDTag
                          orderby d.AdUser
                          select new
                          {
                              s.SunID,
                              s.BarcodeNum,
                              s.Status,
                              s.OfficialName,
                              s.Manufacturer,
                              s.Model,
                              s.ModelName,
                              s.SerialNumber,
                              s.AssetValue,
                              s.EffectiveDate,
                              s.CustArea,
                              s.BureauOrRegion,
                              s.PropertyContact,
                              s.CurrentUser,
                              s.FedSupplyGroup,
                              s.UtilizationCode,
                              s.AssetCondition,
                              s.ConditionDescription,
                              s.PhysicalInventoryDate,
                              s.AcquisitionDate,
                              s.ResponsibilityDate,
                              s.Site,
                              s.Stlv1,
                              s.Stlv2,
                              s.Stlv3,
                              s.MailStop,
                              s.Gps1,
                              s.Gps2,
                              s.Gps3,
                              s.ResolutionDate,
                              s.Resolution,
                              s.FinalEvent,
                              s.Datetime,
                              s.FinalEventUserDefinedLabel01,
                              s.FinalEventUserField01,
                              d.CmdbID,
                              d.CDTag,
                              d.Org,
                              d.HostName,
                              d.Location,
                              d.Floor,
                              d.Room,
                              d.IpAddress,
                              d.SubnetMask,
                              d.MacAddress,
                              CMDB_Manufacturer = d.Manufacturer,
                              CMDB_Model = d.Model,
                              CMDB_SerialNumber = d.SerialNumber,
                              d.OperatingSystem,
                              d.AdUser,
                              d.SunflowerUser,
                              CMDB_Status = d.Status,
                              d.ClassType,
                              CMDB_AcquisitionDate = d.AcquisitionDate,
                              d.WarrantyEndDate,
                              d.Custodian,
                              d.Comments,
                              d.InventoriedBy,
                              d.InventoryDate,
                              d.LastScan,
                              d.ModifiedBy,
                              d.Modified
                          };
            return Json(new { data = Cd_Sunflower.ToList() });
        }

        [HttpGet]
        [ActionName("GetCMDB_EPO")]
        public IActionResult GetCMDB_EPO()
        {
            var Cd_Sunflower = from e in _context.Epos
                               join d in _context.Cmdbs on e.SystemName equals d.HostName
                               orderby d.AdUser
                               select new
                               {
                                   e.EpoID,
                                   e.SystemName,
                                   e.ManagedState,
                                   e.Tags,
                                   e.IpAddress,
                                   e.UserName,
                                   d.CmdbID,
                                   d.CDTag,
                                   d.Org,
                                   d.HostName,
                                   d.Location,
                                   d.Floor,
                                   d.Room,
                                   CMDB_IP_Address = d.IpAddress,
                                   d.SubnetMask,
                                   d.MacAddress,
                                   CMDB_Manufacturer = d.Manufacturer,
                                   CMDB_Model = d.Model,
                                   CMDB_SerialNumber = d.SerialNumber,
                                   d.OperatingSystem,
                                   d.AdUser,
                                   d.SunflowerUser,
                                   CMDB_Status = d.Status,
                                   d.ClassType,
                                   CMDB_AcquisitionDate = d.AcquisitionDate,
                                   d.WarrantyEndDate,
                                   d.Custodian,
                                   d.Comments,
                                   d.InventoriedBy,
                                   d.InventoryDate,
                                   d.LastScan,
                                   d.ModifiedBy,
                                   d.Modified
                               };
            return Json(new { data = Cd_Sunflower.ToList() });
        }
    }
}

