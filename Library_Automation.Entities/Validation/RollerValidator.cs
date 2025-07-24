using FluentValidation;
using Library_Automation.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Automation.Entities.Validation
{
    public class RollerValidator: AbstractValidator<Roller>
    {

        public RollerValidator() 
        {
            RuleFor(x => x.Rol).NotEmpty().WithMessage("The Role field can not be empty");
            RuleFor(x => x.Rol).MaximumLength(50).WithMessage("The Role field can be maximum 50 characters");
        }
    }
}
