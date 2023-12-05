using ECommerceProject.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceProject.Domain.Concrete
{
    public class Files : AuditableEntity
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public string Storage { get; set; }
        [NotMapped]
        public override DateTime? UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
    }
}
