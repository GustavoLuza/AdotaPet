using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Infra.Data.UnitOfWork
{
   public interface IUnityOfWork
    {
        void Commit();
    }
}
