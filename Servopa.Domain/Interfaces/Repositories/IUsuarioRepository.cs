using Servopa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servopa.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario AutenticarUsuario(Usuario user);
    }
}
