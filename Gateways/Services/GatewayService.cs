using Gateways.Common.DTO.RequestDTO;
using Gateways.Data;
using Gateways.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Gateways.Services
{
    public class GatewayService
    {
        private InventaryContext _context;
        private PeripheralDeviceService _peripheralDeviceService;

        public GatewayService(InventaryContext context,PeripheralDeviceService peripheralDeviceService)
        {
            _context = context;
            _peripheralDeviceService = peripheralDeviceService;
        }

        public Gateway AddGateway(GatewayRequestDTO gateway)
        {
            var newGateway = new Gateway { 
                Id = Guid.NewGuid(),
                GatewayName = gateway.GatewayName,
                IPV4 = gateway.IPV4,
            };
            //foreach (var deviceId in gateway.peripheralDevices)
            //{

            //    newGateway.peripheralDevices.Add(_peripheralDeviceService.GetPeripheralDevice(deviceId)); 
            //}
            _context.Gateways.Add(newGateway);
            _context.SaveChanges();
            return newGateway;
        }

        public List<Gateway> GetAllGateways() {
           return _context.Gateways.Include(gateway => gateway.peripheralDevices).ToList();            
        }

        public Gateway UpdateGateway(Guid Id, GatewayRequestDTO newGateway)
        {
            var Gateway = _context.Gateways.FirstOrDefault(x => x.Id == Id);
            if (newGateway == null)
            {
                throw new Exception("Gateway not found");
            }
            Gateway.GatewayName = newGateway.GatewayName;
            Gateway.IPV4 = newGateway.IPV4;
            //foreach (var deviceId in newGateway.peripheralDevices)
            //{
            //    Gateway.peripheralDevices.Add(_peripheralDeviceService.GetPeripheralDevice(deviceId));
            //}            
            _context.Gateways.Update(Gateway);
            _context.SaveChanges();
            return Gateway;
        }

        public void DeleteGateWay(Guid id)
        {
            var result = _context.Gateways.FirstOrDefault(gateway => gateway.Id == id);
            if (result != null)
            {
                _context.Gateways.Remove(result);
                _context.SaveChanges();
            }
        }


    }

}
