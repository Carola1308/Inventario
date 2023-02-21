using Gateways.Common.DTO.RequestDTO;
using Gateways.Common.DTO.ResponseDTO;
using Gateways.Data.Entity;
using Gateways.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gateways.Controllers
{
    [Route("api/inventario")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private GatewayService _gatewayService { get; set; }
        private PeripheralDeviceService _peripheralDeviceService { get; set; }
        public InventarioController(GatewayService gatewayService, PeripheralDeviceService peripheralDeiveceService) {
            _gatewayService= gatewayService;
            _peripheralDeviceService= peripheralDeiveceService;

        }

        // GET: api/<InventarioController>
        [HttpGet("gateways")]
        public List<Gateway> GetAllGateways()
        {
            return _gatewayService.GetAllGateways();
        }

        [HttpGet("peripheral-device")]
        public List<PeripheralDeviceResponseDTO> GetAllPeripheralDevice()
        {
            return _peripheralDeviceService.GetAllPeripheralDevices();
        }


        // GET api/<InventarioController>/5
        [HttpGet("gateways/{id}")]
        public ActionResult<Gateway> GetGateway(Guid id)
        {
            var result = _gatewayService.GetAllGateways().FirstOrDefault(gateway => gateway.Id == id) ;
            if (result == null) {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("peripheral-device/{id}")]
        public ActionResult<PeripheralDeviceResponseDTO> GetPeripheralDevice(Guid id)
        {
            var result = _peripheralDeviceService.GetAllPeripheralDevices().FirstOrDefault(periphecalDevice => periphecalDevice.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/<InventarioController>
        [HttpPost("gateways")]
        public ActionResult CreateGateWay(GatewayRequestDTO gateway)
        {
            _gatewayService.AddGateway(gateway);
            return Ok();
        }

        [HttpPost("peripheral-device")]
        public ActionResult CreatePeripheralDevice(PeripheralDeviceRequestDTO peripheralDevice)
        {
            _peripheralDeviceService.AddPeripheralDevice(peripheralDevice);
            return Ok();
        }
        
        [HttpPut("gateways/{id}")]
        public ActionResult UpdateGateway(Guid id, [FromBody]GatewayRequestDTO gateway)
        {
            _gatewayService.UpdateGateway(id, gateway);
            return Ok();
        }

        [HttpPut("peripheral-device/{id}")]
        public ActionResult UpdatePerapheralDevice(Guid id, PeripheralDeviceRequestDTO peripheralDevice)
        {
            _peripheralDeviceService.UpdatePeripheralDevice(id, peripheralDevice);
            return Ok();
        }

        // DELETE api/<InventarioController>/5
        [HttpDelete("gateways/{id}")]
        public ActionResult DeleteGateWay(Guid id)
        {
           _gatewayService.DeleteGateWay(id);
            return Ok();
        }

        [HttpDelete("peripheral-device/{id}")]
        public ActionResult DeletePeripheralDevice(Guid id)
        {
            _peripheralDeviceService.DeletePeripheralDevice(id);
            return Ok();
        }
    }
}
