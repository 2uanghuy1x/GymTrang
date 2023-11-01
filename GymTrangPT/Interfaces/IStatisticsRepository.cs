using GymApi.Models;
using GymTrangPT.Dto.Bill;

namespace GymTrangPT.Interfaces
{
    public interface IStatisticsRepository
    {
        ICollection<BillDto> GetAll(DateTime ToDate, DateTime FromDate);
        ICollection<Bill> GetAllList();
        Task CreateOrEditData(Bill category);
        Task DeleteData(int input);
    }
}
