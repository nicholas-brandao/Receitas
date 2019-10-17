using Servopa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servopa.Domain.Interfaces.Services
{
    public interface IUsuarioService : IService<Usuario>
    {
        bool AutenticarUsuario(Usuario user);
    }
}
