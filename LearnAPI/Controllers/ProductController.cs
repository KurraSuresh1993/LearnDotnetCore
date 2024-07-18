using LearnAPI.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPut]
        public async Task<IActionResult> UploadImageAsync(IFormFile formFile, string productCode)
        {
            APIResponse response = new APIResponse();
            try
            {
                string filePath = GetFilePath(productCode);
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string imgPath = filePath + "\\" + productCode + ".png";
                if (System.IO.File.Exists(imgPath))
                {
                    System.IO.File.Delete(imgPath);
                }
                using (FileStream fileStream = System.IO.File.Create(imgPath))
                {
                    await formFile.CopyToAsync(fileStream);
                    response.ResponseCode = 200;
                    response.Result = "Success";
                }
            }
            catch (Exception ex)
            {

                response.ErrorMessage = ex.Message;
            }
            return Ok(response);
        }

        [NonAction]
        private string GetFilePath(string productCode)
        {
            return _webHostEnvironment.WebRootPath + "\\Upload\\Products\\" + productCode;
        }
    }
}
