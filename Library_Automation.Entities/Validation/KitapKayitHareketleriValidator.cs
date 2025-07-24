using FluentValidation;
using Library_Automation.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Automation.Entities.Validation
{
    public class KitapKayitHareketleriValidator:AbstractValidator<KitapHareketleri>
    {
        public KitapKayitHareketleriValidator()
        {
            RuleFor(x => x.YapilanIslem).MaximumLength(150).WithMessage("Field can be maximum 150 characters");
        }
    }
}
