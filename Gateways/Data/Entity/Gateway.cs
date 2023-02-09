namespace Gateways.Data.Entity
{
    public class Gateway
    {
        public Gateway()
        {
            peripheralDevices = new List<PeripheralDevice>();
        }
        public Guid Id { get; set; }
        public string GatewayName { get; set; }
        public string IPV4 { get; set;}

        public List<PeripheralDevice> peripheralDevices { get; set; }
    }
}
