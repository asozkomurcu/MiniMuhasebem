using Microsoft.AspNetCore.Http;

namespace MiniMuhasebem.Application.Models.RequestModels.CustomerImageRM
{
    public class CreateCustomerImageVM
    {
        public int? CustomerId { get; set; }
        public string UploadedImage { get; set; }
    }
}
