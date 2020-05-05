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

namespace ImportExcelDemo.Pages.DisplayTable
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

            /* JoinDatas = (
                 from c in _context.Cmdbs
                 join s in _context.Sunflowers
                 on c.CDTag equals s.BarcodeNum
                 select new
                 {
                     CDTag = c.CDTag,
                     Org = c.Org

                 }).ToList();*/


       /*     List<Cmdb> query = (
                from c in _context.Cmdbs
                join s in _context.Sunflowers
                on c.CDTag equals s.BarcodeNum //
                select new
                {
                    CDTag = c.CDTag,
                    c.Org,
                    c.HostName,
                    c.Location
                }).ToList();

            JoinDatas = query;*/
        }



        [ViewData]
        public string StatusMessage { get; set; }
        [ViewData]
        public string NumMessage { get; set; }
        public IList<Cmdb> Cmdbs { get; set; }

        
        /*public var joins { get; set; }*/

        public async Task OnGetAsync()
        {
            Cmdbs = await _context.Cmdbs
                .AsNoTracking()
                .ToListAsync();

            var joinedTable = (
                from c in _context.Cmdbs
                join s in _context.Sunflowers
                on c.CDTag equals s.BarcodeNum
                select c).ToListAsync();

            /*JoinDatas = await joins.;*/
        /*    
            JoinDatas = await
                _context.Cmdbs.Join(_context.Sunflowers,
                c => c.CDTag,
                s => s.BarcodeNum,
                (c, s) => new
                {
                    c.CDTag,
                    c.Org,
                    c.HostName,
                    c.Location
                }).ToListAsync();

            JoinDatas = await (from c in _context.Cmdbs
                            join s in _context.Sunflowers
                            on c.CDTag equals s.BarcodeNum
                            select new
                            {
                                CDTag = c.CDTag,

                            }).ToListAsync();*/

           /* int nEntries = joins.Count();*/
            int nEntries = Cmdbs.Count();
            StatusMessage = "Currently Showing: JoinDatas";
            NumMessage = "Total Entries: " + nEntries;
        }


        //JSON result / using js for a more dynamic table...
        public IList<Cmdb> CMDB { get; set; }
        
        public async Task<ActionResult> OnGetListAsync()
        {
            CMDB = await _context.Cmdbs
                /*.Include(c => c.)*/
                .AsNoTracking()
                .ToListAsync();

            return new JsonResult(CMDB);
        }
    }
}