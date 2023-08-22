using MiniMuhasebem.Domain.Common;

namespace MiniMuhasebem.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public string CategoryName { get; set; }

    }
}
