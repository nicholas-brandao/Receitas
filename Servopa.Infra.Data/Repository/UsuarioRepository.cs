using Servopa.Domain.Entities;
using Servopa.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Servopa.Domain.Interfaces.Repositories;

namespace Servopa.Infra.Data.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ServopaSqlServerContext context) : base(context)
        {}

        public Usuario AutenticarUsuario(Usuario user)
        {
            return this.dbSet.FirstOrDefault(w => w.Login.Equals(user.Login) && w.Senha.Equals(user.Senha));
        }
    }
}
