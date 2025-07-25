using FluentValidation.Attributes;
using Library_Automation.Entities.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Automation.Entities.Model
{
    [Validator(typeof(RollerValidator))]
    public class Roller
    {
        public int Id { get; set; }
        public string Rol { get; set; }
        public List<KullaniciRolleri> KullaniciRolleri { get; set; }
    }
}
