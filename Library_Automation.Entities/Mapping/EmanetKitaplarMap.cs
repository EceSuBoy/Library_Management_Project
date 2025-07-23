using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Library_Automation.Entities.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Automation.Entities.Mapping
{
    public class EmanetKitaplarMap:EntityTypeConfiguration<EmanetKitaplar>
    {
        public EmanetKitaplarMap()
        {
            this.ToTable("EmanetKitaplar");
            this.HasKey(x => x.Id); //Primary Key
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); //Otomatik artan sayi

            this.HasRequired(x=>x.Kitaplar).WithMany(x=> x.EmanetKitaplar).HasForeignKey(x => x.kitapId);
            this.HasRequired(x => x.Uyeler).WithMany(x => x.EmanetKitaplar).HasForeignKey(x => x.uyeId);
        }
    }
}
