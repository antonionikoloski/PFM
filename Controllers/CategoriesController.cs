
using System.Globalization;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using pfm.Commands;
using pfm.Models;
using pfm.Services;


namespace pfm.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{
  

    private readonly ILogger<CategoriesController> _logger;
    private readonly ICategoryService _categoryService;

    public CategoriesController (ILogger<CategoriesController> logger,ICategoryService pfm)
    {
        _logger = logger;
        _categoryService=pfm;
    }
    
      [HttpPost]
        public async Task<IActionResult> CreateCategories(IFormFile file,[FromServices] IWebHostEnvironment hostingEnvironment)
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
          
                
  

           
                 var result=await _categoryService.Create(commands);
               
                if(result.Count==0)
                {
                    return BadRequest("No categories created");
                }
                else
                {
                    return Ok();
                }
               
           
           
           
        }
       private List<CreateCategoryCommand> GetCommands(string filename)
       {
           var commands = new List<CreateCategoryCommand>();
           #region  ReadingCsv
           var path =$"{filename}";
           using (var reader =new StreamReader(path))
           using (var csv=new CsvReader(reader,CultureInfo.InvariantCulture))
           {
            
              csv.Read();
              csv.ReadHeader();
              while(csv.Read())
              {
                var com=csv.GetRecord<CreateCategoryCommand>();
                commands.Add(com);
              }
           }
              #endregion
           return commands;
       }
         [HttpGet("Analytical-View")]
        public async Task<IActionResult> GetAnalysis( string  catcode,  string sd,  string ed,  string direction )
        {
          
            
            var result = await _categoryService.GetAnalysis(catcode, sd, ed, direction);
            return Ok(result);
        }

 
}