using System.ComponentModel.DataAnnotations;

namespace Gateways.Common.DTO.RequestDTO
{
    public class PeripheralDeviceRequestDTO
    {
        
        public string Vendor { get; set; }        
        public string Status { get; set; }
        public Guid GatewayId { get; set; }
    }
}
