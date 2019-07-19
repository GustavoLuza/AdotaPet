using GL.Treinamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Infra.Data.EntityConfig
{
    public class AnimalConfig :EntityTypeConfiguration<Animal>
    {
        public AnimalConfig()
        {
            HasKey(a => a.AnimalId);

            Property(a => a.NomeAnimal).IsRequired().HasMaxLength(150);
            Property(a => a.Especie).IsRequired();
            Property(a => a.CorPelagem).IsRequired();
            Property(a => a.Sexo).IsRequired();
            Property(a => a.Porte).IsRequired();
            Property(a => a.Castrado).IsRequired();
            Property(a => a.Vermifugado).IsRequired();
            Property(a => a.Vacinado).IsRequired();
            Property(a => a.Ativo).IsRequired();
            Ignore(c => c.ValidationResult);

            ToTable("Animais");
        }
    }
}
