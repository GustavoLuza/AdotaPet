using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Domain.Interfaces.Repository;
using GL.Treinamento.Domain.Interfaces.Services;
using GL.Treinamento.Domain.Validation.Mantimento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Services
{
    public class MantimentoService :IMantimentoService
    {
        private readonly IMantimentoRepository _mantimentoRepository;
        
        public MantimentoService(IMantimentoRepository mantimentoRepository)
        {
            _mantimentoRepository = mantimentoRepository;
        }

        public Mantimentos Adicionar(Mantimentos mantimentos)
        {
            if (!mantimentos.IsValid())
                return mantimentos;

            mantimentos.ValidationResult = new MantimentoAptoParaCadastroValidation(_mantimentoRepository).Validate(mantimentos);
            if (!mantimentos.ValidationResult.IsValid)
                return mantimentos;

            return _mantimentoRepository.Adicionar(mantimentos);

        }

        public Mantimentos Atualizar(Mantimentos mantimentos)
        {
            return _mantimentoRepository.Atualizar(mantimentos);
        }

        public void Dispose()
        {
            _mantimentoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Mantimentos> ObterAtivos()
        {
            return _mantimentoRepository.ObterAtivos();
        }

        public Mantimentos ObterPorId(Guid id)
        {
            return _mantimentoRepository.ObterPorId(id);
        }

        public IEnumerable<Mantimentos> ObterTodos()
        {
            return _mantimentoRepository.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _mantimentoRepository.Remover(id);
        }

        
    }
}
