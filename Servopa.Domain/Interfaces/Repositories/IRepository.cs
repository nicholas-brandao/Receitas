using Servopa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Servopa.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Adicionar(T obj);

        void Atualizar(T obj);

        void Remover(T obj);

        T ObterPorId(int id);

        IEnumerable<T> ObterTodos();

        IEnumerable<T> Pesquisar(Expression<Func<T, bool>> predicate);
    }
}
