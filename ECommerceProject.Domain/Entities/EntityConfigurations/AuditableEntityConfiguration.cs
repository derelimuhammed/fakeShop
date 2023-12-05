using ECommerceProject.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.Domain.Entities.EntityConfigurations
{
    public class AuditableEntityConfiguration<T> : BaseEntityConfiguration<T> where T : AuditableEntity
        //AuditableEntity, BaseEntity'den kalıtım aldığı için bu şekilde kullanabiliyoruz
    {
        public override void Configure(EntityTypeBuilder<T> builder) //override ile virtual metodun üzerine yazmış oluyoruz
        {
            base.Configure(builder); //Buradaki ifade ile base dekileri de Configure etmiş oluyor
            builder.Property(x => x.DeletedBy).IsRequired(false);
            builder.Property(x => x.DeletedDate).IsRequired(false);
        }
    }
}
