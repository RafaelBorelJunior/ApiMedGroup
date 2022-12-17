using ApiTeste.Business.Models;
using ApiTeste.DTO;
using ApiTeste.ViewModels;
using AutoMapper;

namespace ApiTeste.Config
{
    public class ConfigAutoMapper:Profile
    {
        public ConfigAutoMapper()
        {
            CreateMap<Contato, ContatoViewModel>().ReverseMap();
            CreateMap<Contato, ContatoDTO>().ReverseMap();
        }
    }
}
