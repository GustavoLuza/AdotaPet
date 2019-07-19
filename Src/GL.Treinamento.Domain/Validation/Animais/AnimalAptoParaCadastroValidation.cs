using DomainValidation.Validation;
using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Validation.Animais
{
    public class AnimalAptoParaCadastroValidation :Validator<Animal>
    {
        public AnimalAptoParaCadastroValidation(IAnimalRepository animalRepository)
        {

        }
    }
}
