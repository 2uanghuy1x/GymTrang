using GymApi.Models;
using GymTrangPT.Data;
namespace GymTrangPT
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.Staffs.Any())
            {
                var Staffs = new List<Staff>()
                {
                    new Staff()
                    {
                       MaNV="NV001",
                       NgaySinh=new DateTime(1903,1,1),
                       HoTen = "Nguyen Quoc Hung",
                       GioiTinh = true,
                       DiaChi ="Cau Giay Hoang Ha",
                       SDT="0947258147",
                       VaiTro= true,
                       MatKhau ="456789asd",
                       TrangThai = true,
                    },
 new Staff()
{
    MaNV = "NV002",
    NgaySinh = new DateTime(1990, 5, 10),
    HoTen = "Tran Thi Anh",
    GioiTinh = false,
    DiaChi = "Ba Dinh, Ha Noi",
    SDT = "0987654321",
    VaiTro = false,
    MatKhau = "123456abc",
    TrangThai = true
},
  new Staff()
{

    MaNV = "NV003",
    NgaySinh = new DateTime(1985, 12, 20),
    HoTen = "Le Van Tuan",
    GioiTinh = true,
    DiaChi = "Hoan Kiem, Ha Noi",
    SDT = "0912345678",
    VaiTro = false,
    MatKhau = "qwerty123",
    TrangThai = true
},

 new Staff()
{

    MaNV = "NV004",
    NgaySinh = new DateTime(1995, 3, 25),
    HoTen = "Pham Thi Binh",
    GioiTinh = false,
    DiaChi = "Thanh Xuan, Ha Noi",
    SDT = "0876543210",
    VaiTro = true,
    MatKhau = "abc123xyz",
    TrangThai = true
},

                new Staff()
                {
                    MaNV = "NV005",
                    NgaySinh = new DateTime(1988, 8, 8),
                    HoTen = "Nguyen Van Hieu",
                    GioiTinh = true,
                    DiaChi = "Hai Ba Trung, Ha Noi",
                    SDT = "0965432109",
                    VaiTro = true,
                    MatKhau = "password123",
                    TrangThai = true
                },

            };
                dataContext.Staffs.AddRange(Staffs);
                dataContext.SaveChanges();
            }

            if (!dataContext.Bills.Any())
            {
                var billList = new List<Bill>()
               {
                   new Bill()
                {

                    MaHD = "HD001",
                    MaGT = "GT001",
                    MaHV = "HV001",
                    HoTen = "Nguyen Van A",
                    NgayMua = DateTime.Now,
                    DonGia = 100.5m,
                    MaNV = "NV001"
                },

                new Bill()
                {

                    MaHD = "HD002",
                    MaGT = "GT002",
                    MaHV = "HV002",
                    HoTen = "Tran Thi B",
                    NgayMua = DateTime.Now.AddDays(-1),
                    DonGia = 75.25m,
                    MaNV = "NV002"
                },

                new Bill()
                {

                    MaHD = "HD003",
                    MaGT = "GT003",
                    MaHV = "HV003",
                    HoTen = "Le Van C",
                    NgayMua = DateTime.Now.AddDays(-2),
                    DonGia = 50.75m,
                    MaNV = "NV003"
                },
            };


                dataContext.Bills.AddRange(billList);
                dataContext.SaveChanges();
            }

            if (!dataContext.Customers.Any())
            {
                var customerList = new List<Customer>()
                {
                     new Customer()
                {

                    MaHV = "HV001",
                    HoTen = "Nguyen Van A",
                    GioiTinh = true,
                    NgaySinh = new DateTime(1990, 5, 10),
                    DiaChi = "Cau Giay, Ha Noi",
                    SDT = "0947258147",
                    MaGT = "GT001",
                    NgayDK = DateTime.Now,
                    NgayHH = DateTime.Now.AddYears(1),
                    MaNV = "NV001",
                    TrangThai = true
                },
                new Customer()
                {

                    MaHV = "HV002",
                    HoTen = "Tran Thi B",
                    GioiTinh = false,
                    NgaySinh = new DateTime(1985, 12, 20),
                    DiaChi = "Ba Dinh, Ha Noi",
                    SDT = "0987654321",
                    MaGT = "GT002",
                    NgayDK = DateTime.Now,
                    NgayHH = DateTime.Now.AddYears(2),
                    MaNV = "NV002",
                    TrangThai = true
                },
                new Customer()
                {

                    MaHV = "HV003",
                    HoTen = "Le Van C",
                    GioiTinh = true,
                    NgaySinh = new DateTime(1995, 3, 25),
                    DiaChi = "Hoan Kiem, Ha Noi",
                    SDT = "0912345678",
                    MaGT = "GT003",
                    NgayDK = DateTime.Now,
                    NgayHH = DateTime.Now.AddYears(3),
                    MaNV = "NV003",
                    TrangThai = true
                },
                };


                dataContext.Customers.AddRange(customerList);
                dataContext.SaveChanges();
            }

            if (!dataContext.EpisodePackages.Any())
            {
                var episodePackageList = new List<EpisodePackage>()
                {
                     new EpisodePackage()
                {

                    MaGT = "GT001",
                    TenGT = "Giai Tri 1",
                    DonGia = 50.0m,
                    ThoiGian = 60,
                    MaNV = "NV001",
                    TrangThai = true
                },

                 new EpisodePackage()
                {

                    MaGT = "GT002",
                    TenGT = "Giai Tri 2",
                    DonGia = 75.0m,
                    ThoiGian = 90,
                    MaNV = "NV002",
                    TrangThai = true
                },

                 new EpisodePackage()
                {

                    MaGT = "GT003",
                    TenGT = "Giai Tri 3",
                    DonGia = 100.0m,
                    ThoiGian = 120,
                    MaNV = "NV003",
                    TrangThai = true
                },
                };


                dataContext.EpisodePackages.AddRange(episodePackageList);
                dataContext.SaveChanges();
            }

            if (!dataContext.HistoryEPs.Any())
            {
                var historyEPList = new List<HistoryEP>()
                {
                    new HistoryEP()
                {

                    MaLS = 1,
                    MaHV = "HV001",
                    NgayTap = DateTime.Now.Date,
                    ThoiGian = 60,
                    GioVao = "08:00",
                    MaPT = "PT001"
                },

                new HistoryEP()
                {

                    MaLS = 2,
                    MaHV = "HV002",
                    NgayTap = DateTime.Now.Date.AddDays(-1),
                    ThoiGian = 90,
                    GioVao = "09:30",
                    MaPT = "PT002"
                },

                new HistoryEP()
                {

                    MaLS = 3,
                    MaHV = "HV003",
                    NgayTap = DateTime.Now.Date.AddDays(-2),
                    ThoiGian = 120,
                    GioVao = "10:15",
                    MaPT = "PT003"
                },
            };
                dataContext.HistoryEPs.AddRange(historyEPList);
                dataContext.SaveChanges();
            }

            if (!dataContext.Pts.Any())
            {
                List<Pt> ptList = new List<Pt>()
                {
                    new Pt()
                {

                    MaPT = "PT001",
                    HoTen = "Tran Van A",
                    GioiTinh = true,
                    NgaySinh = new DateTime(1990, 5, 10),
                    DiaChi = "Cau Giay, Ha Noi",
                    SDT = "0947258147",
                    MaNV = "NV001",
                    TrangThai = true
                },

                new Pt()
                {

                    MaPT = "PT002",
                    HoTen = "Nguyen Thi B",
                    GioiTinh = false,
                    NgaySinh = new DateTime(1985, 12, 20),
                    DiaChi = "Ba Dinh, Ha Noi",
                    SDT = "0987654321",
                    MaNV = "NV002",
                    TrangThai = true
                },

                new Pt()
                {

                    MaPT = "PT003",
                    HoTen = "Le Van C",
                    GioiTinh = true,
                    NgaySinh = new DateTime(1995, 3, 25),
                    DiaChi = "Hoan Kiem, Ha Noi",
                    SDT = "0912345678",
                    MaNV = "NV003",
                    TrangThai = true
                },
            };


                dataContext.Pts.AddRange(ptList);
                dataContext.SaveChanges();
            }
        }
    }
}
