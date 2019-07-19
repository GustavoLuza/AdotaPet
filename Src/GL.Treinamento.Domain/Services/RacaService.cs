using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Domain.Interfaces.Repository;
using GL.Treinamento.Domain.Interfaces.Services;
using GL.Treinamento.Domain.Validation.Racas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Services
{
    public class RacaService : IRacaService
    {
        private readonly IRacaRepository _racaRepository;

        public RacaService(IRacaRepository racaRepository)
        {
            _racaRepository = racaRepository;
        }

        public Raca Adicionar(Raca raca)
        {
            if (!raca.IsValid())
                return raca;

            raca.ValidationResult = new RacaAptaParaCadastroValidation(_racaRepository).Validate(raca);
            if (!raca.ValidationResult.IsValid)
                return raca;

            return _racaRepository.Adicionar(raca);
        }

        public Raca Atualizar(Raca raca)
        {
            return _racaRepository.Atualizar(raca);
        }

        public void Dispose()
        {
            _racaRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Raca ObterPorId(Guid id)
        {
            return _racaRepository.ObterPorId(id);
        }

        public Raca ObterPorRaca(string nomeRaca)
        {
            return _racaRepository.ObterPorRaca(nomeRaca);
        }

        public IEnumerable<Raca> ObterTodos()
        {
            return _racaRepository.ObterTodos();
        }

        public void Remover(Guid id)
        {
             _racaRepository.Remover(id);
        }
    }
}
