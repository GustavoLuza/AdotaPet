using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Domain.Interfaces.Repository;
using GL.Treinamento.Domain.Interfaces.Services;
using GL.Treinamento.Domain.Validation.Animais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public Animal Adicionar(Animal animal)
        {
            if (!animal.IsValid())
                return animal;

            animal.ValidationResult = new AnimalAptoParaCadastroValidation(_animalRepository).Validate(animal);
            if (!animal.ValidationResult.IsValid)
                return animal;

            return _animalRepository.Adicionar(animal);
        }

        public Animal Atualizar(Animal animal)
        {
            return _animalRepository.Atualizar(animal);
        }

        public void Dispose()
        {
            _animalRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Animal> ObterAtivos()
        {
            return _animalRepository.ObterAtivos();
        }

        public Animal ObterPorId(Guid id)
        {
            return _animalRepository.ObterPorId(id);
        }

        public IEnumerable<Animal> ObterTodos()
        {
            return _animalRepository.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _animalRepository.Remover(id);
        }
    }
}
