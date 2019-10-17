using Microsoft.EntityFrameworkCore;
using Servopa.Domain.Entities;
using Servopa.Domain.Interfaces;
using Servopa.Domain.Interfaces.Repositories;
using Servopa.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Servopa.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly ServopaSqlServerContext context;
        protected DbSet<T> dbSet;

        public BaseRepository(ServopaSqlServerContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<T>();
        }

        public virtual void Adicionar(T obj)
        {
            var entry = this.context.Entry(obj);
            this.dbSet.Add(obj);
            entry.State = EntityState.Added;

        }

        public virtual void Atualizar(T obj)
        {
            var entry = this.context.Entry(obj);
            this.dbSet.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public virtual T ObterPorId(int id)
        {
            try
            {
                var resultado = this.dbSet.Find(id);

                //if (resultado != null)
                //    this.context.Entry(resultado).State = EntityState.Detached;

                return resultado;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public virtual IEnumerable<T> ObterTodos()
        {
            return this.dbSet.ToList();
        }

        public virtual IEnumerable<T> ObterTodosPaginado(int pagina, int registros)
        {
            var resultado = this.dbSet.Take(pagina).Skip(registros);

            return this.dbSet.ToList();
        }

        public virtual IEnumerable<T> Pesquisar(Expression<Func<T, bool>> predicate)
        {
            return this.dbSet.Where(predicate);
        }

        public virtual void Remover(T obj)
        {
            var entry = this.context.Entry(obj);
            this.dbSet.Remove(obj);
            entry.State = EntityState.Deleted;
        }
    }
}
