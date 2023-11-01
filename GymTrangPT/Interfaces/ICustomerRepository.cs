using GymApi.Models;

namespace GymTrangPT.Interfaces
{
    public interface ICustomerRepository
    {
        ICollection<Customer> GetAll(string dataSearch);
        ICollection<Customer> GetAllList();
        Task CreateOrEditData(Customer category);
        Task DeleteData(int input);

    }
}
