using AutoMapper;
using restoran_app.Areas.Manage.Helpers.DTOs.Positions;
using restoran_app.Models;

namespace restoran_app.Areas.Manage.Helpers.Mapper.Positions;

public class PositionMapper : Profile
{
    public PositionMapper()
    {
        CreateMap<CreatePositionDto, Position>().ReverseMap();
        CreateMap<UpdatePositionDto, Position>().ReverseMap();
    }
}
