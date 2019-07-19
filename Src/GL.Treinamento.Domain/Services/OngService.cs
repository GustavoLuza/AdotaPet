using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Domain.Interfaces.Repository;
using GL.Treinamento.Domain.Interfaces.Services;
using GL.Treinamento.Domain.Validation.Ongs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Services
{
    public class OngService :IOngService
    {
        private readonly IOngRepository _ongRepository;

        public OngService(IOngRepository ongRepository)
        {
            _ongRepository = ongRepository;
        }

        public Ong Adicionar(Ong ong)
        {
            if (!ong.IsValid())
                return ong;

            ong.ValidationResult = new OngAptaParaCadastroValidation(_ongRepository).Validate(ong);
            if (!ong.ValidationResult.IsValid)
                return ong;

            return _ongRepository.Adicionar(ong);
        }

        public Ong Atualizar(Ong ong)
        {
            return _ongRepository.Atualizar(ong);
        }

        public void Dispose()
        {
            _ongRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Ong> ObterAtivos()
        {
            return _ongRepository.ObterAtivos();
        }

        public Ong ObterPorCNPJ(string cnpj)
        {
           return _ongRepository.ObterPorCNPJ(cnpj);
        }

        public Ong ObterPorEmail(string email)
        {
            return _ongRepository.ObterPorEmail(email);
        }

        public Ong ObterPorId(Guid id)
        {
            return _ongRepository.ObterPorId(id);
        }

        public IEnumerable<Ong> ObterTodos()
        {
            return _ongRepository.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _ongRepository.Remover(id);
        }
    }
}
