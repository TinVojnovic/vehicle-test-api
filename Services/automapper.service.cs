using AutoMapper;
using VehiclesApp.Api;
using VehiclesApp.Api.Dtos;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<VehicleMake, VehicleMakeDTO>();

        CreateMap<VehicleModel, VehicleModelDTO>();

        CreateMap<Vehicle, VehicleDTO>();

        CreateMap<VehiclesApp.Api.Attribute, AttributeDTO>();

        CreateMap<VehicleAttribute, VehicleAttributeDTO>();

        CreateMap<AttributeValue, AttributeValueDTO>()
            .ForMember(dest => dest.AttributeName, opt => opt.MapFrom(src => src.Attribute.Name));

        CreateMap<VehicleAttributeValue, VehicleAttributeValueDTO>()
            .ForMember(
                dest => dest.AttributeValue,
                opt => opt.MapFrom(src => src.AttributeValue.Value)
            );
    }
}
