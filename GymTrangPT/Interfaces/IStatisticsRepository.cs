using GymApi.Models;
using GymTrangPT.Dto.Bill;

namespace GymTrangPT.Interfaces
{
    public interface IStatisticsRepository
    {
        ICollection<BillDto> GetAll(int year);
        ICollection<Bill> GetAllList();
        Task CreateOrEditData(Bill category);
        Task DeleteData(int input);
    }
}
