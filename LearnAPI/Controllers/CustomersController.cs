using ClosedXML.Excel;
using LearnAPI.Models;
using LearnAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Data;

namespace LearnAPI.Controllers
{
    [Authorize]
    [EnableRateLimiting("fixedwindow")]
    //[DisableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CustomersController(ICustomerService customerService, IWebHostEnvironment webHostEnvironment)
        {
            _customerService = customerService;
            _webHostEnvironment = webHostEnvironment;
        }

        // [EnableCors("corspolicy")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var customers = await _customerService.GetAllAsync();
            if (customers is null)
            {
                return NotFound();
            }
            return Ok(customers);
        }

        [DisableRateLimiting]
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer is null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] CustomerModel customer)
        {
            var result = await _customerService.CreateAsync(customer);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomerModel customer, [FromQuery] int id)
        {
            var result = await _customerService.UpdateAsync(customer, id);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] int id)
        {
            var result = await _customerService.RemoveAsync(id);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("ExportExcel")]
        public async Task<IActionResult> ExportExcel()
        {

            try
            {
                string filePath = GetFilePath();
                string excelPath = filePath + "\\customerinfo.xlsx";
                DataTable dt = new();
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Phone", typeof(string));
                dt.Columns.Add("CreditLimit", typeof(int));
                dt.Columns.Add("Code", typeof(string));
                var customers = await _customerService.GetAllAsync();
                if (customers != null && customers.Count > 0)
                {
                    foreach (var item in customers)
                    {
                        dt.Rows.Add(item.Id, item.Name, item.Email, item.Phone, item.CreditLimit, item.Code);
                    }
                }
                using (XLWorkbook wb = new())
                {
                    wb.AddWorksheet(dt, "Customer Info");
                    using (MemoryStream stream = new())
                    {
                        wb.SaveAs(stream);
                        if (!System.IO.File.Exists(excelPath))
                        {
                            System.IO.File.Delete(excelPath);
                        }
                        wb.SaveAs(excelPath);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Customer.xlsx");
                    }
                }

            }
            catch (Exception)
            {

                return NotFound();
            }
            return Ok();
        }

        [NonAction]
        private string GetFilePath()
        {
            return _webHostEnvironment.WebRootPath + "\\Export";
        }
    }
}
