using GL.Treinamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Infra.Data.EntityConfig
{
    public class MantimentoConfig :EntityTypeConfiguration<Mantimentos>
    {
        public MantimentoConfig()
        {
            HasKey(m => m.MantimentoId);

            Property(m => m.Descricao).HasMaxLength(100);
            Property(m => m.DataValidade).IsRequired();
            Property(m => m.Ativo).IsRequired();
            Property(m => m.Item).IsRequired();
            Property(m => m.Quantidade).IsRequired();
            Property(m => m.Tipo).IsRequired();
            Property(m => m.CodigoIdentificacao).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Ignore(c => c.ValidationResult);

            ToTable("Mantimentos");
        }
    }
}
