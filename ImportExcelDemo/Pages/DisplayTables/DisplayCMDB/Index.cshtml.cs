using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ImportExcelDemo.Models;

namespace ImportExcelDemo.Pages.DisplayTables.DisplayCMDB
{
    public class IndexModel : PageModel
    {
        private readonly ImportExcelDemo.Data.DemoContext _context;

        public IndexModel(ImportExcelDemo.Data.DemoContext context)
        {
            _context = context;
        }

        public IList<Cmdb> Cmdb { get;set; }

        public async Task OnGetAsync()
        {
            Cmdb = await _context.Cmdbs.ToListAsync();
        }
    }
}
