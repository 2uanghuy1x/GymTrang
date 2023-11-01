namespace GymApi.Models
{
    public class Bill
    {
        public int? Id { get; set; }
        public string MaHD { get; set; }
        public string MaGT { get; set; }
        public string MaHV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgayMua { get; set; }
        public decimal DonGia { get; set; }
        public string MaNV { get; set; }
    }
}
