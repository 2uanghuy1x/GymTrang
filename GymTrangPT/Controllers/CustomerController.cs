using AutoMapper;
using GymApi.Models;
using GymTrangPT.Dto;
using GymTrangPT.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using PagedList;
using System.Drawing;

namespace GymTrangPT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll(string? dataSearch, int? pageIndex, int? pageSize)
        {
            if (pageIndex == null)
            {
                pageIndex = 1;
            }
            if (pageSize == null)
            {
                pageSize = 1;
            }
            var data = _mapper.Map<List<Customer>>(_customerRepository.GetAll(dataSearch));
            var dataPage = data.ToPagedList((int)pageIndex, (int)pageSize);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(dataPage);
        }

        [HttpPost("CreateOrEdit")]
        public IActionResult CreateOrEdit([FromBody] CustomerDto categoryCreate)
        {
            if (categoryCreate == null)
                return BadRequest(ModelState);

            var category = _customerRepository.GetAllList()
                .Where(c => c.MaNV.Trim().ToUpper() == categoryCreate.MaNV.TrimEnd().ToUpper())
                .FirstOrDefault();

            //if (category != null)
            //{
            //    ModelState.AddModelError("", "Category already exists");
            //    return StatusCode(422, ModelState);
            //}

            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //var categoryMap = _mapper.Map<Customer>(categoryCreate);
            Customer data = new Customer()
            {
                Id= categoryCreate.Id,
                MaHV = categoryCreate.MaHV,
                HoTen = categoryCreate.HoTen,
                GioiTinh = categoryCreate.GioiTinh,
                NgaySinh = categoryCreate.NgaySinh,
                DiaChi = categoryCreate.DiaChi,
                SDT = categoryCreate.SDT,
                MaGT = categoryCreate.MaGT,
                NgayDK = categoryCreate.NgayDK,
                NgayHH = categoryCreate.NgayHH,
                MaNV = categoryCreate.MaNV,
                TrangThai = categoryCreate.TrangThai,

            };
            _customerRepository.CreateOrEditData(data);


            return Ok("Successfully created");
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteData(int id)
        {
            _customerRepository.DeleteData(id);
            return Ok("Successfully deleted");
        }

        [HttpGet("export")]
        public IActionResult ExportExcelFromTemplate(string? dataSearch)
        {
            string templatePath = "ExcelTemplate/Customer.xlsx";
            string outputPath = "path_to_output_file.xlsx";

            // Copy the template file to the output file
            System.IO.File.Copy(templatePath, outputPath, true);
            var data = _mapper.Map<List<Customer>>(_customerRepository.GetAll(dataSearch));
            int stt = 0;
            int startRow = 2;

            using (var package = new ExcelPackage(new FileInfo(outputPath)))
            {
                var worksheet = package.Workbook.Worksheets["Sheet1"];
                if (data != null)
                {
                    var dataRange = worksheet.Cells[$"A2:L{data.Count() + startRow -1}"];
                    dataRange.Style.WrapText = true;
                    dataRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    dataRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    dataRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    dataRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    dataRange.Style.Border.Top.Color.SetColor(Color.Black);
                    dataRange.Style.Border.Bottom.Color.SetColor(Color.Black);
                    dataRange.Style.Border.Left.Color.SetColor(Color.Black);
                    dataRange.Style.Border.Right.Color.SetColor(Color.Black);
                    foreach (var item in data)
                    {
                        worksheet.Cells[startRow + stt, 1].Value = stt + 1;
                        worksheet.Cells[startRow + stt, 2].Value = item.MaHV;
                        worksheet.Cells[startRow + stt, 3].Value = item.HoTen;
                        worksheet.Cells[startRow + stt, 4].Value = item.GioiTinh == true ? "Nam" :"Nữ";
                        worksheet.Cells[startRow + stt, 5].Value = item.NgaySinh;
                        worksheet.Cells[startRow + stt, 6].Value = item.DiaChi;
                        worksheet.Cells[startRow + stt, 7].Value = item.SDT;
                        worksheet.Cells[startRow + stt, 8].Value = item.MaGT;
                        worksheet.Cells[startRow + stt, 9].Value = item.NgayDK;
                        worksheet.Cells[startRow + stt, 10].Value = item.NgayHH;
                        worksheet.Cells[startRow + stt, 11].Value = item.MaNV;
                        worksheet.Cells[startRow + stt, 12].Value = item.TrangThai == true ?" Hoạt động" : " Không Hoạt động";
                        stt++;
                    }
                    package.Save();
                }
            }

            byte[] fileBytes = System.IO.File.ReadAllBytes(outputPath);
            System.IO.File.Delete(outputPath);

            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "output_file.xlsx");
        }
    } 
}
