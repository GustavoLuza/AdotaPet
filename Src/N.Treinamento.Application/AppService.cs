using GL.Treinamento.Infra.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Treinamento.Application
{
    public class AppService
    {
        private readonly IUnityOfWork _uow;

        public AppService(IUnityOfWork uow)
        {
            _uow = uow;
        }

        public void Commit()
        {
            _uow.Commit();
        }
    }
}
