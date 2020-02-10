using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;


namespace ImportExcelDemo.Pages.ImportExcel
{
    public class IndexModel : PageModel
    {
        //IHostingEnvironment has been replaced with IWebHosting but is still used
        //when you don't need the WebRootPath or WebRootFileProvider location
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

            if(Upload != null)
            {
                
                try
                {
                    string fileExt = Path.GetExtension(Upload.FileName);

                    //Validate file Type
                    if(fileExt != ".xls" && fileExt != ".xlsx")
                    {
                        Message = "Please select an excel with .xls or .xlsx extension";
                    }

                    string folderPath = Path.Combine(_environment.ContentRootPath, "uploads");
                        
                        //Server.MapPath("~/uploads/");
                    //Check for if Directory exists
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    //Save file to folder
                    var filePath = Path.Combine(folderPath,
                                                Path.GetFileName(Upload.FileName));
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await Upload.CopyToAsync(fileStream);
                    }
                    

                }
                catch(Exception ex)
                {
                    Message = ex.Message;
                }


                ///
             /*   var file = Path.Combine(_environment.ContentRootPath, "uploads", Upload.FileName);

                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await Upload.CopyToAsync(fileStream);
                }*/

            }
            else
            {
                Message = "Please select a File to upload.";
            }

            //No need for return View() as a Razor page is considered View-Model with 
            //Controller features
        }

    }
}