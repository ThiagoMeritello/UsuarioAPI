using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Usuario.Business.Models.Validations
{
    public class UsuarioValidation : AbstractValidator<Usuarios>
    {
        public UsuarioValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Sobrenome)
                .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser fornecido")
                .EmailAddress().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.DataNascimento)
                .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Escolaridade)
                .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser fornecido");
        }
    }
}
