using Servopa.Domain.Entities;
using Servopa.Domain.Interfaces.Repositories;
using Servopa.Domain.Interfaces.Services;
using Servopa.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servopa.Service.Services
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        private IUsuarioRepository repository;
        public UsuarioService(IUsuarioRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        public bool AutenticarUsuario(Usuario user)
        {
            user = repository.AutenticarUsuario(user);

            if (user == null)
                return false;
            else
                return true;
        }
    }
}
