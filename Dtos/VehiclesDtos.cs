using System.ComponentModel.DataAnnotations;

namespace VehiclesApp.Api.Dtos;

public class VehicleMakeDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Abrv { get; set; } = null!;
}

public class VehicleMakeCreateDTO
{
    public string Name { get; set; } = null!;
    public string Abrv { get; set; } = null!;
}
public class VehicleMakeUpdateDTO
{
    public string? Name { get; set; }
    public string? Abrv { get; set; }
}

public class VehicleModelDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Abrv { get; set; } = null!;
    public VehicleMakeDTO VehicleMake { get; set; } = null!;
}

public class VehicleDTO
{
    public int Id { get; set; }
    public VehicleModelDTO Model { get; set; } = null!;
    public List<VehicleAttributeDTO> VehicleAttributes { get; set; } =
        new List<VehicleAttributeDTO>();
}

public class AttributeDTO
{
    public string Name { get; set; } = null!;
}

public class VehicleAttributeDTO
{
    public int Id { get; set; }
    public AttributeDTO Attribute { get; set; } = null!;
    public List<VehicleAttributeValueDTO> VehicleAttributeValues { get; set; } =
        new List<VehicleAttributeValueDTO>();
}

public class AttributeValueDTO
{
    public int Id { get; set; }
    public string Value { get; set; } = null!;
    public string AttributeName { get; set; } = null!;
}

public class VehicleAttributeValueDTO
{
    public int AttributeValueId { get; set; }
    public string AttributeValue { get; set; } = null!;
}
