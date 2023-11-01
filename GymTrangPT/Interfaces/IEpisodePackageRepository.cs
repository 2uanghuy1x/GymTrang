using GymApi.Models;

namespace GymTrangPT.Interfaces
{
    public interface IEpisodePackageRepository
    {
        ICollection<EpisodePackage> GetAll(string dataSearch);
        ICollection<EpisodePackage> GetAllList();
        Task CreateOrEditData(EpisodePackage category);
        Task DeleteData(int input);
    }
}
