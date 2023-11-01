namespace GymApi.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public bool VaiTro { get; set; }
        public string MatKhau { get; set; }
        public bool TrangThai { get; set; }
    }
}
