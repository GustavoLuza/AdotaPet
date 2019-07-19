using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Domain.Interfaces.Repository;
using GL.Treinamento.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Services
{
    public class PainelAdministrativoService : IPainelAdministrativoService
    {

        private readonly IPainelAdministrativoRepository _painelAdministrativoRepository;

        public PainelAdministrativoService(IPainelAdministrativoRepository painelAdministrativoRepository)
        {
            _painelAdministrativoRepository = painelAdministrativoRepository;
        }


        public PainelAdministrativo Adicionar(PainelAdministrativo painelAdministrativo)
        {
            return _painelAdministrativoRepository.Adicionar(painelAdministrativo);
        }

        public PainelAdministrativo Atualizar(PainelAdministrativo painelAdministrativo)
        {
            return _painelAdministrativoRepository.Atualizar(painelAdministrativo);
        }

        public void Dispose()
        {
            _painelAdministrativoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public PainelAdministrativo ObterPorInt(int id)
        {
            return _painelAdministrativoRepository.ObterPorInt(id);
        }

        public IEnumerable<PainelAdministrativo> ObterTodos()
        {
            return _painelAdministrativoRepository.ObterTodos();
        }
        
    }
}
