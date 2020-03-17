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
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using Microsoft.Data.SqlClient;
using ExcelDataReader;
using ImportExcelDemo.Models;
using ImportExcelDemo.Data;
using OfficeOpenXml;

namespace ImportExcelDemo.Pages.ImportExcel
{
    public class IndexModel : PageModel
    {
        //IHostingEnvironment has been replaced with IWebHosting but is still used
        //when you don't need the WebRootPath or WebRootFileProvider location
        [Obsolete]
        private IHostingEnvironment _environment;

        private readonly DemoContext _context;

        [Obsolete]
        public IndexModel(IHostingEnvironment environment, DemoContext context)
        {
            _environment = environment;
            _context = context;
        }

        [ViewData]
        public string Message { get; set; }

        [BindProperty]
        public IFormFile CmdbUpload { get; set; }

        [Obsolete]
        public async Task OnPostCmdbUploadAsync()
        {
            if(CmdbUpload != null)
            {       
                try
                {
                    string fileExt = Path.GetExtension(CmdbUpload.FileName);

                    //Validate file Type
                    if (fileExt != ".xls" && fileExt != ".xlsx")
                    {
                        Message = "Please select an excel with .xls or .xlsx extension";
                    }
                    else
                    {
                        string folderPath = Path.Combine(_environment.ContentRootPath, "uploads");

                        //Server.MapPath("~/uploads/");
                        //Check for if Directory exists
                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }

                        //Save file to folder
                        var filePath = Path.Combine(folderPath,
                                                    Path.GetFileName(CmdbUpload.FileName));
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await CmdbUpload.CopyToAsync(fileStream);
                            Message = "CMDB File uploaded.";
                        }
                    }



                    //Get File Extension
                    string excelConString = "";

                    //Set Connection String based on Extension
                    switch(fileExt)
                    {
                        //Excel 1997-2007 extension
                        case ".xls":
                            excelConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES'";
                            break;
                        //Excel 2007 and above extension
                        case ".xlsx":
                            excelConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES'";
                            break;
                    }

                    //Fill Data Table

                    /// 
                    /*
                    DataTable dt = new DataTable();

                    FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    using(stream)
                    {
                        //Will auto-detect if xls or xlsx format
                        using(var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            //Read all of Excel File and assign to a DataSet
                            var result = reader.AsDataSet(new ExcelDataSetConfiguration());

                            DataTableCollection dataTable = result.Tables;
                            dt = dataTable["owssvr"]; // or owssvr / Sheet1?
                        }

                    }

                    */
                    ////


                    /*
                     * misc code scratchwork:
                     * 
                     * var workSheet = reader.asDataSet().Tables["Sheet1"] or owssvr
                     * var sheets = from DataTable sheet in workbook.Tables select sheet.TableName;
                     */



                    /*

                    //Insert Records as Entities
                    DemoContext entities = new DemoContext();
                    foreach(DataRow row in dt.Rows)
                    {
                        entities.Cmdbs.Add(GetCmdbFromExcelRow(row));
                    }
                    entities.SaveChanges();

                    Message = "Data Imported Successfully.";

                    */

                   /* //Read data from first sheet of excel into datatable
                    DataTable dt = new DataTable();
                    excelConString = string.Format(excelConString, filePath);

                    using(OleDbConnection excelOledbConnection = new OleDbConnection(excelConString))
                    {
                        using(OleDbCommand excelDbCommand = new OleDbCommand())
                        {
                            using (OldDbDataAdapter excelDataAdapter = new OleDbDataAdapter())
                            {
                                excelDbCommand.Connection = excelOledbConnection;
                            }
                        }

                    }
                    System.Data.datase*/
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

        [Obsolete]
        public async Task OnPostCmdbCommitAsync()
        {
            string folderPath = Path.Combine(_environment.ContentRootPath, "uploads");
            var filePath = Path.Combine(folderPath,
                                                    Path.GetFileName(CmdbUpload.FileName));

           /* var path = Path.Combine(
                _environment.ContentRootPath,
                String.Format("Data/Source/02042020_CMDB.xlsx"));*/

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var ep = new ExcelPackage(stream))
                {
                    // get the first worksheet

                    var ws = ep.Workbook.Worksheets[0];

                    // initialize the record counters
                    var nCMDB = 0;


                    #region Import all CMDB entries
                    // create a list containing all the CMDB entries already existing
                    // into the Database (it should be empty on first run).
                    var lstCmdbs = _context.Cmdbs.ToList();

                    // iterates through all rows, skipping the first one
                    for (int nRow = 2; nRow <= ws.Dimension.End.Row; nRow++)
                    {
                        var row = ws.Cells[nRow, 1, nRow, ws.Dimension.End.Column];
                        var cdTag = row[nRow, 1].GetValue<string>();

                        // Did we already created a Cmdb entry with that name?
                        if (lstCmdbs.Where(c => c.CDTag == cdTag).Count() >= 0)
                        {
                            //There already exist a entry... Remove it then update!
                            //ONE entry per CD Tag
                            if (lstCmdbs.Where(c => c.CDTag == cdTag).Count() > 0)
                            {
                                Console.WriteLine(lstCmdbs.Where(c => c.CDTag == cdTag).Count());
                                lstCmdbs.RemoveAll(c => c.CDTag == cdTag);
                            }
                            // create a new CMDB entity and fill it with xlsx data                         

                            var cmdb = new Cmdb();                          

                            cmdb.CDTag = cdTag;
                            cmdb.Org = row[nRow, 2].GetValue<string>();
                            cmdb.HostName = row[nRow,3].GetValue<string>();
                            cmdb.Location = row[nRow, 4].GetValue<string>();
                            cmdb.Floor = row[nRow, 5].GetValue<string>();
                            cmdb.Room = row[nRow, 6].GetValue<string>();
                            cmdb.IpAddress = row[nRow, 7].GetValue<string>();
                            cmdb.SubnetMask = row[nRow, 8].GetValue<string>();
                            cmdb.MacAddress = row[nRow, 9].GetValue<string>();
                            cmdb.Manufacturer = row[nRow, 10].GetValue<string>();
                            cmdb.Model = row[nRow, 11].GetValue<string>();
                            cmdb.SerialNumber = row[nRow, 12].GetValue<string>();
                            cmdb.OperatingSystem = row[nRow, 13].GetValue<string>();
                            cmdb.AdUser = row[nRow, 14].GetValue<string>();
                            cmdb.SunflowerUser = row[nRow, 15].GetValue<string>();
                            cmdb.Status = row[nRow, 16].GetValue<string>();
                            cmdb.ClassType = row[nRow, 17].GetValue<string>();
                            cmdb.AcquisitionDate = row[nRow, 18].GetValue<DateTime>();
                            cmdb.WarrentyEndDate = row[nRow, 19].GetValue<DateTime>();
                            cmdb.Custodian = row[nRow, 20].GetValue<string>();
                            cmdb.Comments = row[nRow, 21].GetValue<string>();
                            cmdb.InventoriedBy = row[nRow, 22].GetValue<string>();
                            cmdb.InventoryDate = row[nRow, 23].GetValue<DateTime>();
                            cmdb.LastScan = row[nRow, 24].GetValue<DateTime>();
                            cmdb.ModifiedBy = row[nRow, 25].GetValue<string>();
                            cmdb.Modified = row[nRow, 26].GetValue<DateTime>();

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

                    Message = "CMDB Committed to Database. " + 
                                nCMDB + " entries Added.";

                    
                   /* return new JsonResult(new
                    {
                        Cmdb_entries_added = nCMDB
                    });*/

                }

            }
        }





        //Helper Method with grabbing specific data/columns 
        private Cmdb GetCmdbFromExcelRow(DataRow row)
        {
            return new Cmdb
            {
                CDTag = row[0].ToString(),
                Location = row[3].ToString(),
                AdUser = row[13].ToString()
            };
        }

    }
}