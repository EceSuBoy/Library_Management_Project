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
    public class IletisimMap:EntityTypeConfiguration<Iletisim>
    {
        public IletisimMap()
        {
            this.ToTable("Iletisim");
            this.HasKey(x => x.Id); //Primary Key
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); //Otomatik artan sayi
            this.Property(x => x.AdiSoyadi).IsRequired().HasMaxLength(100);
            this.Property(x => x.Aciklama).HasMaxLength(5000);
            this.Property(x => x.Email).IsRequired().HasMaxLength(100);
            this.Property(x => x.Baslik).IsRequired().HasMaxLength(200);
            this.Property(x => x.Mesaj).IsRequired().HasMaxLength(500);
        }
    }
}
