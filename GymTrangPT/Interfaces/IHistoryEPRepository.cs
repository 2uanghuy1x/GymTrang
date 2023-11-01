using GymApi.Models;
using GymTrangPT.Dto.His;

namespace GymTrangPT.Interfaces
{
    public interface IHistoryEPRepository
    {
        ICollection<HistoryEPDto> GetAll(string dataSearchEP, string dataSearchCus, DateTime ToDate, DateTime FromDate);
        ICollection<HistoryEP> GetAllList();
        Task CreateOrEditData(HistoryEP category);
        Task DeleteData(int input);
    }
}
