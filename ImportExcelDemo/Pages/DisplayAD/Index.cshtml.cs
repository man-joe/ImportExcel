using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ImportExcelDemo.Data;
using ImportExcelDemo.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;

namespace ImportExcelDemo.Pages.DisplayAD
{
    public class IndexModel : PageModel
    {

        [Obsolete]
        private IHostingEnvironment _environment;

        private readonly ImportExcelDemo.Data.DemoContext _context;
        /*public List<> JoinDatas { get; set; }*/

        [ViewData]
        public bool FirstOptionChecked { get; set; }

        public bool OptionsSet { get; set; }

        public int DataSet { get; set; }

        public List<string> DataSetOptions { get; set; }

        [Obsolete]
        public IndexModel(IHostingEnvironment environment, DemoContext context)
        {
            _environment = environment;
            _context = context;
            FirstOptionChecked = false;
            OptionsSet = false;
            DataSetOptions = new List<string>();
        }



        [ViewData]
        public string StatusMessage { get; set; }
        [ViewData]
        public string NumMessage { get; set; }
        public IList<AD_User> AD_Users { get; set; }

        public IList<AD_Computer> AD_Computers { get; set; }

        
        /*public var joins { get; set; }*/
        public async Task OnGetAsync() 
        {
            AD_Users = await _context.AD_Users
                .AsNoTracking()
                .ToListAsync();

            AD_Computers = await _context.AD_Computers
                .AsNoTracking()
                .ToListAsync();
        }
        public IActionResult OnPostSubmit()
        {
            FirstOptionChecked = true;
            DataSet = Convert.ToInt32(Request.Form["DataSets"]);
            Response.Cookies.Append("DataSet", DataSet.ToString());
            return Page();
        }
        public async Task OnPostDisplay()
        {
            AD_Users = await _context.AD_Users
               .AsNoTracking()
               .ToListAsync();

            AD_Computers = await _context.AD_Computers
                .AsNoTracking()
                .ToListAsync();

            DataSet = Convert.ToInt32(Request.Cookies["DataSet"]);

            FirstOptionChecked = true;
            OptionsSet = true;

            foreach(var item in Request.Form.Keys)
            {
                if (item.Contains("DataSetsOptions"))
                {
                    DataSetOptions.Add(item);
                }
            }

            if (DataSet == 0)
            {
                NumMessage = "The total number of Users is " + AD_Users.Count;
                StatusMessage = "Now displaying AD Users";
            }
            else if (DataSet == 1)
            {
                NumMessage = "The total number of Computers is " + AD_Computers.Count;
                StatusMessage = "Now displaying AD Computers";
            }
        }

        public IActionResult OnPostRefresh()
        {
            FirstOptionChecked = false;
            OptionsSet = false;
            return Page();
        }
    }
}