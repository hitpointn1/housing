using Housing.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Housing.Data
{
    public class HousingContext : DbContext
    {
        public HousingContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Billing> Billings { get; set; }
        public DbSet<AdditionalsBill> Additionals { get; set; }
        //public DbSet<ElectricityBill> ElectricityBills { get; set; }
        //public DbSet<HeatingBill> HeatingBills { get; set; }
        //public DbSet<Rent> Rents { get; set; }
        //public DbSet<RepairsBill> RepairsBills { get; set; }
        //public DbSet<WaterBill> WaterBills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
