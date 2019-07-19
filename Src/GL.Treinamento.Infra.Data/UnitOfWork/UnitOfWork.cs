using GL.Treinamento.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnityOfWork
    {
        private readonly TreinamentoContext _context;
        private bool _disposed; //CONTROLE PARA SABER SE O OBJETO JÁ FOI DESTRUÍDO

        public UnitOfWork(TreinamentoContext context)
        {
            _context = context;
            _disposed = false;  //DISPOSED SEMPRE VAI SER INCIADO COM FALSE
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing) //VERIFICA SE O DISPOSED É VERDADEIRO OU FALSO, EVITANDO DESTRUIR O OBJETO MAIS DE UMA VEZ
        {
            if(!_disposed)
            {
                if(disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
