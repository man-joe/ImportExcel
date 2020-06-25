using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ImportExcelDemo
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public string TimeNow { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            TimeNow = DateTime.Now.ToLongTimeString();
        }

        public IActionResult OnPostSubmit()
        {
            int dataSet = Convert.ToInt32(Request.Form["DataSets"]);
            if (dataSet == 0)
            {
                Response.Redirect("/DisplayADComputer");
            }
            else if (dataSet == 1)
            {
                Response.Redirect("/DisplayADUser");
            }
            else if (dataSet == 2)
            {
                Response.Redirect("/DisplayCMDB");
            }
            else if (dataSet == 3)
            {
                Response.Redirect("/DisplaySun");
            } 
            else if (dataSet == 4)
            {
                Response.Redirect("/DisplayEPO");
            } 
            else if (dataSet == 5)
            {
                Response.Redirect("/DisplayADUser_CMDB");
            } 
            else if (dataSet == 6)
            {
                Response.Redirect("/DisplayADComputer_CMDB");
            } 
            else if (dataSet == 7)
            {
                Response.Redirect("/DisplayAD_CMDB");
            }
            return Page();
        }
    }

}