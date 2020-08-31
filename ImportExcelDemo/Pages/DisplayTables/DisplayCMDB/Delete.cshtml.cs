using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ImportExcelDemo.Models;

namespace ImportExcelDemo.Pages.DisplayTables.DisplayCMDB
{
    public class DeleteModel : PageModel
    {
        private readonly ImportExcelDemo.Data.DemoContext _context;

        public DeleteModel(ImportExcelDemo.Data.DemoContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cmdb = await _context.Cmdbs.FindAsync(id);

            if (Cmdb != null)
            {
                _context.Cmdbs.Remove(Cmdb);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
