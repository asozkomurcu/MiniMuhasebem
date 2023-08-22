using MiniMuhasebem.Domain.Entities;

namespace MiniMuhasebem.Application.Models.Dtos.CustomerDtos
{
    public class CustomerDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birtdate { get; set; }
        public Gender Gender { get; set; }
        public Account Account { get; set; }
    }
}
