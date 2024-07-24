using LearnAPI.Helper;
using LearnAPI.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace LearnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly LearnDataContext _context;

        public ProductController(IWebHostEnvironment webHostEnvironment, LearnDataContext context)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
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

        [HttpPut("MultiUploadImageToDataBase")]
        public async Task<IActionResult> DataBaseMultiUploadImageAsync(IFormFileCollection formFiles, string productCode)
        {
            int passCount = 0;
            int errorCount = 0;
            APIResponse response = new APIResponse();
            try
            {


                foreach (var file in formFiles)
                {

                    using (MemoryStream stream = new MemoryStream())
                    {
                        await file.CopyToAsync(stream);
                        _context.TblProductImages.Add(new Repos.Models.TblProductImage()
                        {
                            ProductCode = productCode,
                            ProductImage = stream.ToArray()
                        });
                        await _context.SaveChangesAsync();
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

        [HttpGet("GetMultipleImagesfromDataBase")]
        public async Task<IActionResult> GetMultipleImagesfromDataBaseAsync(string productCode)
        {
            List<string> imageUrlList = new();
            try
            {
                
                var productImages = _context.TblProductImages.Where(item => item.ProductCode == productCode);
                if (productImages.Count() > 0 && productImages != null)
                {
                    foreach (var item in productImages)
                    {
                        imageUrlList.Add(Convert.ToBase64String(item.ProductImage));
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

        [HttpGet("DownloadDataBaseImage")]
        public async Task<IActionResult> DownloadDataBaseImageAsync(string productCode)
        {
            try
            {
                var _productImage = await _context.TblProductImages.FirstOrDefaultAsync(item => item.ProductCode == productCode);
                if (_productImage != null)
                {
                    return File(_productImage.ProductImage, "img/png", productCode + ".png");
                }
                //string filePath = GetFilePath(productCode);
                //string imgPath = $"{filePath}\\{productCode}.png";

                //if (System.IO.File.Exists(imgPath))
                //{
                //    MemoryStream stream = new MemoryStream();
                //    using (FileStream fileStream = new FileStream(imgPath, FileMode.Open))
                //    {
                //        await fileStream.CopyToAsync(stream);
                //    }
                //    stream.Position = 0;
                //    return File(stream, "img/png", productCode + ".png");
                //}
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

        [NonAction]
        private string GetFilePath(string productCode)
        {
            return _webHostEnvironment.WebRootPath + "\\Upload\\Products\\" + productCode;
        }
    }
}
