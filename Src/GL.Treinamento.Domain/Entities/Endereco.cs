using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Entities
{
   public class Endereco
    {
        public Endereco()
        {
            EnderecoId = Guid.NewGuid();
        }
        public Guid EnderecoId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estados { get; set; }
        public Guid ClienteId { get; set; }
        public virtual Cliente cliente { get; set; }
        public Guid OngId { get; set; }
        public virtual Ong ong { get; set; }
    }
}
