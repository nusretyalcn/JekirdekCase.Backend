using Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.FirstName).MinimumLength(2);
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("İsim boş olamaz");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("Soyisim boş olamaz");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Mail adresi adı boş olamaz");
            RuleFor(p => p.Email).EmailAddress().WithMessage("Geçerli bir mail adresi giriniz");
        }
    }
}
