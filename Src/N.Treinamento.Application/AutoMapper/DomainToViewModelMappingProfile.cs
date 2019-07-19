using AutoMapper;
using GL.Treinamento.Domain.Entities;
using N.Treinamento.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Treinamento.Application.AutoMapper
{
   public class DomainToViewModelMappingProfile : Profile //ESTÁ HERDANDO DA CLASSE PROFILE
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>(); //CRIANDO O MAPEAMENTO DE CLIENTE PARA ClienteViewModel
            CreateMap<Cliente, ClienteEnderecoViewModel>();//CRIANDO O MAPEAMENTO DE CLIENTE PARA ClienteEnderecoViewModel
            CreateMap<Endereco, EnderecoViewModel>();//CRIANDO O MAPEAMENTO DE CLIENTE PARA EnderecoViewModel
            CreateMap<Doenca, DoencaViewModel>();
            CreateMap<Endereco, ClienteEnderecoViewModel>();//CRIANDO O MAPEAMENTO DE CLIENTE PARA ClienteEnderecoViewModel
            CreateMap<PainelAdministrativo, PainelAdministrativoViewModel>();//CRIANDO O MAPEAMENTO DE PainelAdministrativo PARA PainelAdministrativoViewModel
            CreateMap<AspNetUsers, AspNetUsersViewModel>();
            CreateMap<Raca, RacaViewModel>();
            CreateMap<Animal, AnimalViewModel>();
            CreateMap<Ong, OngViewModel>();
            CreateMap<Ong, OngEnderecoViewModel>();
            CreateMap<Endereco, OngEnderecoViewModel>();
            CreateMap<Endereco, OngEnderecoViewModel>();
        }
    }
}
