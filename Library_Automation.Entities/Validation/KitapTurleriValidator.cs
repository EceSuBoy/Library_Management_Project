using FluentValidation;
using Library_Automation.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Automation.Entities.Validation
{
    public class KitapTurleriValidator:AbstractValidator<KitapTurleri>
    {
        public KitapTurleriValidator() 
        {
            RuleFor(x => x.KitapTuru).NotEmpty().WithMessage("The book genre field can not be empty");
            RuleFor(x => x.KitapTuru).MaximumLength(150).WithMessage("The book genre field can be maximum 150 characters");
            RuleFor(x => x.KitapTuru).MinimumLength(5).WithMessage("The book genre field can be minimum 5 characters");



        }
    }
}
