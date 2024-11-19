using Microsoft.EntityFrameworkCore;

namespace VehiclesApp.Api.Data;

public class VehiclesAppContext : DbContext
{
    public VehiclesAppContext(DbContextOptions<VehiclesAppContext> options)
        : base(options) { }

    public DbSet<VehicleMake> VehicleMakes { get; set; }
    public DbSet<VehicleModel> VehicleModels { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<VehicleAttribute> VehicleAttributes { get; set; }
    public DbSet<Attribute> Attributes { get; set; }
    public DbSet<AttributeValue> AttributeValues { get; set; }
    public DbSet<VehicleAttributeValue> VehicleAttributeValues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VehicleModel>()
        .Navigation(vm => vm.VehicleMake)
        .AutoInclude();
        
        //  VehicleAttribute <-> AttributeValue JOIN TABLE CONFIG
        modelBuilder
            .Entity<VehicleAttributeValue>()
            .HasKey(vav => new { vav.VehicleAttributeId, vav.AttributeValueId });

        modelBuilder
            .Entity<VehicleAttributeValue>()
            .HasOne(vav => vav.VehicleAttribute)
            .WithMany(va => va.VehicleAttributeValues)
            .HasForeignKey(vav => vav.VehicleAttributeId);

        modelBuilder
            .Entity<VehicleAttributeValue>()
            .HasOne(vav => vav.AttributeValue)
            .WithMany(av => av.VehicleAttributeValues)
            .HasForeignKey(vav => vav.AttributeValueId);
    }
}
