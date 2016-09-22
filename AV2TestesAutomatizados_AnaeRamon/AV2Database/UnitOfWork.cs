using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AV2Database.Model;

namespace AV2Database
{
    public class UnitOfWork : IDisposable
    {

        private RepositorioPalavras _repositorio;
        private readonly DBPalavrasContext _palavrasContext;

        public UnitOfWork(DBPalavrasContext palavrasContext)
        {
            _palavrasContext = palavrasContext;
            _repositorio = new RepositorioPalavras(_palavrasContext);
        }

        public void InserirPalavra(PalavrasModel palavra)
        {
            _repositorio.Inserir(palavra);
            Save();
        }

        public void RemoverPalavra(int idPalavra)
        {
            PalavrasModel palavraBuscada = _palavrasContext.Palavras.Find(idPalavra);
            _repositorio.Remover(palavraBuscada);
            Save();
        }

        public List<PalavrasModel> ObtemListaPalavras()
        {
           return _repositorio.ObterTodas().ToList();
        }
        
        private void Save()
        {
            _palavrasContext.SaveChanges();
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
                    _palavrasContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
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
