namespace CustomerRepo.Models
{
    public class Token
    {
        public int TokenID { get; set; }
        public string CustomerKey { get; set; } = string.Empty;
        public string TokenValue { get; set; } = string.Empty;
        public DateTime TokenInitDate { get; set; }
        public DateTime? TokenExpiry { get; set; }

        public Customer Customer { get; set; } = null!;
    }

}
