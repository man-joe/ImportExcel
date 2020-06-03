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
using CsvHelper;
using System.Reflection;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;

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
        public IFormFile ExcelUpload { get; set; }


        public IFormFile CmdbUpload { get; set; }

        [BindProperty]
        public IFormFile SunUpload { get; set; }



        [Obsolete]
        public async Task OnPostExcelUploadAsync()
        {
            if (ExcelUpload != null)
            {
                try
                {
                    string fileExt = Path.GetExtension(ExcelUpload.FileName);

                    //Validate file Type
                    if (fileExt != ".xls" && fileExt != ".xlsx" && fileExt != ".csv")
                    {
                        Message = "Please select an excel with .xls, .xlsx, or .csv extension";
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

                        var fileName = Path.GetFileName(ExcelUpload.FileName);
                        var filePath = Path.Combine(folderPath, fileName);
                        /*                            var filePath = Path.Combine(folderPath,
                                                                            Path.GetFileName(CmdbUpload.FileName));*/

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            if (fileName.ToUpper().Contains("CMDB"))
                            {                                
                                Message = "CMDB File uploaded.";
                                //CmdbUpload.CopyTo(fileStream);
                                await ExcelUpload.CopyToAsync(fileStream);
                               /* await CmdbUpload.CopyToAsync  */
                            }
                            else if (fileName.ToUpper().Contains("SUN"))
                            {
                                await ExcelUpload.CopyToAsync(fileStream);
                                Message = "Sunflower File uploaded.";
                            }
                            else if (fileName.ToUpper().Contains("EPO"))
                            {
                                await ExcelUpload.CopyToAsync(fileStream);
                                Message = "EPO File uploaded.";
                            }

                        }

                        /*else if(fileName.ToUpper().Contains("SUN"))
                        {
                            var filePath = Path.Combine(folderPath,
                                                    Path.GetFileName(SunUpload.FileName));
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                
                            }
                        }


                        var filePath = Path.Combine(folderPath,
                                                    Path.GetFileName(CmdbUpload.FileName));
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await CmdbUpload.CopyToAsync(fileStream);
                            Message = "CMDB File uploaded.";
                        }*/
                    }



/*                    //Get File Extension
                    string excelConString = "";

                    //Set Connection String based on Extension
                    switch (fileExt)
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
*/
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
                catch (Exception ex)
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
                                                    Path.GetFileName(ExcelUpload.FileName));

            /* var path = Path.Combine(
                 _environment.ContentRootPath,
                 String.Format("Data/Source/02042020_CMDB.xlsx"));*/

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var ep = new ExcelPackage(stream))
                {
                    // get the first worksheet
                    ExcelWorkbook wb = ep.Workbook;
                    /*var ws = wb.Worksheets["owssvr"];*/
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
                            cmdb.HostName = row[nRow, 3].GetValue<string>();
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

        [Obsolete]
        public async Task OnPostSunCommitAsync()
        {
            string folderPath = Path.Combine(_environment.ContentRootPath, "uploads");
            var filePath = Path.Combine(folderPath,
                                                    Path.GetFileName(ExcelUpload.FileName));

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var ep = new ExcelPackage(stream))
                {
                    // get the first worksheet
                    var ws = ep.Workbook.Worksheets[0];

                    // initialize the record counters
                    var sunSum = 0;

                    #region Import all Sunflower entries
                    // create a list containing all the Sunflower entries already existing
                    // into the Database (it should be empty on first run).
                    var lstSuns = _context.Sunflowers.ToList();

                    // iterates through all rows, skipping the first one
                    for (int nRow = 2; nRow <= ws.Dimension.End.Row; nRow++)
                    {
                        var row = ws.Cells[nRow, 1, nRow, ws.Dimension.End.Column];
                        var barcodeNum = row[nRow, 1].GetValue<string>();

                        // Did we already create a sunflower entry with that name?
                        if (lstSuns.Where(c => c.BarcodeNum == barcodeNum).Count() >= 0)
                        {
                            //There already exist a entry... Remove it then update!
                            //ONE entry per barcode tag
                            if (lstSuns.Where(c => c.BarcodeNum == barcodeNum).Count() > 0)
                            {
                                Console.WriteLine(lstSuns.Where(c => c.BarcodeNum == barcodeNum).Count());
                                lstSuns.RemoveAll(c => c.BarcodeNum == barcodeNum);
                            }
                            // create a new CMDB entity and fill it with xlsx data                         

                            var sun = new Sunflower();

                            sun.BarcodeNum = barcodeNum;
                            sun.Status = row[nRow, 3].GetValue<string>();
                            sun.Manufacturer = row[nRow, 6].GetValue<string>();
                            sun.Model = row[nRow, 7].GetValue<string>();
                            sun.OfficialName = row[nRow, 5].GetValue<string>();
                            sun.ModelName = row[nRow, 9].GetValue<string>();
                            sun.SerialNumber = row[nRow, 11].GetValue<string>();
                            sun.AssetValue = row[nRow, 13].GetValue<string>();
                            sun.EffectiveDate = row[nRow, 16].GetValue<DateTime>();
                            sun.CustArea = row[nRow, 19].GetValue<string>();
                            sun.BureauOrRegion = row[nRow, 20].GetValue<string>();
                            sun.PropertyContact = row[nRow, 22].GetValue<string>();
                            sun.CurrentUser = row[nRow, 23].GetValue<string>();
                            sun.FedSupplyGroup = row[nRow, 24].GetValue<string>();
                            sun.UtilizationCode = row[nRow, 25].GetValue<string>();
                            sun.AssetCondition = row[nRow, 27].GetValue<string>();
                            sun.ConditionDescription = row[nRow, 28].GetValue<string>();
                            sun.PhysicalInventoryDate = row[nRow, 29].GetValue<DateTime>();
                            sun.AcquisitionDate = row[nRow, 30].GetValue<DateTime>();
                            sun.ResponsibilityDate = row[nRow, 31].GetValue<DateTime>();
                            sun.Site = row[nRow, 33].GetValue<string>();
                            sun.Stlv1 = row[nRow, 36].GetValue<string>();
                            sun.Stlv2 = row[nRow, 38].GetValue<string>();
                            sun.Stlv3 = row[nRow, 39].GetValue<string>();
                            sun.MailStop = row[nRow, 48].GetValue<string>();
                            sun.Gps1 = row[nRow, 49].GetValue<string>();
                            sun.Gps2 = row[nRow, 50].GetValue<string>();
                            sun.Gps3 = row[nRow, 51].GetValue<string>();
                            sun.ResolutionDate = row[nRow, 53].GetValue<DateTime>();
                            sun.Resolution = row[nRow, 54].GetValue<string>();
                            sun.FinalEvent = row[nRow, 55].GetValue<string>();
                            sun.Datetime = row[nRow, 56].GetValue<DateTime>();
                            sun.FinalEventUserDefinedLabel01 = row[nRow, 57].GetValue<string>();
                            sun.FinalEventUserField01 = row[nRow, 58].GetValue<string>();

                            // save it into the Database
                            _context.Sunflowers.Add(sun);
                            await _context.SaveChangesAsync();

                            // store the cmdb to retrieve its Id later on
                            lstSuns.Add(sun);

                            // increment the counter
                            sunSum++;
                        }
                    }
                    #endregion

                    Message = "SunFlower Committed to Database. " +
                                sunSum + " entries Added.";
                }
            }
        }

        [Obsolete]
        public async Task OnPostEPOCommitAsync()
        {
            string folderPath = Path.Combine(_environment.ContentRootPath, "uploads");
            var filePath = Path.Combine(folderPath,
                                                    Path.GetFileName(ExcelUpload.FileName));

            Assembly assembly = Assembly.GetExecutingAssembly();

            using (var streamReader = System.IO.File.OpenText(filePath))
            using (var csv = new CsvReader(streamReader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.HeaderValidated = null;
                csv.Configuration.MissingFieldFound = null;

                try
                {
                    var records = csv.GetRecords<EPO>().ToList();
/*                    foreach(var r in records)
                    {
                        Console.WriteLine(r.EpoId + "\t" + r.SystemName);
                    }*/
                    /* Console.WriteLine(JsonConvert.SerializeObject(records));*/
                    int nEPO = records.Count();
                    _context.Epos.AddRange(records);
                    await _context.SaveChangesAsync();
                    Message = "EPO Committed to Database. " +
                        nEPO + " entries Added.";
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} - datetime is not parsed", csv);
                }
                
                

                /*foreach(var r in records)
                {
                    if (r.SystemName.Length == 15)
                        r.UniqueIdentifier = r.SystemName.Substring(6, 9);
                }
                _context.Epos.AddRange(records);
*/
               
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


        /*public void */

    }
}