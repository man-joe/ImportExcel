using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ImportExcelDemo.Models;

namespace ImportExcelDemo.Pages.DisplayTables.DisplayCMDB
{
    public class EditModel : PageModel
    {
        private readonly ImportExcelDemo.Data.DemoContext _context;

        public EditModel(ImportExcelDemo.Data.DemoContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cmdb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CmdbExists(Cmdb.CmdbID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CmdbExists(int id)
        {
            return _context.Cmdbs.Any(e => e.CmdbID == id);
        }
    }
}
