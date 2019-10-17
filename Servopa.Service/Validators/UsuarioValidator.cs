using FluentValidation;
using Servopa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servopa.Service.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Não foi possível encontrar o objeto.");
                    });

            RuleFor(c => c.Login)
                .NotEmpty().WithMessage("Obrigatório informar o login.")
                .NotNull().WithMessage("Obrigatório informar o login.");
        }
    }
}
