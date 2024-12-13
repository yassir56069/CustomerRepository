using NuGet.Common;

namespace CustomerRepo.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerKey { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string? CustomerNote { get; set; }

        public ICollection<CustomerDevice> CustomerDevices { get; set; } = [];
        public ICollection<Token> Tokens { get; set; } = [];
    }
}
