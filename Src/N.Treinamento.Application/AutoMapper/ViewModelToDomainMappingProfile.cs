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
   public class ViewModelToDomainMappingProfile : Profile //ESTÁ HERDANDO DA CLASSE PROFILE
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>(); //CRIANDO O MAPEAMENTO DE ClienteViewModel PARA Cliente
            CreateMap<ClienteEnderecoViewModel, Cliente>();//CRIANDO O MAPEAMENTO DE ClienteEnderecoViewModel PARA Cliente
            CreateMap<EnderecoViewModel, Endereco>();//CRIANDO O MAPEAMENTO DE EnderecoViewModel PARA Endereco
            CreateMap<DoencaViewModel, Doenca>();
            CreateMap<ClienteEnderecoViewModel, Endereco>();//CRIANDO O MAPEAMENTO DE ClienteEnderecoViewModel PARA Endereco
            CreateMap<PainelAdministrativoViewModel, PainelAdministrativo>(); //CRIANDO O MAPEAMENTO DE PainelAdministrativoViewModel PARA PainelAdministrativo
            CreateMap<AspNetUsersViewModel, AspNetUsers>();
            CreateMap<RacaViewModel, Raca>();
            CreateMap<AnimalViewModel, Animal>();
            CreateMap<OngViewModel, Ong>();
            CreateMap<OngEnderecoViewModel, Ong>();
            CreateMap<OngEnderecoViewModel, Endereco>();
            CreateMap<MantimentoViewModel, Mantimentos>();
        }
    }
}
