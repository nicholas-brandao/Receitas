using FluentValidation;
using Servopa.Domain.Entities;
using Servopa.Domain.Interfaces;
using Servopa.Domain.Interfaces.Repositories;
using Servopa.Domain.Interfaces.Services;
using Servopa.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Servopa.Service.Services
{
    public class BaseService<T> : IService<T> where T : class
    {
        private readonly IRepository<T> repository;

        public BaseService(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public virtual void Adicionar(T obj)
        {
            this.repository.Adicionar(obj);
        }

        public virtual void Atualizar(T obj)
        {
            this.repository.Atualizar(obj);
        }

        public virtual void Remover(T id)
        {
            this.repository.Remover(id);
        }

        public virtual T ObterPorId(int id)
        {
            return repository.ObterPorId(id);
        }

        public virtual IEnumerable<T> ObterTodos()
        {
            return repository.ObterTodos();
        }

        public IEnumerable<T> Pesquisar(Expression<Func<T, bool>> predicate)
        {
            return this.repository.Pesquisar(predicate);
        }
    }
}
