using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImportExcelDemo.Pages.ImportExcel
{
    public class IndexModel : PageModel
    {
        //
        [Obsolete]
        private IHostingEnvironment _environment;

        [Obsolete]
        public IndexModel(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        [ViewData]
        public string Message { get; set; }

        [BindProperty]
        public IFormFile Upload { get; set; }

        [Obsolete]
        public async Task OnPostAsync()
        {
            var file = Path.Combine(_environment.ContentRootPath, "uploads", Upload.FileName);

            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Upload.CopyToAsync(fileStream);
            }
        }

    }
}