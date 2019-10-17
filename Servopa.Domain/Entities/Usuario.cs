using System;
using System.Collections.Generic;
using System.Text;

namespace Servopa.Domain.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}
