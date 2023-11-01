namespace GymApi.Models
{
    public class Customer
    {   
        public int? Id { get; set; }
        public string MaHV { get; set; }
        public string HoTen { get; set; }
        public bool? GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string MaGT { get; set; }
        public DateTime NgayDK { get; set; }
        public DateTime NgayHH { get; set; }
        public string MaNV { get; set; }
        public bool TrangThai { get; set; }
    }
}
