namespace Gateways.Data.Entity
{
    public class PeripheralDevice
    {
        public Guid Id { get; set; }
        public string Vendor { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Status { get; set; }        
        public Gateway Gateway { get; set; }
    }
}
