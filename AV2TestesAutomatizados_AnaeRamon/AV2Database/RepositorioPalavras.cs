using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AV2Database.Model;

namespace AV2Database
{
    public class RepositorioPalavras : IRepositorio<PalavrasModel>, IDisposable
    {
        private readonly DBPalavrasContext dbContext;

        public RepositorioPalavras(DBPalavrasContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Inserir(PalavrasModel palavra)
        {
            dbContext.Palavras.Add(palavra);
        }

        public IEnumerable<PalavrasModel> ObterTodas()
        {
            return dbContext.Palavras.ToList();
        }

        public void Remover(PalavrasModel palavra)
        {
            dbContext.Palavras.Remove(palavra);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    dbContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~RepositorioPalavras() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
             GC.SuppressFinalize(this);
        }
        #endregion
    }
}
