using Library_Automation.Entities.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Automation.Entities.Mapping
{
    public class KitapTurleriMap:EntityTypeConfiguration<KitapTurleri>
    {
        public KitapTurleriMap()
        {
            this.ToTable("KitapTurleri");
            this.HasKey(x => x.KitapId); //Primary Key
            this.Property(x => x.KitapId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); //Otomatik artan sayi
            this.Property(x => x.KitapTuru).IsRequired().HasMaxLength(150);
            this.Property(x => x.Aciklama).HasMaxLength(5000);
        }
    }
}
