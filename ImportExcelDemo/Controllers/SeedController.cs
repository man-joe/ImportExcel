using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ImportExcelDemo.Data;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using OfficeOpenXml;
using ImportExcelDemo.Models;

namespace ImportExcelDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly DemoContext _context;
        private readonly IWebHostEnvironment _env;

        public SeedController(DemoContext context, IWebHostEnvironment env)
        {
            _context = context;
            // same as this.context = context;
            _env = env;
        }

        [HttpGet]
        public async Task<ActionResult> Import()
        {
            var path = Path.Combine(
                _env.ContentRootPath,
                String.Format("uploads/02042020_CMDB.xlsx"));

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (var ep = new ExcelPackage(stream))
                {
                    // get the first worksheet

                    var ws = ep.Workbook.Worksheets[0];

                    // initialize the record counters
                    var nCMDB = 0;


                    #region Import all CMDB entries
                    // create a list containing all the CMDB entries already existing
                    // into the Database (it will be empty on first run).
                    var lstCmdbs = _context.Cmdbs.ToList();

                    // iterates through all rows, skipping the first one
                    for (int nRow = 2; nRow <= ws.Dimension.End.Row; nRow++)
                    {
                        var row = ws.Cells[nRow, 1, nRow, ws.Dimension.End.Column];
                        var cdTag = row[nRow, 1].GetValue<string>();

                        // Did we already created a Cmdb entry with that name?
                        if (lstCmdbs.Where(c => c.CDTag == cdTag).Count() == 0)
                        {
                            // create the Country entity and fill it with xlsx data
                            var cmdb = new Cmdb();
                            cmdb.CDTag = cdTag;
                            cmdb.AdUser = row[nRow, 14].GetValue<string>();
                            cmdb.Location = row[nRow, 4].GetValue<string>();

                            // save it into the Database
                            _context.Cmdbs.Add(cmdb);
                            await _context.SaveChangesAsync();

                            // store the cmdb to retrieve its Id later on
                            lstCmdbs.Add(cmdb);

                            // increment the counter
                            nCMDB++;
                        }
                    }

                    #endregion

                    return new JsonResult(new
                    {
                        Cmdbs = nCMDB
                    });

                }

            }
        }
    }
}
