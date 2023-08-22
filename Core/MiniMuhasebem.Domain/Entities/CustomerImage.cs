using MiniMuhasebem.Domain.Common;

namespace MiniMuhasebem.Domain.Entities
{
    public class CustomerImage : AuditableEntity
    {
        public int CustomerId { get; set; }
        public string Path { get; set; }

        public Customer Customer { get; set; }
    }
}
