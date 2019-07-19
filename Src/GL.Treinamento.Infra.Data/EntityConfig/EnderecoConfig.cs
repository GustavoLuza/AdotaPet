using GL.Treinamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Infra.Data.EntityConfig
{
    //MAPEAMENTO UTILIZANDO FLUENT API
    public class EnderecoConfig :EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            HasKey(e => e.EnderecoId);

            Property(e => e.Logradouro).IsRequired().HasMaxLength(200);
            Property(e => e.Numero).IsRequired().HasMaxLength(10);
            Property(e => e.Bairro).IsRequired().HasMaxLength(50);
            Property(e => e.CEP).IsRequired().HasMaxLength(8).IsFixedLength();
            Property(e => e.Complemento).HasMaxLength(100);

            //O RELACIONAMENTO SEMPRE FICA POR CONTA DA TABELA QUE TEM O RELACIONAMENTO (TABELA DE CLIENTE CONTÉM RELACIONAMENTO COM ENDEREÇO)

            HasRequired(e => e.cliente).WithMany(c => c.Enderecos).HasForeignKey(e => e.ClienteId); //RELACIONAMENTO OBRIGATORIO ONDE CLIENTE PODE TER VÁRIOS ENDEREÇOS

            ToTable("Enderecos");
        }
    }
}
