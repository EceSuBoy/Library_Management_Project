using FluentValidation;
using Library_Automation.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Automation.Entities.Validation
{
    public class KitaplarValidator:AbstractValidator<Kitaplar>
    {
        public KitaplarValidator()
        {
            RuleFor(x => x.BarkodNo).NotEmpty().WithMessage("The field can not be empty");
            RuleFor(x => x.BarkodNo).MaximumLength(30).WithMessage("Field can be maximum 30 characters");

            RuleFor(x => x.KitapAdi).NotEmpty().WithMessage("The field can not be empty");
            RuleFor(x => x.KitapAdi).MaximumLength(100).WithMessage("Field can be maximum 100 characters");

            RuleFor(x => x.Yazari).NotEmpty().WithMessage("The field can not be empty");
            RuleFor(x => x.Yazari).MaximumLength(100).WithMessage("Field can be maximum 100 characters");

            RuleFor(x => x.YayinEvi).NotEmpty().WithMessage("The field can not be empty");
            RuleFor(x => x.YayinEvi).MaximumLength(150).WithMessage("Field can be maximum 150 characters");


        }
    }
}
