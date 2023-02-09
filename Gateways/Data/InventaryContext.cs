using Gateways.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Gateways.Data
{
    public class InventaryContext : DbContext
    {
        public InventaryContext(DbContextOptions<InventaryContext> options) : base(options)
        {
        }

        public DbSet<Gateway> Gateways { get; set; }
        public DbSet<PeripheralDevice> peripheralDevices { get; set; }

    }
}
