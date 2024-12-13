namespace CustomerRepo.Models
{
    public class APKInfo
    {
        public int APKID { get; set; }
        public string APKName { get; set; } = string.Empty;
        public string APKPath { get; set; } = string.Empty;
        public string ApkVerNumber { get; set; } = string.Empty;
        public string DeviceCode { get; set; } = string.Empty;
        public string TokenValue { get; set; } = string.Empty;

        public Device Device { get; set; } = null!;
        public Token Token { get; set; } = null!;
    }

}
