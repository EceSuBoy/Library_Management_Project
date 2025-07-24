using FluentValidation;
using Library_Automation.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Automation.Entities.Validation
{
    public class DuyurularValidator: AbstractValidator<Duyurular>
    {
        public DuyurularValidator() 
        {
            RuleFor(x => x.Baslik).NotEmpty().WithMessage("The title field can not be left empty");
            RuleFor(x => x.Duyuru).NotEmpty().WithMessage("The announcement field can not be left empty");
            RuleFor(x => x.Tarih).NotEmpty().WithMessage("The date field can not be left empty");
            RuleFor(x => x.Baslik).MaximumLength(150).WithMessage("The title can be maximum 150 characters");
            RuleFor(x => x.Duyuru).MaximumLength(500).WithMessage("Announcements can be maximum 500 characters");


        }
    }
}
