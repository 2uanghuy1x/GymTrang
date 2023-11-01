using GymApi.Models;
using GymTrangPT.Data;
using GymTrangPT.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GymTrangPT.Repository
{
    public class EpisodePackageRepository : IEpisodePackageRepository
    {
        //private readonly IRepository<EpisodePackage> repository;
        private DataContext _context;
        public EpisodePackageRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<EpisodePackage> GetAll(string dataSearch)
        {
            return _context.EpisodePackages
                .Where(e =>  string.IsNullOrWhiteSpace(dataSearch) || e.MaGT.Contains(dataSearch) || e.TenGT.Contains(dataSearch)).ToList();
        }

        public async Task CreateOrEditData(EpisodePackage category)
        {
            if (category.Id == null)
            {
                await CreateData(category);
            }
            else await UpdateData(category);
        }
        private async Task CreateData(EpisodePackage category)
        {
            _context.EpisodePackages.Add(category);
            await _context.SaveChangesAsync();
        }
        private async Task UpdateData(EpisodePackage category)
        {
            var data = _context.EpisodePackages.FirstOrDefault(p => p.Id == category.Id);
            if (data != null)
            {
                data.Id = category.Id;
                data.MaGT = category.MaGT;
                data.TenGT = category.TenGT;
                data.DonGia = category.DonGia;
                data.ThoiGian = category.ThoiGian;
                data.MaNV = category.MaNV;
                data.TrangThai = category.TrangThai;
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteData(int Id)
        {
            var data=  _context.EpisodePackages.FirstOrDefault(p => p.Id == Id);
            if (data != null) {
                _context.EpisodePackages.RemoveRange(data);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception( "Dữ liệu không đã tồn tại");
            }
            
        }

        public ICollection<EpisodePackage> GetAllList()
        {
            return _context.EpisodePackages.ToList();
        }
    }
}
