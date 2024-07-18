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

        [HttpPut("UploadImage")]
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

        [HttpPut("MultiUploadImage")]
        public async Task<IActionResult> MultiUploadImageAsync(IFormFileCollection formFiles, string productCode)
        {
            int passCount = 0;
            int errorCount = 0;
            APIResponse response = new APIResponse();
            try
            {

                string filePath = GetFilePath(productCode);
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                foreach (var file in formFiles)
                {
                    string imgPath = filePath + "\\" + productCode + file.FileName;
                    if (System.IO.File.Exists(imgPath))
                    {
                        System.IO.File.Delete(imgPath);
                    }
                    using (FileStream fileStream = System.IO.File.Create(imgPath))
                    {
                        await file.CopyToAsync(fileStream);
                        passCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                errorCount++;
                response.ErrorMessage = ex.Message;
            }
            response.ResponseCode = 200;
            response.Result = passCount + " Files uploaded & " + errorCount + " files failed";
            return Ok(response);
        }

        [HttpGet("GetImage")]
        public async Task<IActionResult> GetImageAsync(string productCode)
        {
            string imageUrl = string.Empty;
            try
            {
                string filePath = GetFilePath(productCode);
                string imgPath = $"{filePath}\\{productCode}.png";
                string hostUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                if (System.IO.File.Exists(imgPath))
                {
                    imageUrl = $"{hostUrl}/Upload/products/{productCode}/{productCode}.png";
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {

                throw;
            }
            return Ok(imageUrl);
        }

        [HttpGet("GetMultipleImages")]
        public async Task<IActionResult> GetMultipleImagesAsync(string productCode)
        {
            List<string> imageUrlList = new();
            try
            {
                string hostUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                string filePath = GetFilePath(productCode);
                if (System.IO.Directory.Exists(filePath))
                {
                    DirectoryInfo dir = new DirectoryInfo(filePath);
                    FileInfo[] fileInfos = dir.GetFiles();
                    foreach (FileInfo fileInfo in fileInfos)
                    {
                        // imageUrl.Add(fileInfo.FullName);
                        string fileName = fileInfo.Name;
                        string imgPath = $"{filePath}\\{fileName}";
                        if (System.IO.File.Exists(imgPath))
                        {
                            string imageUrl = $"{hostUrl}/Upload/products/{productCode}/{fileName}";
                            imageUrlList.Add(imageUrl);
                        }
                    }
                }




                else
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {

                throw;
            }
            return Ok(imageUrlList);
        }

        [HttpGet("DownloadImage")]
        public async Task<IActionResult> DownloadImageAsync(string productCode)
        {
            //string imageUrl = string.Empty;
            //string hostUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            try
            {
                string filePath = GetFilePath(productCode);
                string imgPath = $"{filePath}\\{productCode}.png";

                if (System.IO.File.Exists(imgPath))
                {
                    MemoryStream stream = new MemoryStream();
                    using (FileStream fileStream = new FileStream(imgPath, FileMode.Open))
                    {
                        await fileStream.CopyToAsync(stream);
                    }
                    stream.Position = 0;
                    return File(stream, "img/png", productCode + ".png");
                    // imageUrl = $"{hostUrl}/Upload/products/{productCode}/{productCode}.png";
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        [HttpDelete("RemoveImage")]
        public async Task<IActionResult> RemoveImageAsync(string productCode)
        {
            //string imageUrl = string.Empty;
            //string hostUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            try
            {
                string filePath = GetFilePath(productCode);
                string imgPath = $"{filePath}\\{productCode}.png";

                if (System.IO.File.Exists(imgPath))
                {
                    System.IO.File.Delete(imgPath);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        [HttpDelete("RemoveMultipleImages")]
        public async Task<IActionResult> RemoveMultipleImagesAsync(string productCode)
        {
            //string imageUrl = string.Empty;
            //string hostUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            try
            {
                string filePath = GetFilePath(productCode);
                if (System.IO.Directory.Exists(filePath))
                {
                    DirectoryInfo dir = new DirectoryInfo(filePath);
                    FileInfo[] fileInfos = dir.GetFiles();
                    foreach (FileInfo fileInfo in fileInfos)
                    {
                        fileInfo.Delete();
                        return Ok();
                    }
                }
                else
                {

                    return NotFound();
                }

            }
            catch (Exception)
            {

                return NotFound();
            }
            return Ok();
        }

        [NonAction]
        private string GetFilePath(string productCode)
        {
            return _webHostEnvironment.WebRootPath + "\\Upload\\Products\\" + productCode;
        }
    }
}
