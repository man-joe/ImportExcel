using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImportExcelDemo.Data;
using ImportExcelDemo.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImportExcelDemo.Pages.RazorJSON
{
    public class GetJSONModel : PageModel
    {
        [Obsolete]
        private IHostingEnvironment _environment;
        private readonly ImportExcelDemo.Data.DemoContext _context;

        [Obsolete]
        public GetJSONModel(IHostingEnvironment environment, DemoContext context)
        {
            _environment = environment;
            _context = context;
        }

        public JsonResult OnGet()
        {
            /*List<Cmdb> lstCmdbs = _context.Cmdbs.ToList();
            return new JsonResult(lstCmdbs);*/

            List<Sunflower> lst = _context.Sunflowers.ToList();
            return new JsonResult(lst);
        }
    }
}