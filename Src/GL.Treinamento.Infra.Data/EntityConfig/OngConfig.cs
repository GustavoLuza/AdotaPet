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
    public class OngConfig :EntityTypeConfiguration<Ong>
    {
        public OngConfig()
        {
            HasKey(o => o.OngId);
            Property(o => o.NomeFantasia).IsRequired().HasMaxLength(200);
            Property(o => o.CNPJ).IsRequired().HasMaxLength(14).IsFixedLength().HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = true }));
            Property(o => o.Celular).IsRequired().HasMaxLength(12);
            Property(o => o.Telefone).HasMaxLength(10);
            Property(o => o.Email).IsRequired().HasMaxLength(100);
            Property(o => o.Ativo).IsRequired();
            Ignore(o => o.ValidationResult);
            ToTable("Ongs");
        }
    }
}
