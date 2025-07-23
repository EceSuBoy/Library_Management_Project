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
    public class RollerMap:EntityTypeConfiguration<Roller>
    {
        public RollerMap() 
        {
            this.ToTable("Roller");
            this.HasKey(x => x.Id); //Primary Key
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); //Otomatik artan sayi
            this.Property(x => x.Rol).IsRequired().HasMaxLength(50);
        }
    }
}
