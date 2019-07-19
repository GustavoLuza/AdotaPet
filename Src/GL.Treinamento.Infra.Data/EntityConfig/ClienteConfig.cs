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
    //CLASSE DO TIPO FLUENT API
    //CLASSE DE MAPEAMENTO DO CLIENTE
   public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(c => c.ClienteId); //DIZ QUE ESSA É MINHA CHAVE PRIMARIA USANDO FLUENT E EXPRESSÃO LAMBDA
            //HasKey(c => new { c.ClienteId, c.CPF});  CASO A CHAVE PRIMARIA SEJA COMPOSTA, DEVE SER FEITO DESTA FORMA

            Property(c => c.Nome).IsRequired().HasColumnOrder(1).HasMaxLength(150); //DEFINE QUE A COLUNA NOME VAI SER A PRIMEIRA DO BANCO E QUE O TAMANHO MAXIMO É DE 150 CARACTERES
            Property(c => c.CPF).IsRequired().HasMaxLength(11).IsFixedLength().HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = true })); //DEFINE O CPF COMO UNICO
            Property(c => c.Email).IsRequired().HasMaxLength(100);
            Property(c => c.DataNascimento).IsRequired();
            Property(c => c.Ativo).IsRequired();
            Ignore(c => c.ValidationResult);

            ToTable("Clientes"); //DEFINO O NOME DA TABELA

        }
    }
}
