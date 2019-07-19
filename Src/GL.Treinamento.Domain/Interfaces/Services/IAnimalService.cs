using GL.Treinamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Interfaces.Services
{
    public interface IAnimalService :IDisposable
    {
        Animal Adicionar(Animal animal);
        Animal ObterPorId(Guid id);
        IEnumerable<Animal> ObterTodos();
        IEnumerable<Animal> ObterAtivos();
        Animal Atualizar(Animal animal);
        void Remover(Guid id);
    }
}
