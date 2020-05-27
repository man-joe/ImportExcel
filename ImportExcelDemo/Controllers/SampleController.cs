using System;
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
    }
}