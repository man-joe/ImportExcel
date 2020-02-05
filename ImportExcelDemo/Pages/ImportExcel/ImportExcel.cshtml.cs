using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ImportExcelDemo.Data;
using ImportExcelDemo.Models;

namespace ImportExcelDemo
{
    public class ImportExcelModel : PageModel
    {
        private readonly ImportExcelDemo.Data.DemoContext _context;

        public ImportExcelModel(ImportExcelDemo.Data.DemoContext context)
        {
            _context = context;
        }

        public IList<Cmdb> Cmdb { get;set; }

        [ViewData]
        public string Message { get; set; }
        
        public async Task OnGetAsync()
        {

            Message = "Data Imported Successfully.";

            Cmdb = await _context.Cmdbs.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(HttpPostedFileBase postedFile)
        {
            Cmdb = await _context.Cmdbs.ToListAsync();

            return RedirectToPage("./Index");
        }

    }
}
