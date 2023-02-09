using System.ComponentModel.DataAnnotations;

namespace Gateways.Common.DTO.RequestDTO
{
    public class PeripheralDeviceRequestDTO
    {
        [Required]
        public string Vendor { get; set; }        
        public bool Status { get; set; }
    }
}
