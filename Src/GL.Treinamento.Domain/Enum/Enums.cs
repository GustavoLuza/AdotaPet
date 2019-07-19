using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Enum
{
    public static class Enums
    {
        public enum SexoAnimais
        {
            [Display(Name = "Macho")]
            Macho = 0,
            [Display(Name = "Fêmea")]
            Fêmea = 1,
        }

        public enum RespostasSimNao
        {
            [Display(Name = "Sim")]
            Sim = 0,
            [Display(Name = "Não")]
            Não = 1,
        }

        public enum PorteAnimal
        {
            [Display(Name = "Pequeno")]
            Pequeno = 0,
            [Display(Name = "Médio")]
            Médio = 1,
            [Display(Name = "Grande")]
            Grande = 2,
            [Display(Name = "Extra grande")]
            ExtraGrande = 3,
        }

        public enum CorPelagem
        {
            [Display(Name = "Claro")]
            Claro = 0,
            [Display(Name = "Escuro")]
            Escuro = 1,
            [Display(Name = "Mesclado")]
            Mesclado = 2,
        }

        public enum EspecieAnimal
        {
            [Display(Name = "Cão")]
            Cão = 0,
            [Display(Name = "Gato")]
            Gato = 1,
            [Display(Name = "Cavalo")]
            Cavalo = 2,
            [Display(Name = "Outros")]
            Outros = 3,
        }
    }
    
}
