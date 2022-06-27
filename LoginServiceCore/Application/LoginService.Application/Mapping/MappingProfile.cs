using AutoMapper;
using Common.Application.Model;
using LoginService.Application.Models;

namespace LoginService.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<InRequest, AuthenticationRequest>().ReverseMap();
        }
    }
}
