using Library_Automation.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Automation.Entities.Mapping
{
    public class KitaplarMap:EntityTypeConfiguration<Kitaplar>
    {
        public KitaplarMap()
        {
            this.ToTable("Kitaplar");
            this.HasKey(x => x.Id); //Primary Key
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); //Otomatik artan sayi
            this.Property(x => x.BarkodNo).IsRequired().HasMaxLength(30);
            this.Property(x => x.KitapAdi).IsRequired().HasMaxLength(100);
            this.Property(x => x.Yazari).IsRequired().HasMaxLength(100);
            this.Property(x => x.YayinEvi).IsRequired().HasMaxLength(150);
        }
    }
}
