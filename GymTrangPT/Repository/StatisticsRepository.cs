using GymApi.Models;
using GymTrangPT.Data;
using GymTrangPT.Dto.Bill;
using GymTrangPT.Dto.His;
using GymTrangPT.Interfaces;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;

namespace GymTrangPT.Repository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private DataContext _context;
        public StatisticsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateOrEditData(Bill category)
        {
            if (category.Id == null)
            {
                await CreateData(category);
            }
            else await UpdateData(category);
        }
        private async Task CreateData(Bill category)
        {
                _context.Bills.AddRange(category);
                await _context.SaveChangesAsync();
        }
        private async Task UpdateData(Bill category)
        {

            var data = _context.Bills.FirstOrDefault(e => e.Id == category.Id);
            if (data != null)
            {
                data.Id = category.Id;
                data.MaHD = category.MaHD;
                data.MaGT = category.MaGT;
                data.MaHV = category.MaHV;
                data.HoTen = category.HoTen;
                data.NgayMua = category.NgayMua;
                data.DonGia = category.DonGia;
                data.MaNV = category.MaNV;
                await _context.SaveChangesAsync();
            }

        }

        public async Task DeleteData(int input)
        {
            var data =  _context.Bills.FirstOrDefault(p => p.Id == input);
            if (data != null)
            {
                _context.Bills.RemoveRange(data);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Dữ liệu không đã tồn tại");
            }
        }

        public ICollection<BillDto> GetAll(int year)
        {
            var data = from bi in _context.Bills
                       join ep in _context.EpisodePackages on bi.MaGT equals ep.MaGT
                       where bi.NgayMua.Year == year
                       select new BillDto
                       {
                           Id = bi.Id,
                           MaGT= bi.MaGT,
                           TenGT= ep.TenGT,
                       };
            return data.ToList();
            //return _context.Bills.Where(e=> e.NgayMua >= ToDate && e.NgayMua <=FromDate).ToList();
        }

        public ICollection<Bill> GetAllList()
        {
            return _context.Bills.ToList();
        }
    }
}
