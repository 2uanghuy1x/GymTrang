using GymApi.Models;
using GymTrangPT.Data;
using GymTrangPT.Dto;
using GymTrangPT.Interfaces;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;

namespace GymTrangPT.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private DataContext _context;
        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateOrEditData(Customer category)
        {
            if (category.Id == null)
            {
                await CreateData(category);
            }
            else await UpdateData(category);
        }

        private async Task CreateData(Customer category)
        {
            _context.Customers.Add(category);
            await _context.SaveChangesAsync();
        }
        private async Task UpdateData(Customer category)
        {
            var data = _context.Customers.FirstOrDefault(p => p.Id == category.Id);
            if (data != null)
            {
                data.Id = category.Id;
                data.MaHV = category.MaHV;
                data.HoTen = category.HoTen;
                data.GioiTinh = category.GioiTinh;
                data.NgaySinh = category.NgaySinh;
                data.DiaChi = category.DiaChi;
                data.SDT = category.SDT;
                data.MaGT = category.MaGT;
                data.NgayDK = category.NgayDK;
                data.NgayHH = category.NgayHH;
                data.MaNV = category.MaNV;
                data.TrangThai = category.TrangThai;


               // _context.Customers.UpdateRange(category);
                await _context.SaveChangesAsync();
            }
        }

        public async  Task DeleteData(int input)
        {
            var data =  _context.Customers.FirstOrDefault(p => p.Id == input);
            if (data != null)
            {
                _context.Customers.RemoveRange(data);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Dữ liệu không đã tồn tại");
            }
        }

        public ICollection<Customer> GetAll(string dataSearch)
        {
            return _context.Customers
                .Where(e => 
                string.IsNullOrWhiteSpace(dataSearch) || e.MaHV.Contains(dataSearch) 
                || e.HoTen.Contains(dataSearch)|| e.SDT.Contains(dataSearch)).ToList();
        }

        public ICollection<Customer> GetAllList()
        {
            return _context.Customers.ToList();
        }

    }
}
