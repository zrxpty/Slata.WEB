using AutoMapper;
using backend.Models;
using Slata.BLL.DTO;

namespace backend.AutoMapperProfile
{
    public class ApplicantProfile : Profile
    {
        public ApplicantProfile()
        {
            CreateMap<ApplicantDTO, ApplicantVM>().ReverseMap();
        }
    }
}
