using FluentValidation;
using Library_Automation.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Automation.Entities.Validation
{
    public class IletisimValidator :AbstractValidator<Iletisim>
    {
        public IletisimValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("The Email field can not be empty");
            RuleFor(x => x.Email).Length(150).WithMessage("The Email can be maximum 150 characters");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Please enter Email");


            RuleFor(x => x.AdiSoyadi).NotEmpty().WithMessage("The Username field can not be empty");
            RuleFor(x => x.Email).MaximumLength(100).WithMessage("The Username field can be maximum 100 characters");
            RuleFor(x => x.Baslik).NotEmpty().WithMessage("The Header field can not be empty");
            RuleFor(x => x.Baslik).MaximumLength(200).WithMessage("The Header field can be maximum 200 characters");


            RuleFor(x => x.Mesaj).NotEmpty().WithMessage("The Message field can not be empty");
            RuleFor(x => x.Mesaj).MaximumLength(500).WithMessage("The Message field can be maximum 500 characters");

        }
    }
}
