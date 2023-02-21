using Gateways.Common.DTO.RequestDTO;
using Gateways.Common.DTO.ResponseDTO;
using Gateways.Data;
using Gateways.Data.Entity;

namespace Gateways.Services
{
    public class PeripheralDeviceService
    {   
        private InventaryContext _context;

        public PeripheralDeviceService(InventaryContext context)
        {
            _context = context;
        }

        public PeripheralDevice AddPeripheralDevice(PeripheralDeviceRequestDTO newPeripheralDevice)
        {
            var gateway = _context.Gateways.FirstOrDefault(g => g.Id == newPeripheralDevice.GatewayId);

            var createPeripheralDevice = new PeripheralDevice
            {
                Id = Guid.NewGuid(),
                Status = newPeripheralDevice.Status.ToLower() == "true",
                Vendor = newPeripheralDevice.Vendor,
                CreationDate = DateTime.Now,
                Gateway = gateway
            };

            _context.peripheralDevices.Add(createPeripheralDevice);
            _context.SaveChanges();
            return createPeripheralDevice;
        }

        public List<PeripheralDeviceResponseDTO> GetAllPeripheralDevices()
        {
            return _context.peripheralDevices.Select(device => new PeripheralDeviceResponseDTO 
            {
                Id = device.Id,
                Vendor = device.Vendor,
                Status = device.Status.ToString(),
                CreationDate = device.CreationDate.ToString("g"),
            }).ToList();
        }

        public PeripheralDeviceResponseDTO GetPeripheralDevice(Guid id)
        {
            var result = _context.peripheralDevices.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                throw new Exception("Peripherial Not Found");
            }
            var device = new PeripheralDeviceResponseDTO 
            { 
                Id = result.Id,
                Vendor= result.Vendor,
                Status = result.Status.ToString(),
                CreationDate = result.CreationDate.ToString("g"),
            };
            return device;
        }

        public PeripheralDevice UpdatePeripheralDevice(Guid Id, PeripheralDeviceRequestDTO newPeripheralDevice)
        {
            var peripheralDevice1 = _context.peripheralDevices.FirstOrDefault(x => x.Id == Id);
            if (peripheralDevice1 == null)
            {
                throw new Exception("Peripheral Device not found");
            }
            peripheralDevice1.Vendor = newPeripheralDevice.Vendor;
            peripheralDevice1.Status = newPeripheralDevice.Status.ToLower() == "true";

            _context.peripheralDevices.Update(peripheralDevice1);
            _context.SaveChanges();
            return peripheralDevice1;
        }

        public void DeletePeripheralDevice(Guid id)
        {
            var result = _context.peripheralDevices.FirstOrDefault(peripheralDevice => peripheralDevice.Id == id);
            if (result != null)
            {
                _context.peripheralDevices.Remove(result);
                _context.SaveChanges();
            }
        }

    }
}
