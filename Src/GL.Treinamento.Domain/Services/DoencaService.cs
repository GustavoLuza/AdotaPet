using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Domain.Interfaces.Repository;
using GL.Treinamento.Domain.Interfaces.Services;
using GL.Treinamento.Domain.Validation.Doencas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Services
{
    public class DoencaService : IDoencaService
    {
        private readonly IDoencaRepository _doencaRepository;

        public DoencaService(IDoencaRepository doencaRepository)
        {
            _doencaRepository = doencaRepository;
        }

        public Doenca Adicionar(Doenca doenca)
        {
           if(!doenca.IsValid())
                return doenca;

            doenca.ValidationResult = new DoencaAptaParaCadastroValidation(_doencaRepository).Validate(doenca);
            if (!doenca.ValidationResult.IsValid)
                return doenca;

            return _doencaRepository.Adicionar(doenca);
            
        }

        public Doenca Atualizar(Doenca doenca)
        {
            return _doencaRepository.Atualizar(doenca);
        }

        public void Dispose()
        {
            _doencaRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Doenca ObterPorDoenca(string nomeDoenca)
        {
            return _doencaRepository.ObterPorDoenca(nomeDoenca);
        }

        public Doenca ObterPorId(Guid id)
        {
            return _doencaRepository.ObterPorId(id);
        }

        public IEnumerable<Doenca> ObterTodos()
        {
            return _doencaRepository.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _doencaRepository.Remover(id);
        }
    }
}
