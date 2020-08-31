using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ImportExcelDemo.Models;

namespace ImportExcelDemo.Pages.DisplayTables.DisplayCMDB
{
    public class DetailsModel : PageModel
    {
        private readonly ImportExcelDemo.Data.DemoContext _context;

        public DetailsModel(ImportExcelDemo.Data.DemoContext context)
        {
            _context = context;
        }

        public Cmdb Cmdb { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cmdb = await _context.Cmdbs.FirstOrDefaultAsync(m => m.CmdbID == id);

            if (Cmdb == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
