using Library_Automation.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Library_Automation.Entities.Mapping
{
    public class DuyurularMap : EntityTypeConfiguration<Duyurular>
    {
        public DuyurularMap()
        {
            this.ToTable("Duyurular");
            this.HasKey(x => x.Id); //Primary Key
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); //Otomatik artan sayi
            this.Property(x => x.Baslik).HasColumnType("varchar"); // Kolon turu
            this.Property(x => x.Baslik).IsRequired().HasMaxLength(150); //mAx karakter sayisi
            this.Property(x => x.Duyuru).IsRequired().HasMaxLength(500);
            this.Property(x => x.Aciklama).HasMaxLength(5000);

            this.Property(x => x.Id).HasColumnName("Id"); //kolon adlandirma
            this.Property(x => x.Baslik).HasColumnName("Baslik");
            this.Property(x => x.Duyuru).HasColumnName("Duyuru");
            this.Property(x => x.Aciklama).HasColumnName("Aciklama");
            this.Property(x => x.Tarih).HasColumnName("Tarih");
        }
    }
}
