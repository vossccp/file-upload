using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(IFormFile file, [FromForm] string plateNumber)
        {
            if (file == null)
            {
                return BadRequest();
            }
            
            Console.WriteLine($"Plate Number set to {plateNumber}");
            
            var filename = Path.Combine(Environment.CurrentDirectory, file.FileName);
            using (var stream = new FileStream(filename, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            
            Console.WriteLine($"File saved to {filename}");
            
            return Ok();
        }
    }
}