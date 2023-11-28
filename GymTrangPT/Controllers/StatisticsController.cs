using AutoMapper;
using GymApi.Models;
using GymTrangPT.Dto;
using GymTrangPT.Dto.Bill;
using GymTrangPT.Interfaces;
using GymTrangPT.Repository;
using Microsoft.AspNetCore.Mvc;
using PagedList;

namespace GymTrangPT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : Controller
    {
        private readonly IStatisticsRepository _statisticsRepository;
        private readonly IMapper _mapper;

        public StatisticsController(IStatisticsRepository statisticsRepository, IMapper mapper)
        {
            _statisticsRepository = statisticsRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll(int year)
        {
            //if (pageIndex == null)
            //{
            //    pageIndex = 1;
            //}
            //if (pageSize == null)
            //{
            //    pageSize = 1;
            //}
            //var data = _mapper.Map<List<Customer>>(_statisticsRepository.GetAll(ToDate, FromDate));
            var data =  _statisticsRepository.GetAll(year);
            //var dataPage = data.ToPagedList((int)pageIndex, (int)pageSize);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(data);
        }

        [HttpPost("CreateOrEdit")]
        public IActionResult CreateOrEdit([FromBody] CreateOrEditBill categoryCreate)
        {
            if (categoryCreate == null)
                return BadRequest(ModelState);

            //var category = _statisticsRepository.GetAllList()
            //    .Where(c => c.MaNV.Trim().ToUpper() == categoryCreate.MaNV.TrimEnd().ToUpper())
            //    .FirstOrDefault();

            //if (category != null)
            //{
            //    ModelState.AddModelError("", "Category already exists");
            //    return StatusCode(422, ModelState);
            //}

            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            Bill data = new Bill()
            {
                Id = categoryCreate.Id,
                MaHD = categoryCreate.MaHD,
                MaGT = categoryCreate.MaGT,
                MaHV = categoryCreate.MaHV,
                HoTen = categoryCreate.HoTen,
                NgayMua = categoryCreate.NgayMua,
                DonGia = categoryCreate.DonGia,
                MaNV = categoryCreate.MaNV,
            };
            _statisticsRepository.CreateOrEditData(data);


            return Ok("Successfully created");
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteData(int id)
        {
            _statisticsRepository.DeleteData(id);
            return Ok("Successfully deleted");
        }
    }
}
