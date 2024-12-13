namespace CustomerRepo.Models
{
    public class CustomerDevice
    {
        public int CustomerID { get; set; }
        public Customer Customer { get; set; } = null!;

        public int DeviceID { get; set; }
        public Device Device { get; set; } = null!;
    }

}
