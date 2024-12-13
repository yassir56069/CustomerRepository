namespace CustomerRepo.Models
{
    public class Device
    {
        public int DeviceID { get; set; }
        public string DeviceCode { get; set; } = string.Empty;
        public string? DeviceModel { get; set; }

        public ICollection<CustomerDevice> CustomerDevices { get; set; } = [];
        public ICollection<APKInfo> APKInfos { get; set; } = [];
    }

}
