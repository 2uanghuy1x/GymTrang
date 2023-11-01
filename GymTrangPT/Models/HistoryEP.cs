namespace GymApi.Models
{
    public class HistoryEP
    {
        public int? Id { get; set; }
        public int MaLS { get; set; }
        public string MaHV { get; set; }
        public DateTime NgayTap { get; set; }
        public int ThoiGian { get; set; }
        public string GioVao { get; set; }
        public string MaPT { get; set; }
    }
}
