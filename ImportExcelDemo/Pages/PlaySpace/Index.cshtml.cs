using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImportExcelDemo.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ImportExcelDemo.Pages.PlaySpace
{
    public class IndexModel : PageModel
    {

        private readonly ImportExcelDemo.Data.DemoContext _context;
        [Obsolete]
        private IHostingEnvironment _environment;

        [Obsolete]
        public IndexModel(IHostingEnvironment environment, ImportExcelDemo.Data.DemoContext context)
        {
            _environment = environment;
            _context = context;
        }

        public IList<Cmdb> Cmdb { get; set; }
        /*public async Task<JsonResult> OnGetListAsync()
        {
            Cmdb = await _context.Cmdbs
                .AsNoTracking()
                .ToListAsync();

            return new JsonResult(Cmdb);
        }
*/
        public JsonResult OnGetList()
        {
            Cmdb = _context.Cmdbs
                .AsNoTracking()
                .ToList();

            return new JsonResult(Cmdb);
        }
    }
}