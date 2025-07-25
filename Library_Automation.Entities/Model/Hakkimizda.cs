using FluentValidation.Attributes;
using Library_Automation.Entities.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Automation.Entities.Model
{
    [Validator(typeof(HakkimizdaValidator))]
    public class Hakkimizda
    {
        public int Id { get; set; }
        public string Icerik { get; set; }
        public string Aciklama { get; set; }
    }
}
