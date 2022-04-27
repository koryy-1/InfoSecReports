using InfoSecReports.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CloudConvert.API;
using CloudConvert.API.Models.ExportOperations;
using CloudConvert.API.Models.ImportOperations;
using CloudConvert.API.Models.JobModels;
using CloudConvert.API.Models.TaskOperations;
using System.Net;
using System.Text;
using Microsoft.Extensions.Logging;

namespace InfoSecReports.Pages.ObjectOfVerifications
{
    public class DetailsModel : PageModel
    {
        private readonly InfoSecReportsContext _context;
        private readonly ILogger<DetailsModel> _logger;
        IWebHostEnvironment _appEnvironment;

        public DetailsModel(InfoSecReportsContext context, IWebHostEnvironment appEnvironment, ILogger<DetailsModel> logger)
        {
            _context = context;
            _appEnvironment = appEnvironment;
            _logger = logger;
        }

        public ObjectOfVerification ObjectOfVerification { get; set; }
        public IList<Event> Event { get; set; }
        public IList<Flaw> Flaw { get; set; }
        public IList<Recomendation> Recomendation{ get; set; }
        public IList<Achievement> Achievement { get; set; }
        public IList<WorkingGroup> WorkingGroup { get; set; }
        public IList<ScriptOfObject> ScriptOfObject { get; set; }
        public IList<Script> Script { get; set; }

        public int EventsCount { get; set; }
        public int FlawsCount { get; set; }
        public int PeopleCount { get; set; }
        [BindProperty]
        public List<string> Events { get; set; }
        [BindProperty]
        public List<string> Flaws { get; set; }
        [BindProperty]
        public string NameOfCompany { get; set; }

        public async Task<IActionResult> OnGetAsync(string id, List<string> eventslist, List<string> flawslist, bool post, bool isdownload)
        {
            
            Events = eventslist;
            Flaws = flawslist;
            NameOfCompany = id;
            if (id == null)
            {
                return NotFound();
            }

            string companyname = Translit(NameOfCompany.ToUpper());
            ObjectOfVerification = await _context.ObjectOfVerification.FirstOrDefaultAsync(m => m.Name == id);
            EventsCount = Events.Count();
            FlawsCount = Flaws.Count();
            Event = _context.Event.ToList();
            Flaw = _context.Flaw.ToList();
            PeopleCount = await _context.WorkingGroup.Where(m => m.NameOfСompany == id).CountAsync();
            string path = "/Files/" + NameOfCompany + ".txt";

            List<string> EventFromDB = new List<string>();
            List<string> FlawFromDB = new List<string>();
            //fix it

            foreach (var item in Event)
            {
                EventFromDB.Add(item.Name);
            }

            foreach(var item in Flaw)
            {
                FlawFromDB.Add(item.Name);
            }

            if (EventsCount == 0 && FlawsCount == 0)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(_appEnvironment.WebRootPath + path, System.Text.Encoding.Default))
                    {
                        var EventsCountT = Int16.Parse(sr.ReadLine());
                        var FlawsCountT = Int16.Parse(sr.ReadLine());
                        EventsCount = EventsCountT;
                        FlawsCount = FlawsCountT;
                        for (var i = 0; i < EventsCountT; i++)
                        {
                            Events.Add(sr.ReadLine());
                            if (EventFromDB.IndexOf(Events[i]) == -1)
                            {
                                Events.Remove(Events[i]);
                                EventsCount -= 1;
                            }
                        }
                        for (var i = 0; i < FlawsCountT; i++)
                        {
                            Flaws.Add(sr.ReadLine());
                            if (FlawFromDB.IndexOf(Flaws[i]) == -1)
                            {
                                Flaws.Remove(Flaws[i]);
                                FlawsCount -= 1;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }


            }
            else
            {
                using (StreamWriter outputFile = new StreamWriter(_appEnvironment.WebRootPath + path))
                {
                    outputFile.WriteLine(EventsCount);
                    outputFile.WriteLine(FlawsCount);
                    foreach (var item in Events)
                    {
                        outputFile.WriteLine(item);
                    }
                    foreach (var item in Flaws)
                    {
                        outputFile.WriteLine(item);
                    }
                }
            }

            if(isdownload) 
            {
                try 
                {
                    string filenametodwnld = "/" + companyname + Events.Count() + Flaws.Count() + ".doc";
                    _logger.LogInformation("Downloading");
                    string file_path = _appEnvironment.ContentRootPath + filenametodwnld;
                    _logger.LogInformation(file_path);
                    System.IO.FileStream fs = System.IO.File.OpenRead(file_path);
                    byte[] data = new byte[fs.Length];
                    int br = fs.Read(data, 0, data.Length);
                    if (br != fs.Length)
                        throw new System.IO.IOException(file_path);
                    byte[] fileBytes = data;
                    return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, file_path);
                }
                catch 
                {
                    _logger.LogInformation("File not found.");
                }
                
            }            
            
            if (post)
            {
                string pathtoreport = "/Reports/" + companyname + Events.Count() + Flaws.Count() + ".txt";
                string filename = companyname + Events.Count() + Flaws.Count() + ".txt";
                
                OnPostAsync(Flaws, Events, companyname, filename, pathtoreport);
            }
            if (ObjectOfVerification == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async void OnPostAsync(List<string> Flaws, List<string> Events, string companyname, string filename, string path)
        {
            
            Event = _context.Event.ToList();
            Flaw = _context.Flaw.ToList();
            //ScriptOfObject = _context.ScriptOfObject.Where(m => m.NameOfCompany == NameOfCompany).ToList();
            Achievement = _context.Achievement.Where(m => m.NameOfСompany == NameOfCompany).ToList();
            Script = _context.Script.ToList();
            ScriptOfObject = _context.ScriptOfObject.Where(m => m.NameOfCompany == NameOfCompany).ToList();
            Recomendation = _context.Recomendation.ToList();
            WorkingGroup = _context.WorkingGroup.Where(m => m.NameOfСompany == NameOfCompany).ToList();
            using (StreamWriter outputFile = new StreamWriter(_appEnvironment.WebRootPath + path))
            {
                outputFile.WriteLine("Отчет.");
                outputFile.WriteLine("Имя организации: " + NameOfCompany);
                outputFile.WriteLine("-------------------------------------------");
                outputFile.WriteLine("Мероприятия по защите.");
                var i = 0;
                var j = 0;
                foreach (var item in Events)
                {
                    foreach (var jitem in Event)
                    {
                        if (item == jitem.Name)
                        {
                            outputFile.WriteLine(i + 1 + ".");
                            outputFile.WriteLine("Имя мероприятия: " + jitem.Name);
                            outputFile.WriteLine("Описание мероприятия: " + jitem.Content);
                            outputFile.WriteLine("Коэффицент значимости: " + jitem.ImportanceFactor);
                            outputFile.WriteLine("Категория: " + jitem.CategoryName);
                            i++;
                        }
                    }

                }
                outputFile.WriteLine("-------------------------------------------");
                outputFile.WriteLine("Недостатки в защите.");

                foreach (var flawsitem in Flaws)
                {
                    foreach (var flawitem in Flaw)
                    {
                        if (flawsitem == flawitem.Name)
                        {
                            outputFile.WriteLine(j + 1 + ".");
                            outputFile.WriteLine("Имя недостатка: " + flawitem.Name);
                            outputFile.WriteLine("Описание недостатка: " + flawitem.Content);
                            outputFile.WriteLine("Коэффициент значимости: " + flawitem.ImportanceFactor);
                            outputFile.WriteLine("Категория: " + flawitem.CategoryName);
                            foreach (var recitem in Recomendation)
                            {
                                if (recitem.Name == flawitem.RecomindationID)
                                {
                                    outputFile.WriteLine("- Рекомедация -");
                                    outputFile.WriteLine("Имя рекомендации: " + recitem.Name);
                                    outputFile.WriteLine("Описание рекомендации: " + recitem.Description);
                                    outputFile.WriteLine("Уровень рекомендации: " + recitem.Level);
                                    outputFile.WriteLine("Категория рекомендации: " + recitem.Category);
                                }
                            }
                            j++;
                        }
                    }
                }
                outputFile.WriteLine("-------------------------------------------");
                outputFile.WriteLine("Достижения.");
                var k = 0;
                foreach (var achitem in Achievement)
                {
                    outputFile.WriteLine(k + 1 + ".");
                    outputFile.WriteLine("Имя достижения: " + achitem.Name);
                    outputFile.WriteLine("Описание: " + achitem.Description);
                    outputFile.WriteLine("Адрес узла: " + achitem.NodeAdress);
                    outputFile.WriteLine("Дата аутентификации: " + achitem.AuthData);
                    outputFile.WriteLine("Путь: " + achitem.Path);
                    k++;
                }
                outputFile.WriteLine("-------------------------------------------");
                outputFile.WriteLine("Сценарии проверки.");
                var n = 0;
                foreach (var scrobjitem in ScriptOfObject) 
                {
                    foreach (var scritem in Script) 
                    {
                        if (scritem.Name == scrobjitem.NameOfScript)
                        {
                            outputFile.WriteLine(n + 1 + ".");
                            outputFile.WriteLine("Имя сценария: " + scritem.Name);
                            outputFile.WriteLine("Содержание:" + scritem.Content);
                            n++;
                        }
                    }
                }
                outputFile.WriteLine("-------------------------------------------");
                outputFile.WriteLine("Состав рабочей группы");
                var m = 0;
                foreach (var wgitem in WorkingGroup) 
                {
                    outputFile.WriteLine(m + 1 + "." + " ФИО: " + wgitem.Member);
                }
            }
            _logger.LogInformation(filename);
            await Convertation(filename, path);
        }
        
        public string api_key { get; set; }
        [BindProperty]
        public string downloadurl { get; set; }
        public async Task<IActionResult> Convertation(string name, string pathtofile)
        {
            using (StreamReader sr = new StreamReader(_appEnvironment.WebRootPath + "/apikey.txt", System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    api_key += line;
                }
            }
            var _cloudConvert = new CloudConvertAPI(api_key);

            var job = await _cloudConvert.CreateJobAsync(new JobCreateRequest
            {
                Tasks = new
                {
                    import = new ImportUploadCreateRequest(),
                    convert = new ConvertCreateRequest
                    {
                        Input = "import",
                        Input_Format = "txt",
                        Output_Format = "doc"
                    },
                    export = new ExportUrlCreateRequest
                    {
                        Input = "convert",
                        Archive_Multiple_Files = true
                    }
                },
                Tag = "Test"
            });
            _logger.LogInformation(name);
            _logger.LogInformation(pathtofile);
            
            var uploadTask = job.Data.Tasks.FirstOrDefault(t => t.Name == "import");
            byte[] file = await System.IO.File.ReadAllBytesAsync(_appEnvironment.WebRootPath + pathtofile);
            string fileName = name;
            await _cloudConvert.UploadAsync(uploadTask.Result.Form.Url.ToString(), file, fileName, uploadTask.Result.Form.Parameters); 
            job = await _cloudConvert.WaitJobAsync(job.Data.Id); // Wait for job completion
            var exportTask = job.Data.Tasks.FirstOrDefault(t => t.Name == "export");
            var fileExport = exportTask.Result.Files.FirstOrDefault(t => true);
            _logger.LogInformation(fileExport.Url.ToString());
            downloadurl = fileExport.Url.ToString();
            using (var client = new WebClient()) client.DownloadFile(fileExport.Url, fileExport.Filename);  
            return Page();
        }
        
        public string Translit(string s)
        {
            StringBuilder ret = new StringBuilder();
            string[] rus = { "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й",
                    "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц",   
                    "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я" };
            string[] eng = { "A", "B", "V", "G", "D", "E", "E", "ZH", "Z", "I", "Y", 
                    "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "F", "KH", "TS",   
                    "CH", "SH", "SHCH", null, "Y", null, "E", "YU", "YA" };

            for (int j = 0; j < s.Length; j++)
            for (int i = 0; i < rus.Length; i++)
            if (s.Substring(j, 1) == rus[i]) ret.Append(eng[i]);
            return ret.ToString();
        }

    }
}
