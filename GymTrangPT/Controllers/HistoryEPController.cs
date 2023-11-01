using AutoMapper;
using GymApi.Models;
using GymTrangPT.Dto;
using GymTrangPT.Dto.His;
using GymTrangPT.Interfaces;
using GymTrangPT.Repository;
using Microsoft.AspNetCore.Mvc;
using PagedList;

namespace GymTrangPT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryEPController : Controller
    {
        private readonly IHistoryEPRepository _historyEPRepository  ;
        private readonly IMapper _mapper;

        public HistoryEPController(IHistoryEPRepository historyEPRepository, IMapper mapper)
        {
            _historyEPRepository = historyEPRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll(string? dataSearchEP, string? dataSearchCus, DateTime ToDate, DateTime FromDate, int? pageIndex, int? pageSize)
        {
            if (pageIndex == null)
            {
                pageIndex = 1;
            }
            if (pageSize == null)
            {
                pageSize = 1;
            }
            var data = _mapper.Map<List<HistoryEPDto>>(_historyEPRepository.GetAll(dataSearchEP, dataSearchCus, ToDate, FromDate));
            var dataPage = data.ToPagedList((int)pageIndex, (int)pageSize);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(dataPage);
        }

        [HttpPost("CreateOrEdit")]
        public IActionResult CreateOrEdit([FromBody] HistoryEPData categoryCreate)
        {
            if (categoryCreate == null)
                return BadRequest(ModelState);

            var category = _historyEPRepository.GetAllList()
                .Where(c => c.MaLS == categoryCreate.MaLS)
                .FirstOrDefault();

            if (category != null)
            {
                ModelState.AddModelError("", "Category already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            HistoryEP data = new HistoryEP()
            {
                Id = categoryCreate.Id, 
                MaLS = categoryCreate.MaLS,
                MaHV = categoryCreate.MaHV,
                NgayTap = categoryCreate.NgayTap,
                ThoiGian = categoryCreate.ThoiGian,
                GioVao = categoryCreate.GioVao,
                MaPT = categoryCreate.MaPT,
            };
            _historyEPRepository.CreateOrEditData(data);


            return Ok("Successfully created");
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteData(int id)
        {
            _historyEPRepository.DeleteData(id);
            return Ok("Successfully deleted");
        }
    }
}
