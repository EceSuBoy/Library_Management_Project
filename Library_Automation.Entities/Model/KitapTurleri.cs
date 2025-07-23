using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Automation.Entities.Model
{
    public class KitapTurleri
    {
        [Key]
        public int KitapId { get; set; }
        [StringLength(50)]
        public string KitapTuru { get; set; }
        public string Aciklama { get; set; }
    }
}
