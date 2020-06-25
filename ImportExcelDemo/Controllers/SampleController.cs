﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetCMDB()
        {
            return Json(new { data = _context.Cmdbs.ToList() });
        }

        [HttpGet]
        [ActionName("GetSun")]
        public IActionResult GetSun()
        {
            return Json(new { data = _context.Sunflowers.ToList() });
        }

        [HttpGet]
        [ActionName("GetEPO")]
        public IActionResult GetEPO()
        {
            return Json(new { data = _context.Epos.ToList() });
        }

        [HttpGet]
        [ActionName("GetAD_Computer")]
        public IActionResult GetADComputer()
        {
            return Json(new { data = _context.AD_Computers.ToList() });
        }

        [HttpGet]
        [ActionName("GetAD_User")]
        public IActionResult GetADUser()
        {
            return Json(new { data = _context.AD_Users.ToList() });
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
    }
}