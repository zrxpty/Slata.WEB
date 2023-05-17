using DAL.Models;
using Slata.BLL.DTO;
using AutoMapper;
using backend.Models;

namespace backend.AutoMapperProfile
{
    public class PositionProfile : Profile
    {
        public PositionProfile() {
            CreateMap<Position, PositionDTO>().ReverseMap();
            CreateMap<PositionDTO, PositionVM>().ReverseMap();
            CreateMap<PositionVM, Position>().ReverseMap();
        }

    }
}
