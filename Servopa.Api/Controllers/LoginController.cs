using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Servopa.Api.Model;
using Servopa.Api.Security;
using Servopa.Domain.Entities;
using Servopa.Domain.Interfaces.Services;

namespace Servopa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IUsuarioService usuarioService;
        private readonly JwtService jwt;

        public LoginController(IConfiguration config, IUsuarioService service, JwtService jwt)
        {
            _config = config;
            usuarioService = service;
            this.jwt = jwt;
        }

        /// <summary>
        /// Efetua o Login
        /// </summary>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost, AllowAnonymous]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Login([FromBody]UserLogin user)
        {
            try
            {
                if (user == null)
                    return Unauthorized(new { message = "Usuário e/ou senha inválidos" });

                var retorno = usuarioService.AutenticarUsuario(new Usuario()
                {
                    Login = user.User,
                    Senha = user.Password
                });

                if (!retorno)
                    return Unauthorized(new { message = "Usuário ou senha inválidos" });

                return CreatedAtAction(
                        actionName: "token",
                        routeValues: new { token = jwt.AutenticarUsuarioJwt(user) },
                        value: jwt.AutenticarUsuarioJwt(user)
                        );
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("Teste")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2", "value3", "value4", "value5" };
        }
    }
}