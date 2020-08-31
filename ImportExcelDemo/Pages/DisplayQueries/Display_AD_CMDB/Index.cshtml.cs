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

namespace ImportExcelDemo.Pages.DisplayQueries.Display_AD_CMDB
{
    public class IndexModel : PageModel
    {
        [Obsolete]
        private IHostingEnvironment _environment;

        private readonly ImportExcelDemo.Data.DemoContext _context;

        public bool FirstOptionChecked { get; set; }
        public bool OptionsSet { get; set; }

        public List<string> ComputerOptions { get; set; }

        public List<string> CMDBOptions { get; set; }

        public List<string> UserOptions { get; set; }


        [Obsolete]
        public IndexModel(IHostingEnvironment environment, DemoContext context)
        {
            _environment = environment;
            _context = context;
            OptionsSet = false;
            ComputerOptions = new List<string>();
            CMDBOptions = new List<String>();
            UserOptions = new List<String>();
        }
        public int DataSet { get; set; }
        [ViewData]
        public string StatusMessage { get; set; }
        [ViewData]
        public string NumMessage { get; set; }
        public IList<Cmdb> Cmdbs { get; set; }

        public IList<AD_Computer> AD_Computers { get; set; }

        public IList<AD_User> AD_Users { get; set; }

        public async Task OnGetAsync()
        {
            Cmdbs = await _context.Cmdbs
                .AsNoTracking()
                .ToListAsync();

            AD_Computers = await _context.AD_Computers
                .AsNoTracking()
                .ToListAsync();

            AD_Users = await _context.AD_Users
                .AsNoTracking()
                .ToListAsync();
        }
        public IActionResult OnPostSubmit()
        {
            FirstOptionChecked = true;
            DataSet = Convert.ToInt32(Request.Form["DataSets"]);
            return Page();
        }
        public async Task OnPostDisplay(int id)
        {
            DataSet = id;
            Cmdbs = await _context.Cmdbs
               .AsNoTracking()
               .ToListAsync();

            AD_Computers = await _context.AD_Computers
                .AsNoTracking()
                .ToListAsync();

            AD_Users = await _context.AD_Users
                .AsNoTracking()
                .ToListAsync();

            if (id == 0)
            {
                NumMessage = "The total number AD Computer entries is " + AD_Computers.Count;
                StatusMessage = "Now displaying AD Computer entries";
            } 
            else if (id == 1)
            {
                NumMessage = "The total number AD User entries is " + AD_Users.Count;
                StatusMessage = "Now displaying AD User entries";
            } 
            else if (id == 2)
            {
                NumMessage = "The total number CMDB entries is " + Cmdbs.Count;
                StatusMessage = "Now displaying CMDB entries";
            } 
            else if (id == 3)
            {
                var Cd_User = from u in _context.AD_Users
                                  join d in _context.Cmdbs on u.UserName equals d.AdUser
                                  orderby d.AdUser
                                  select d;

                var User_Cd = from u in _context.AD_Users
                                  join d in _context.Cmdbs on u.UserName equals d.AdUser
                                  orderby d.AdUser
                                  select u;


                Cmdbs = await Cd_User.AsNoTracking().ToListAsync();
                AD_Users = await User_Cd.AsNoTracking().ToListAsync();
                NumMessage = "The total number of CMDB entries with a Corresponding AD Computer entry is " + AD_Computers.Count;
                StatusMessage = "Now displaying common CMDB and AD Computer entries";

            }
            else if (id == 4)
            {
                var Cd_Computer = from computers in _context.AD_Computers
                                  join CDItem in _context.Cmdbs on computers.ADComputerName equals CDItem.HostName
                                  orderby CDItem.AdUser
                                  select CDItem;

                var Computer_Cd = from computers in _context.AD_Computers
                                  join CDItem in _context.Cmdbs on computers.ADComputerName equals CDItem.HostName
                                  orderby CDItem.AdUser
                                  select computers;


                Cmdbs = await Cd_Computer.AsNoTracking().ToListAsync();
                AD_Computers = await Computer_Cd.AsNoTracking().ToListAsync();
                NumMessage = "The total number of CMDB entries with a Corresponding AD Computer entry is " + AD_Computers.Count;
                StatusMessage = "Now displaying common CMDB and AD Computer entries";
            }
            else if (id == 5)
            {
                var queryUser = from d in _context.Cmdbs
                                join u in _context.AD_Users on d.AdUser equals u.UserName
                                join c in _context.AD_Computers on d.HostName equals c.ADComputerName
                                orderby d.AdUser
                                select u;
                var queryComputer = from d in _context.Cmdbs
                                join u in _context.AD_Users on d.AdUser equals u.UserName
                                join c in _context.AD_Computers on d.HostName equals c.ADComputerName
                                orderby d.AdUser
                                select c;
                var queryCD = from d in _context.Cmdbs
                                join u in _context.AD_Users on d.AdUser equals u.UserName
                                join c in _context.AD_Computers on d.HostName equals c.ADComputerName
                                orderby d.AdUser
                                select d;

                AD_Users = await queryUser.AsNoTracking().ToListAsync();
                AD_Computers = await queryComputer.AsNoTracking().ToListAsync();
                Cmdbs = await queryCD.AsNoTracking().ToListAsync();
                NumMessage = "The total number of CMDB entries with a Corresponding AD Computer entry and AD User entry is " + AD_Computers.Count;
                StatusMessage = "Now displaying common CMDB and AD Computer/User entries";
            }

            


            OptionsSet = true;


            foreach (var item in Request.Form.Keys)
            {
                if(item.Contains("ComputerOptions-13"))
                {
                    ComputerOptions.Add("ComputerOptions-0");
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
                if (item.Contains("UserOptions-20"))
                {
                    UserOptions.Add("UserOptions-0");
                    UserOptions.Add("UserOptions-1");
                    UserOptions.Add("UserOptions-2");
                    UserOptions.Add("UserOptions-3");
                    UserOptions.Add("UserOptions-4");
                    UserOptions.Add("UserOptions-5");
                    UserOptions.Add("UserOptions-6");
                    UserOptions.Add("UserOptions-7");
                    UserOptions.Add("UserOptions-8");
                    UserOptions.Add("UserOptions-9");
                    UserOptions.Add("UserOptions-10");
                    UserOptions.Add("UserOptions-11");
                    UserOptions.Add("UserOptions-12");
                    UserOptions.Add("UserOptions-13");
                    UserOptions.Add("UserOptions-14");
                    UserOptions.Add("UserOptions-15");
                    UserOptions.Add("UserOptions-16");
                    UserOptions.Add("UserOptions-17");
                    UserOptions.Add("UserOptions-18");
                    UserOptions.Add("UserOptions-19");
                }
                else if (item.Contains("UserOptions"))
                {
                    UserOptions.Add(item);
                }
                if (item.Contains("CMDBOptions-26"))
                {
                    CMDBOptions.Add("CMDBOptions-0");
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
        }

        public IActionResult OnPostRefresh()
        {
            OptionsSet = false;
            return Page();
        }
    }
}