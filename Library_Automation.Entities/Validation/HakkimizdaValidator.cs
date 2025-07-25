using FluentValidation;
using Library_Automation.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Automation.Entities.Validation
{
    public class HakkimizdaValidator:AbstractValidator<Hakkimizda>
    {
        public HakkimizdaValidator()
        {
            RuleFor(x => x.Icerik).NotEmpty().WithMessage("The context field can not be empty");
            RuleFor(x => x.Icerik).Length(500).WithMessage("The context can be maximum 500 characters");
        }
    }
}
