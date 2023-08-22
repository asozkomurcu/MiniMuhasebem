using MiniMuhasebem.Domain.Common;

namespace MiniMuhasebem.Domain.Entities
{
    public class Account : BaseEntity
    {
        public int CustomerId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string? LastUserIp { get; set; }
        public Roles Role { get; set; }

        public Customer Customer { get; set; }
    }

    public enum Roles
    {
        User = 1,
        Admin = 2
    }
}
