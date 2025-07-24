using FluentValidation;
using Library_Automation.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Automation.Entities.Validation
{
    public class KullanicilarValidator:AbstractValidator<Kullanicilar>
    {
        public KullanicilarValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("The Email field can not be empty");
            RuleFor(x => x.Email).Length(150).WithMessage("The Email can be maximum 150 characters");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Please enter Email");


            RuleFor(x => x.AdiSoyadi).NotEmpty().WithMessage("The Username field can not be empty");
            RuleFor(x => x.Email).MaximumLength(100).WithMessage("The Username field can be maximum 100 characters");

            RuleFor(x => x.KullaniciAdi).NotEmpty().WithMessage("The Username field can not be empty");
            RuleFor(x => x.KullaniciAdi).MaximumLength(30).WithMessage("The Username field can be maximum 30 characters");


            RuleFor(x => x.Sifre).NotEmpty().WithMessage("The Password field can not be empty");
            RuleFor(x => x.Sifre).MaximumLength(15).WithMessage("The Password field can be maximum 15 characters");

            RuleFor(x => x.Telefon).NotEmpty().WithMessage("The Phone field can not be empty");
            RuleFor(x => x.Telefon).MaximumLength(20).WithMessage("The Phone field can be maximum 20 characters");

            RuleFor(x => x.Adres).NotEmpty().WithMessage("The Address field can not be empty");
            RuleFor(x => x.Adres).MaximumLength(500).WithMessage("The Address field can be maximum 500 characters");
        }
    }
}
