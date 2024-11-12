using System.ComponentModel.DataAnnotations;

namespace VehiclesApp.Api;

public class VehicleMake
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Abrv { get; set; }
}

public class VehicleModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Abrv { get; set; }
    public required VehicleMake VehicleMake { get; set; }
}

public class Vehicle
{
    public int Id { get; set; }
    public required VehicleModel Model { get; set; }
    public List<VehicleAttribute> VehicleAttributes { get; set; } = new List<VehicleAttribute>();
}

public class Attribute
{
    [Key]
    public required string Name { get; set; }
    public List<VehicleAttribute> VehicleAttributes { get; set; } = new List<VehicleAttribute>();
}

public class VehicleAttribute
{
    public int Id { get; set; }
    public Vehicle Vehicle { get; set; } = null!;
    public Attribute Attribute { get; set; } = null!;
    public List<VehicleAttributeValue> VehicleAttributeValues { get; set; } = new List<VehicleAttributeValue>();
}

public class AttributeValue
{
    public int Id { get; set; }
    public required string Value { get; set; }
    public required Attribute Attribute { get; set; }
    public List<VehicleAttributeValue> VehicleAttributeValues { get; set; } = new List<VehicleAttributeValue>();
}

//  VehicleAttribute <-> AttributeValue JOIN TABLE
public class VehicleAttributeValue
{
    public int VehicleAttributeId { get; set; }
    public VehicleAttribute VehicleAttribute { get; set; } = null!;

    public int AttributeValueId { get; set; }
    public AttributeValue AttributeValue { get; set; } = null!;
}
