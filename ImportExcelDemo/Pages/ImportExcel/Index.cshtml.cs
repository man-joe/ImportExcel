using CsvHelper; //CSV .net library
using ImportExcelDemo.Data;
using ImportExcelDemo.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OfficeOpenXml; //EPPlus .net library
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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

        // Helper method to save file and returns file path
        // Reminder! When reading files, you can NOT get full physical file path from client
        // You will get 3 things: the file, filename, and file extension
        [Obsolete]
        private string SaveAndGetFilePath()
        {
            //Check if user submits a file
            if (ExcelUpload != null)
            {
                try
                {
                    string fileExt = Path.GetExtension(ExcelUpload.FileName);

                    //Validate file type
                    if (fileExt != ".xls" && fileExt != ".xlsx" && fileExt != ".csv")
                    {
                        Message = "Error! Please select an excel file with .xls, .xlsx, or .csv extension";
                    }
                    else
                    {
                        string folderPath = Path.Combine(_environment.WebRootPath, "uploads");

                        //Check for if Directory exists
                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }

                        //Save file to folder         
                        var fileName = Path.GetFileName(ExcelUpload.FileName);

                        //Validate correct file name
                        if (fileName.ToUpper().Contains("CMDB"))
                        {
                            Message = "CMDB File uploaded.";
                        }
                        else if (fileName.ToUpper().Contains("SUN"))
                        {
                            Message = "Sunflower File uploaded.";
                        }
                        else if (fileName.ToUpper().Contains("EPO"))
                        {
                            Message = "EPO File uploaded.";
                        }
                        else if (fileName.ToUpper().Contains("ACTIVE") ||
                            fileName.ToUpper().Contains("AD"))
                        {
                            Message = "AD File uploaded.";
                        }
                        else if (fileName.ToUpper().Contains("SCCM"))
                        {
                            Message = "SCCM File uploaded.";
                        }
                        else if (fileName.ToUpper().Contains("ECMO"))
                        {
                            Message = "ECMO File uploaded.";
                        }
                        else
                        {
                            Message = "Error! File Not Recognized.";
                        }

                        if (Message.Contains("uploaded."))
                        {
                            var filePath = Path.Combine(folderPath, fileName);
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                ExcelUpload.CopyTo(fileStream);
                            }
                            return filePath;
                        }

                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    return null;
                }
            }

            Message = "Error! Please select a File to upload.";
            return null;
        }


        [Obsolete]
        public async Task OnPostCmdbCommitAsync()
        {
            //Reminder! Uploading a file will not give you their system path  
            string filePath = SaveAndGetFilePath();

            if (!Message.Contains("Error!"))
            {
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

                                lstCmdbs.Add(new Cmdb
                                {
                                    CDTag = row[nRow, 1].GetValue<string>(),
                                    Org = row[nRow, 2].GetValue<string>(),
                                    HostName = row[nRow, 3].GetValue<string>(),
                                    Location = row[nRow, 4].GetValue<string>(),
                                    Floor = row[nRow, 5].GetValue<string>(),
                                    Room = row[nRow, 6].GetValue<string>(),
                                    IpAddress = row[nRow, 7].GetValue<string>(),
                                    SubnetMask = row[nRow, 8].GetValue<string>(),
                                    MacAddress = row[nRow, 9].GetValue<string>(),
                                    Manufacturer = row[nRow, 10].GetValue<string>(),
                                    Model = row[nRow, 11].GetValue<string>(),
                                    SerialNumber = row[nRow, 12].GetValue<string>(),
                                    OperatingSystem = row[nRow, 13].GetValue<string>(),
                                    AdUser = row[nRow, 14].GetValue<string>(),
                                    SunflowerUser = row[nRow, 15].GetValue<string>(),
                                    Status = row[nRow, 16].GetValue<string>(),
                                    ClassType = row[nRow, 17].GetValue<string>(),
                                    AcquisitionDate = row[nRow, 18].GetValue<DateTime>(),
                                    WarrantyEndDate = row[nRow, 19].GetValue<DateTime>(),
                                    Custodian = row[nRow, 20].GetValue<string>(),
                                    Comments = row[nRow, 21].GetValue<string>(),
                                    InventoriedBy = row[nRow, 22].GetValue<string>(),
                                    InventoryDate = row[nRow, 23].GetValue<DateTime>(),
                                    LastScan = row[nRow, 24].GetValue<DateTime>(),
                                    ModifiedBy = row[nRow, 25].GetValue<string>(),
                                    Modified = row[nRow, 26].GetValue<DateTime>()
                                });

                                // save it into the Database
                                _context.Cmdbs.AddRange(lstCmdbs);
                                nCMDB++;
                            }
                        }

                        await _context.SaveChangesAsync();
                        #endregion

                        Message = "CMDB Committed to Database. " +
                                    nCMDB + " entries Added.";
                    }
                }
            }
        }

        [Obsolete]
        public async Task OnPostSunCommitAsync()
        {
            string filePath = SaveAndGetFilePath();

            if (!Message.Contains("Error!"))
            {
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

                                // For empty Strings in DateTime Cells
                                DateTime? dateTime = String.IsNullOrEmpty(row[nRow, 56].GetValue<string>())
                                    ? (DateTime?)null : DateTime.Parse(row[nRow, 56].GetValue<string>());

                                // create a new Sunflower entity and fill it with xlsx data                         
                                lstSuns.Add(new Sunflower //I prefer it this way better
                                {
                                    BarcodeNum = barcodeNum,
                                    Status = row[nRow, 3].GetValue<string>(),
                                    Manufacturer = row[nRow, 6].GetValue<string>(),
                                    Model = row[nRow, 7].GetValue<string>(),
                                    OfficialName = row[nRow, 5].GetValue<string>(),
                                    ModelName = row[nRow, 9].GetValue<string>(),
                                    SerialNumber = row[nRow, 11].GetValue<string>(),
                                    AssetValue = row[nRow, 13].GetValue<string>(),
                                    EffectiveDate = row[nRow, 16].GetValue<DateTime>(),
                                    CustArea = row[nRow, 19].GetValue<string>(),
                                    BureauOrRegion = row[nRow, 20].GetValue<string>(),
                                    PropertyContact = row[nRow, 22].GetValue<string>(),
                                    CurrentUser = row[nRow, 23].GetValue<string>(),
                                    FedSupplyGroup = row[nRow, 24].GetValue<string>(),
                                    UtilizationCode = row[nRow, 25].GetValue<string>(),
                                    AssetCondition = row[nRow, 27].GetValue<string>(),
                                    ConditionDescription = row[nRow, 28].GetValue<string>(),
                                    PhysicalInventoryDate = row[nRow, 29].GetValue<DateTime>(),
                                    AcquisitionDate = row[nRow, 30].GetValue<DateTime>(),
                                    ResponsibilityDate = row[nRow, 31].GetValue<DateTime>(),
                                    Site = row[nRow, 33].GetValue<string>(),
                                    Stlv1 = row[nRow, 36].GetValue<string>(),
                                    Stlv2 = row[nRow, 38].GetValue<string>(),
                                    Stlv3 = row[nRow, 39].GetValue<string>(),
                                    MailStop = row[nRow, 48].GetValue<string>(),
                                    Gps1 = row[nRow, 49].GetValue<string>(),
                                    Gps2 = row[nRow, 50].GetValue<string>(),
                                    Gps3 = row[nRow, 51].GetValue<string>(),
                                    ResolutionDate = row[nRow, 53].GetValue<DateTime>(),
                                    Resolution = row[nRow, 54].GetValue<string>(),
                                    FinalEvent = row[nRow, 55].GetValue<string>(),
                                    Datetime = dateTime,
                                    FinalEventUserDefinedLabel01 = row[nRow, 57].GetValue<string>(),
                                    FinalEventUserField01 = row[nRow, 58].GetValue<string>()
                                });

                                // save it into the Database
                                _context.Sunflowers.AddRange(lstSuns);

                                sunSum++;
                            }
                        }

                        // int 
                        await _context.SaveChangesAsync();
                        #endregion

                        Message = "SunFlower Committed to Database. " +
                                    sunSum + " entries Added.";
                    }
                }
            }
        }

        [Obsolete]
        public async Task OnPostEPOCommitAsync()
        {

            string filePath = SaveAndGetFilePath();
            if (!Message.Contains("Error!"))
            {
                using (var streamReader = System.IO.File.OpenText(filePath))
                using (var csv = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.HeaderValidated = null;
                    csv.Configuration.MissingFieldFound = null;

                    try
                    {
                        int nEPO = 0;
                        //Reads Header
                        csv.Read();
                        csv.ReadHeader();

                        while (csv.Read())
                        {
                            //Checking for duplicate entries
                            var epo = _context.Epos
                                .Where(e => e.SystemName == csv.GetField<string>("System Name"))
                                .FirstOrDefault();
                            if (epo != null) // there exists an entry already
                                continue;


                            // Need to parse Last Communication Datetime because DOES NOT accept timezone abbreviations 
                            var getLastCom = csv.GetField<string>("Last Communication");
                            DateTime LastCom;

                            if (String.IsNullOrEmpty(getLastCom))
                            {
                                LastCom = new DateTime();
                            }
                            else
                            {
                                if (getLastCom.Contains("EDT"))
                                {
                                    getLastCom = getLastCom.Replace("EDT", "-4:00");
                                }
                                else if (getLastCom.Contains("EST"))
                                {
                                    getLastCom = getLastCom.Replace("EST", "-5:00");
                                }

                                LastCom = DateTime.ParseExact(
                                                    getLastCom,
                                                    "M/d/yy h:mm:ss tt zzz",
                                                    System.Globalization.CultureInfo.InvariantCulture).ToUniversalTime();
                            }

                            //Add to List
                            _context.Epos.Add(new EPO
                            {
                                SystemName = csv.GetField<string>("System Name"),
                                ManagedState = csv.GetField<string>("Managed State"),
                                Tags = csv.GetField<string>("Tags"),
                                IpAddress = csv.GetField<string>("IP address"),
                                UserName = csv.GetField<string>("User Name"),
                                LastCommunication = LastCom
                            });

                            // _context.Epos.AddRange(lstEpos);
                            nEPO++;
                        }

                        await _context.SaveChangesAsync();
                        Message = "EPO Committed to Database. " +
                            nEPO + " entries Added.";
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("{0} - datetime is not parsed", csv);
                    }
                }
            }
        }

        [Obsolete]
        public async Task OnPostADCommitAsync()
        {
            string filePath = SaveAndGetFilePath();
            if (!Message.Contains("Error!"))
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var ep = new ExcelPackage(stream))
                    {
                        // get the first worksheet
                        ExcelWorkbook wb = ep.Workbook;

                        int iSheetsCount = ep.Workbook.Worksheets.Count;
                        var ws = wb.Worksheets["Users"];
                        // initialize the record counters
                        var nAD = 0;

                        #region Import all CMDB entries
                        // create a list containing all the AD entries already existing
                        // into the Database (it should be empty on first run).
                        var lstAD_Computers = _context.AD_Computers.ToList();
                        var lstAD_Users = _context.AD_Users.ToList();

                        // iterates through all rows, skipping the first one
                        for (int nRow = 2; nRow <= ws.Dimension.Rows; nRow++)
                        {
                            var row = ws.Cells[nRow, 1, nRow, ws.Dimension.End.Column];

                            lstAD_Users.Add(new AD_User
                            {
                                ProgramOffice = row[nRow, 1].GetValue<string>(),
                                CACExemptionReason = row[nRow, 2].GetValue<string>(),
                                SmartCardRequired = row[nRow, 3].GetValue<bool>(),
                                UserEmailAddress = row[nRow, 4].GetValue<string>(),
                                EmployeeType = row[nRow, 5].GetValue<string>(),
                                SAMAccountName = row[nRow, 6].GetValue<string>(),
                                Description = row[nRow, 7].GetValue<string>(),
                                UserPrincipalName = row[nRow, 8].GetValue<string>(),
                                AccountDisabled = row[nRow, 9].GetValue<bool>(),
                                PasswordDoesNotExpire = row[nRow, 10].GetValue<bool>(),
                                PasswordCannotChange = row[nRow, 11].GetValue<bool>(),
                                PasswordExpired = row[nRow, 12].GetValue<bool>(),
                                AccountLockedOut = row[nRow, 13].GetValue<bool>(),
                                CACExtendedInfo = row[nRow, 14].GetValue<string>(),
                                UAC = row[nRow, 15].GetValue<int>(),
                                UserName = row[nRow, 16].GetValue<string>(),
                                DN = row[nRow, 17].GetValue<string>(),
                                Created = row[nRow, 18].GetValue<DateTime>(),
                                Changed = row[nRow, 19].GetValue<DateTime>()
                            });
                            _context.AD_Users.AddRange(lstAD_Users);
                            nAD++;
                        }

                        ws = ep.Workbook.Worksheets["Computers"];

                        // iterates through all rows, skipping the first one
                        for (int nRow = 2; nRow <= ws.Dimension.End.Row; nRow++)
                        {
                            var row = ws.Cells[nRow, 1, nRow, ws.Dimension.End.Column];

                            lstAD_Computers.Add(new AD_Computer
                            {
                                ADComputerName = row[nRow, 2].GetValue<string>(),
                                ProgramOffice = row[nRow, 1].GetValue<string>(),
                                OSType = row[nRow, 3].GetValue<string>(),
                                OSVersion = row[nRow, 4].GetValue<string>(),
                                ServicePack = row[nRow, 5].GetValue<string>(),
                                Created = row[nRow, 6].GetValue<DateTime>(),
                                Changed = row[nRow, 7].GetValue<DateTime>(),
                                UAC = row[nRow, 8].GetValue<int>(),
                                AccountDisabled = row[nRow, 9].GetValue<bool>(),
                                SmartCardRequired = row[nRow, 10].GetValue<bool>(),
                                Description = row[nRow, 11].GetValue<string>(),
                                DN = row[nRow, 12].GetValue<string>(),
                                Win7StatusExtendedinfo = row[nRow, 13].GetValue<string>()
                            });

                            _context.AddRange(lstAD_Computers);
                            nAD++;
                        }
                        await _context.SaveChangesAsync();

                        Message = "AD Committed to Database. " +
                                    nAD + " entries Added.";
                    }
                }
                #endregion
            }
        }

        [Obsolete]
        public async Task OnPostSCCMCommitAsync()
        {            
            string filePath = SaveAndGetFilePath();

            if (!Message.Contains("Error!"))
            {
                using (var streamReader = System.IO.File.OpenText(filePath))
                using (var csv = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.HeaderValidated = null;
                    csv.Configuration.MissingFieldFound = null;

                    for (int i = 0; i < 2; i++) // Skips first 3 rows *blank rows don't count*
                    {
                        csv.Read();
                    }

                    //Reads Header
                    csv.Read();
                    csv.ReadHeader();
                    int nSCCM = 0;

                    while (csv.Read())
                    {
                        //Check if table contains this same computer name. ensuring no duplicate entries. 
                        var sccm = _context.Sccms
                            .Where(s => s.ComputerName == csv.GetField<string>("Details_Table0_ComputerName"))
                            .FirstOrDefault();
                        if (sccm != null)
                            continue;

                        _context.Sccms.Add(new SCCM
                        {
                            ComputerName = csv.GetField<string>("Details_Table0_ComputerName"),
                            DomainWorkGroup = csv.GetField<string>("Details_Table0_DomainWorkgroup"),
                            SiteName = csv.GetField<string>("Details_Table0_SMSSiteName"),
                            TopConsoleUser = csv.GetField<string>("Details_Table0_TopConsoleUser"),
                            OperatingSystem = csv.GetField<string>("Details_Table0_OperatingSystem"),
                            SerialNumber = csv.GetField<string>("Details_Table0_SerialNumber"),
                            AssetTag = csv.GetField<string>("Details_Table0_AssetTag"),
                            Manufacturer = csv.GetField<string>("Details_Table0_Manufacturer"),
                            ReleaseDate = csv.GetField<DateTime>("Release_Date"),
                            BiosVersion = csv.GetField<string>("SMBIOS_Version"),
                            Model = csv.GetField<string>("Details_Table0_Model"),
                            MemoryKBytes = csv.GetField<int>("Details_Table0_MemoryKBytes"),
                            ProcessorGhz = csv.GetField<int>("Details_Table0_ProcessorGHz"),
                            DiskSpaceMB = csv.GetField<int>("Details_Table0_DiskSpaceMB"),
                            FreeDiskSpaceMB = csv.GetField<int>("Details_Table0_FreeDiskSpaceMB")
                        });
                        nSCCM++;
                    }

                    await _context.SaveChangesAsync();
                    Message = "SCCM Committed to Database. " +
                        nSCCM + " entries Added.";
                }
            }

        }

    }

}
