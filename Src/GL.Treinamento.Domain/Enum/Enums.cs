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

        public enum Mantimentos
        {
            [Display(Name = "Ração cão")]
            RacaoCao = 0,
            [Display(Name = "Ração gato")]
            RacaoGato = 1,
            [Display(Name = "Ração cavalo")]
            RacaoCavalo = 2,
            [Display(Name = "Tapete higiênico")]
            TapeteHigienico = 3,
            [Display(Name = "Areia sanitária")]
            AreiaSanitaria = 4,
            [Display(Name = "Medicamento")]
            Medicamento = 5,
            [Display(Name = "Outros")]
            Outros = 6,
        }

        public enum Quantidade
        {
            [Display(Name = "1 KG")]
            UmKG = 0,
            [Display(Name = "3 KG")]
            TresKG = 1,
            [Display(Name = "5 KG")]
            CincoKG = 2,
            [Display(Name = "10 KG")]
            DezKG = 3,
            [Display(Name = "15 KG")]
            QuinzeKG = 4,
            [Display(Name = "20 KG")]
            VinteKG = 5,
            [Display(Name = "25 KG")]
            VinteCincoKG = 6,
            [Display(Name = "1 UN")]
            UmUN = 7,
            [Display(Name = "2 UN")]
            DoisUN = 8,
            [Display(Name = "3 UN")]
            TresUN = 9,
            [Display(Name = "4 UN")]
            QuatroUN = 10,
            [Display(Name = "5 UN")]
            CincoUN = 11,
            [Display(Name = "Outros")]
            Outros = 10,
        }

        public enum TipoMantimento
        {
            [Display(Name = "Alimentício")]
            Alimento = 0,
            [Display(Name = "Higiene")]
            Higiene = 1,
            [Display(Name = "Medicamento")]
            Medicamento = 2
        }
    }
    
}
