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