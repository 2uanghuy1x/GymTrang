using AutoMapper;
using GymApi.Models;
using GymTrangPT.Dto;
using GymTrangPT.Dto.Bill;
using GymTrangPT.Dto.His;

namespace GymTrangPT.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<EpisodePackage, EpisodePackageDto>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<HistoryEP, HistoryEPData>();
            CreateMap<Bill, CreateOrEditBill>();
        }
    }
}
