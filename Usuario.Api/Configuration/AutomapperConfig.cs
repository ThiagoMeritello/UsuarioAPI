using AutoMapper;
using Usuario.Api.Controllers;
using Usuario.Api.ViewModels;
using Usuario.Business.Models;

namespace Usuario.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Usuarios, UsuarioViewModel>().ReverseMap();
        }

    }
}
