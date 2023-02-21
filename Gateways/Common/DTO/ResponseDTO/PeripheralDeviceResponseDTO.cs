using Gateways.Data.Entity;

namespace Gateways.Common.DTO.ResponseDTO
{
    public class PeripheralDeviceResponseDTO
    {
        public Guid Id { get; set; }
        public string Vendor { get; set; }
        public string CreationDate { get; set; }
        public string Status { get; set; }
        public Gateway Gateway { get; set; }
    }
}
