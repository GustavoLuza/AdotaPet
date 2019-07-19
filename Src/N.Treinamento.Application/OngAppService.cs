using AutoMapper;
using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Domain.Interfaces.Services;
using GL.Treinamento.Infra.Data.UnitOfWork;
using N.Treinamento.Application.Interfaces;
using N.Treinamento.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Treinamento.Application
{
    public class OngAppService : AppService, IOngAppService
    {
        private readonly IOngService _ongService;

        public OngAppService(IOngService ongService, IUnityOfWork uow) :base(uow)
        {
            _ongService = ongService;
        }

        public OngEnderecoViewModel Adicionar(OngEnderecoViewModel ongEnderecoViewModel)
        {
            var ong = Mapper.Map<Ong>(ongEnderecoViewModel);
            var endereco = Mapper.Map<Endereco>(ongEnderecoViewModel);

            ong.Enderecos.Add(endereco);

            var ongReturn = _ongService.Adicionar(ong);

            if(ongReturn.ValidationResult.IsValid)
            {
                ong.Ativo = true;
                Commit();
            }

            return Mapper.Map<OngEnderecoViewModel>(ongReturn);
        }

        public OngViewModel Atualizar(OngViewModel ongViewModel)
        {
            var ong = Mapper.Map<Ong>(ongViewModel);
            _ongService.Atualizar(ong);
            ong.Ativo = true;
            Commit();
            return ongViewModel;
        }

        public void Dispose()
        {
            _ongService.Dispose();
            GC.SuppressFinalize(this);
        }

        public OngViewModel ObterPorCNPJ(string cnpj)
        {
            return Mapper.Map<OngViewModel>(_ongService.ObterPorCNPJ(cnpj));
        }

        public OngViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<OngViewModel>(_ongService.ObterPorEmail(email));
        }

        public OngViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<OngViewModel>(_ongService.ObterPorId(id));
        }

        public IEnumerable<OngViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<OngViewModel>>(_ongService.ObterAtivos().ToList());
        }

        public void remover(Guid id)
        {
            _ongService.Remover(id);
            Commit(); 
        }
    }
}
