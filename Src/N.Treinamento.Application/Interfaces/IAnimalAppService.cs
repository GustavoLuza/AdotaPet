using N.Treinamento.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Treinamento.Application.Interfaces
{
    public interface IAnimalAppService :IDisposable
    {
        AnimalViewModel Adicionar(AnimalViewModel animalViewModel);
        AnimalViewModel ObterPorId(Guid id);
        IEnumerable<AnimalViewModel> ObterTodos();
        AnimalViewModel Atualizar(AnimalViewModel animalViewModel);
        void Remover(Guid id);
    }
}
