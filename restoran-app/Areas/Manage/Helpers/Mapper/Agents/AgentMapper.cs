using AutoMapper;
using restoran_app.Areas.Manage.Helpers.DTOs.Agents;
using restoran_app.Models;

namespace restoran_app.Areas.Manage.Helpers.Mapper.Agents;

public class AgentMapper : Profile
{
    public AgentMapper()
    {
        CreateMap<CreateAgentDto, Agent>().ReverseMap();
        CreateMap<UpdateAgentDto, Agent>().ReverseMap();
    }
}
