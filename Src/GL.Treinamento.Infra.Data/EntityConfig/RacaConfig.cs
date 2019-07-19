using GL.Treinamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Infra.Data.EntityConfig
{
    public class RacaConfig :EntityTypeConfiguration<Raca>
    {
        public RacaConfig()
        {
            HasKey(r => r.RacaId);
            Property(r => r.NomeRaca).IsRequired().HasMaxLength(150).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = true }));
            Ignore(r => r.ValidationResult);
            ToTable("Racas");
        }
    }
}
