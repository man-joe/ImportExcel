using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ImportExcelDemo.Data;
using ImportExcelDemo.Models;

namespace ImportExcelDemo.Pages.DisplayCMDB
{
    public class CreateModel : PageModel
    {
        private readonly ImportExcelDemo.Data.DemoContext _context;

        public CreateModel(ImportExcelDemo.Data.DemoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Cmdb Cmdb { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cmdbs.Add(Cmdb);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
