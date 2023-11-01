using GymApi.Models;
using GymTrangPT.Data;
using GymTrangPT.Dto.His;
using GymTrangPT.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymTrangPT.Repository
{
    public class HistoryEPRepository : IHistoryEPRepository
    {
        private DataContext _context;
        public HistoryEPRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateOrEditData(HistoryEP category)
        {

            if (category.Id == null)
            {
                await CreateData(category);
            }
            else await UpdateData(category);
        }
        private async Task CreateData(HistoryEP category)
        {
                _context.HistoryEPs.AddRange(category);
                await _context.SaveChangesAsync();
        }
        private async Task UpdateData(HistoryEP category)
        {
            var data = _context.HistoryEPs.FirstOrDefault(p => p.Id == category.Id);
            if (data != null)
            {
                data.Id = category.Id; 
                data.MaLS = category.MaLS;
                data.MaHV = category.MaHV;
                data.NgayTap = category.NgayTap;
                data.ThoiGian = category.ThoiGian;
                data.GioVao = category.GioVao;
                data.MaPT = category.MaPT;
            }
            await _context.SaveChangesAsync();
           
        }

        public async Task DeleteData(int input)
        {
            var data =  _context.HistoryEPs.FirstOrDefault(p => p.Id == input);
            if (data != null)
            {
                _context.HistoryEPs.RemoveRange(data);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Dữ liệu không đã tồn tại");
            }
        }

        public ICollection<HistoryEPDto> GetAll(string dataSearchEP, string dataSearchCus,DateTime ToDate,DateTime FromDate)
        {
            var data = from his in _context.HistoryEPs
                       join cus in _context.Customers on his.MaHV equals cus.MaHV
                       join ep in _context.EpisodePackages on cus.MaGT equals ep.MaGT
                       where (string.IsNullOrWhiteSpace(dataSearchEP) || ep.MaGT.Contains(dataSearchEP) || ep.TenGT.Contains(dataSearchEP))
                       && (string.IsNullOrWhiteSpace(dataSearchEP) || ep.MaGT.Contains(dataSearchEP) || ep.TenGT.Contains(dataSearchEP))
                       && ( his.NgayTap >= ToDate && his.NgayTap <= FromDate)
                       select new HistoryEPDto
                       {
                           Id= his.Id,
                           MaLS= his.MaLS,
                           MaHV= his.MaHV,
                           HoTen= cus.HoTen,
                           MaGT= cus.MaGT,
                           TenGT= ep.TenGT,
                           NgayTap=his.NgayTap,
                           GioVao=his.GioVao,
                           MaPT=his.MaPT,
                       };
            return data.ToList();
        }

        public ICollection<HistoryEP> GetAllList()
        {
            return _context.HistoryEPs.ToList();
        }
    }
}
