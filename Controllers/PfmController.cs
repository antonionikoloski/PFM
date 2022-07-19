using System.Globalization;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using pfm.Commands;
using pfm.Services;

namespace pfm.Controllers;

[ApiController]
[Route("[controller]")]
public class PfmController : ControllerBase
{
  

    private readonly ILogger<PfmController> _logger;
    private readonly IPfmService _PfmService;

    public PfmController (ILogger<PfmController> logger,IPfmService pfm)
    {
        _logger = logger;
        _PfmService=pfm;
    }
    
      [HttpPost]
        public async Task<IActionResult> CreateTransaction(IFormFile file,[FromServices] IWebHostEnvironment hostingEnvironment)
        {

               #region UploadCsv
               string filename= $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
               using (FileStream fs = System.IO.File.Create(filename))
               {
                   file.CopyTo(fs);
                   fs.Flush();
               }
               var commands=this.GetCommands(filename);
               #endregion


           
                 var result=await _PfmService.CreateTransaction(commands);
                    
                
               
           
           return Ok();
           
        }
       private List<CreateTransactionCommand> GetCommands(string filename)
       {
           var commands = new List<CreateTransactionCommand>();
           #region  ReadingCsv
           var path =$"{filename}";
           using (var reader =new StreamReader(path))
           using (var csv=new CsvReader(reader,CultureInfo.InvariantCulture))
           {
            
              csv.Read();
              csv.ReadHeader();
              while(csv.Read())
              {
                var com=csv.GetRecord<CreateTransactionCommand>();
                commands.Add(com);
              }
           }
              #endregion
           return commands;
       }
    
 
}
