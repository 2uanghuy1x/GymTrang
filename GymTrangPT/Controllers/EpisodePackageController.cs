using AutoMapper;
using GymApi.Models;
using GymTrangPT.Dto;
using GymTrangPT.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PagedList;

namespace GymTrangPT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodePackageController : Controller
    {
        private readonly IEpisodePackageRepository _episodePackageRepository;
        private readonly IMapper _mapper;

        public EpisodePackageController(IEpisodePackageRepository episodePackageRepository, IMapper mapper)
        {
            _episodePackageRepository = episodePackageRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll(string? dataSearch,int? pageIndex,int?pageSize)
        {
            if(pageIndex == null)
            {
                pageIndex = 1;
            }
            if(pageSize == null)
            {
                pageSize = 1;
            }
            var data = _mapper.Map<List<EpisodePackageDto>>(_episodePackageRepository.GetAll(dataSearch));
            var dataPage = data.ToPagedList((int)pageIndex, (int)pageSize);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(dataPage);
        }

        [HttpPost("CreateOrEdit")]
        public IActionResult CreateOrEdit([FromBody] EpisodePackageDto categoryCreate)
        {
            if (categoryCreate == null)
                return BadRequest(ModelState);

            var category = _episodePackageRepository.GetAllList()
                .Where(c => c.MaNV.Trim().ToUpper() == categoryCreate.MaNV.TrimEnd().ToUpper())
                .FirstOrDefault();

            //if (category != null)
            //{
            //    ModelState.AddModelError("", "Category already exists");
            //    return StatusCode(422, ModelState);
            //}

            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //var categoryMap = _mapper.Map<EpisodePackage>(categoryCreate);
            EpisodePackage data = new EpisodePackage()
            {
                Id = categoryCreate.Id,
                MaGT = categoryCreate.MaGT,
                TenGT = categoryCreate.TenGT,
                DonGia = categoryCreate.DonGia,
                ThoiGian = categoryCreate.ThoiGian,
                MaNV = categoryCreate.MaNV,
                TrangThai = categoryCreate.TrangThai,
            };
            _episodePackageRepository.CreateOrEditData(data);
           

            return Ok("Successfully created");
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteData(int id)
        {
            _episodePackageRepository.DeleteData(id);
            return Ok("Successfully deleted");
        }
    }
}
