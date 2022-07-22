using System.Globalization;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using pfm.Commands;
using pfm.Models;
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
                    
                if(result.Count==0)
                {
                    return BadRequest("No transactions created");
                }
                else
                {
                    return Ok(result);
                }
               
           
           
           
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
        [HttpPost("transactionid")]
        public async Task<IActionResult> CategorizeTransaction( [FromQuery] int transactionid, [FromQuery] string namecategory)
        {
                var result = await _PfmService.CategorizeTransaction(transactionid,namecategory);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
      [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] int? page, [FromQuery] int? pageSize, [FromQuery] string sortBy, [FromQuery] SortOrder sortOrder )
        {
            page = page ?? 1;
            pageSize = pageSize ?? 10;
            _logger.LogInformation("Returning {page}. page of products", page);
            var result = await _PfmService.GetTransactions(page.Value, pageSize.Value, sortBy, sortOrder);
            return Ok(result);
        }


       
}
