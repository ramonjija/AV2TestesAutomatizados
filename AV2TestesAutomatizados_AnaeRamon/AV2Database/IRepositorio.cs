using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AV2Database
{
    public interface IRepositorio<T> where T : class
    {
        IEnumerable<T> ObterTodas();
        void Inserir(T entity);
        void Remover(T entity);
    }
}
