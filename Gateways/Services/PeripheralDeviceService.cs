using Gateways.Common.DTO.RequestDTO;
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
            var createPeripheralDevice = new PeripheralDevice
            {
                Id = Guid.NewGuid(),
                Status= newPeripheralDevice.Status,
                Vendor = newPeripheralDevice.Vendor,
                CreationDate = DateTime.Now,
            };

            _context.peripheralDevices.Add(createPeripheralDevice);
            _context.SaveChanges();
            return createPeripheralDevice;
        }

        public List<PeripheralDevice> GetAllPeripheralDevices()
        {
            return _context.peripheralDevices.ToList();
        }

        public PeripheralDevice GetPeripheralDevice(Guid id)
        {
            var result = _context.peripheralDevices.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                throw new Exception("Peripherial Not Found");
            }
            return result;
        }

        public PeripheralDevice UpdatePeripheralDevice(Guid Id, PeripheralDeviceRequestDTO newPeripheralDevice)
        {
            var peripheralDevice1 = _context.peripheralDevices.FirstOrDefault(x => x.Id == Id);
            if (peripheralDevice1 == null)
            {
                throw new Exception("Peripheral Device not found");
            }
            peripheralDevice1.Vendor = newPeripheralDevice.Vendor;
            peripheralDevice1.Status = newPeripheralDevice.Status;

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
