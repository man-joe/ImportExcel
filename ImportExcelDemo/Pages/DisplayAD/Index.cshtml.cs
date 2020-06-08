using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImportExcelDemo.Data;
using ImportExcelDemo.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ImportExcelDemo.Pages.DisplayAD
{
    public class IndexModel : PageModel
    {

        [Obsolete]
        private IHostingEnvironment _environment;

        private readonly ImportExcelDemo.Data.DemoContext _context;
        /*public List<> JoinDatas { get; set; }*/

        [Obsolete]
        public IndexModel(IHostingEnvironment environment, DemoContext context)
        {
            _environment = environment;
            _context = context;
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

            //if(AD_Users.Count != 0)
            //{

            //    int nUserEntries = AD_Users.Count();
            //    StatusMessage = "Currently Showing AD_Users";
            //    NumMessage = "Total Entries: " + nUserEntries;
            //} else if (AD_Computers.Count != 0)
            //{
                int nComputerEntries = AD_Computers.Count();
                StatusMessage = "Currently Showing AD_Computers";
                NumMessage = "Total Entries: " + nComputerEntries;
            //}
        }
        //JSON result / using js for a more dynamic table...
        public IList<AD_User> AD_User { get; set; }

        public IList<AD_Computer> AD_Computer { get; set; }
        
        public async Task<ActionResult> OnGetListAsync()
        {
            AD_User = await _context.AD_Users
                .AsNoTracking()
                .ToListAsync();

            AD_Computer = await _context.AD_Computers
                .AsNoTracking()
                .ToListAsync();


            //if(AD_User.Count != 0)
            //{
            //    return new JsonResult(AD_User);
            //}

            return new JsonResult(AD_Computer);
        }
    }
}