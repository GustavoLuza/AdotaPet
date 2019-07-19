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
    public class AnimalAppService :AppService, IAnimalAppService
    {
        private readonly IAnimalService _animalService;

        public AnimalAppService(IAnimalService animalService, IUnityOfWork uow)  :base(uow)
        {
            _animalService = animalService;
        }

        public AnimalViewModel Adicionar(AnimalViewModel animalViewModel)
        {
            var animal = Mapper.Map<Animal>(animalViewModel);

            var animalReturn = _animalService.Adicionar(animal);

            if (animalReturn.ValidationResult.IsValid)
            {
                animal.Ativo = true;
                Commit();
            }

            return Mapper.Map<AnimalViewModel>(animalReturn);
        }

        public AnimalViewModel Atualizar(AnimalViewModel animalViewModel)
        {
            var animal = Mapper.Map<Animal>(animalViewModel);
            _animalService.Atualizar(animal);
            animal.Ativo = true;
            Commit();
            return animalViewModel;
        }

        public void Dispose()
        {
            _animalService.Dispose();
            GC.SuppressFinalize(this);
        } 

        public AnimalViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<AnimalViewModel>(_animalService.ObterPorId(id));
        }

        public IEnumerable<AnimalViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<AnimalViewModel>>(_animalService.ObterAtivos().ToList());
        }

        public void Remover(Guid id)
        {
            _animalService.Remover(id);
            Commit();
        }
    }
}
