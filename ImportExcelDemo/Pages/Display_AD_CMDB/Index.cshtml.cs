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
using Microsoft.EntityFrameworkCore.Internal;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;

namespace ImportExcelDemo.Pages
{
    public class IndexModel : PageModel
    {
        [Obsolete]
        private IHostingEnvironment _environment;

        private readonly ImportExcelDemo.Data.DemoContext _context;
        /*public List<> JoinDatas { get; set; }*/

        public bool OptionsSet { get; set; }

        public List<string> ComputerOptions { get; set; }

        public List<string> CMDBOptions { get; set; }


        [Obsolete]
        public IndexModel(IHostingEnvironment environment, DemoContext context)
        {
            _environment = environment;
            _context = context;
            OptionsSet = false;
            ComputerOptions = new List<string>();
            CMDBOptions = new List<String>();
        }



        [ViewData]
        public string StatusMessage { get; set; }
        [ViewData]
        public string NumMessage { get; set; }
        public IList<Cmdb> Cmdbs { get; set; }

        public IList<AD_Computer> AD_Computers { get; set; }

        /*public var joins { get; set; }*/
        public async Task OnGetAsync()
        {
            Cmdbs = await _context.Cmdbs
                .AsNoTracking()
                .ToListAsync();

            AD_Computers = await _context.AD_Computers
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task OnPostDisplay()
        {
            Cmdbs = await _context.Cmdbs
               .AsNoTracking()
               .ToListAsync();

            AD_Computers = await _context.AD_Computers
                .AsNoTracking()
                .ToListAsync();

            var queryCD = from computers in _context.AD_Computers
                          join CDItem in _context.Cmdbs on computers.ADComputerName equals CDItem.HostName
                          orderby computers.ADComputerName
                          select CDItem;

            var queryAD = from computers in _context.AD_Computers
                          join CDItem in _context.Cmdbs on computers.ADComputerName equals CDItem.HostName

                          orderby computers.ADComputerName
                          select computers;

            Cmdbs = await queryCD.AsNoTracking().ToListAsync();
            AD_Computers = await queryAD.AsNoTracking().ToListAsync();

            OptionsSet = true;


            foreach (var item in Request.Form.Keys)
            {
                if(item.Contains("ComputerOptions-13"))
                {
                    ComputerOptions.Add("ComputerOptions-1");
                    ComputerOptions.Add("ComputerOptions-2");
                    ComputerOptions.Add("ComputerOptions-3");
                    ComputerOptions.Add("ComputerOptions-4");
                    ComputerOptions.Add("ComputerOptions-5");
                    ComputerOptions.Add("ComputerOptions-6");
                    ComputerOptions.Add("ComputerOptions-7");
                    ComputerOptions.Add("ComputerOptions-8");
                    ComputerOptions.Add("ComputerOptions-9");
                    ComputerOptions.Add("ComputerOptions-10");
                    ComputerOptions.Add("ComputerOptions-11");
                    ComputerOptions.Add("ComputerOptions-11");
                    ComputerOptions.Add("ComputerOptions-12");
                }
                else if (item.Contains("ComputerOptions"))
                {
                    ComputerOptions.Add(item);
                }
                if(item.Contains("CMDBOptions-26"))
                {
                    CMDBOptions.Add("CMDBOptions-1");
                    CMDBOptions.Add("CMDBOptions-2");
                    CMDBOptions.Add("CMDBOptions-3");
                    CMDBOptions.Add("CMDBOptions-4");
                    CMDBOptions.Add("CMDBOptions-5");
                    CMDBOptions.Add("CMDBOptions-6");
                    CMDBOptions.Add("CMDBOptions-7");
                    CMDBOptions.Add("CMDBOptions-8");
                    CMDBOptions.Add("CMDBOptions-9");
                    CMDBOptions.Add("CMDBOptions-10");
                    CMDBOptions.Add("CMDBOptions-11");
                    CMDBOptions.Add("CMDBOptions-12");
                    CMDBOptions.Add("CMDBOptions-13");
                    CMDBOptions.Add("CMDBOptions-14");
                    CMDBOptions.Add("CMDBOptions-15");
                    CMDBOptions.Add("CMDBOptions-16");
                    CMDBOptions.Add("CMDBOptions-17");
                    CMDBOptions.Add("CMDBOptions-18");
                    CMDBOptions.Add("CMDBOptions-19");
                    CMDBOptions.Add("CMDBOptions-20");
                    CMDBOptions.Add("CMDBOptions-21");
                    CMDBOptions.Add("CMDBOptions-22");
                    CMDBOptions.Add("CMDBOptions-23");
                    CMDBOptions.Add("CMDBOptions-24");
                    CMDBOptions.Add("CMDBOptions-25");
                }
                else if (item.Contains("CMDBOptions"))
                {
                    CMDBOptions.Add(item);
                }
            }
            NumMessage = "The total number of CMDB entries with a Corresponding AD Computer entry is " + AD_Computers.Count;
            StatusMessage = "Now displaying common CMDB and AD Computer entries";
        }

        public IActionResult OnPostRefresh()
        {
            OptionsSet = false;
            return Page();
        }
    }
}