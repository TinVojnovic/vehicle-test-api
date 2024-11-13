namespace CoachingApp.Api.Endpoints;

using Microsoft.AspNetCore.Http;
using VehiclesApp.Api.Dtos;

public static class MakesController
{
    public static RouteGroupBuilder MapVehicleEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("vehicles/makes");

        group
            .MapGet(
                "/",
                async (VehicleMakeService service) =>
                {
                    return await service.GetAllVehicleMakes();
                }
            )
            .WithName("GetVehicleMakes");

        group
            .MapGet(
                "/{id}",
                async (VehicleMakeService service, int id) =>
                {
                    return await service.GetVehicleMakeById(id);
                }
            )
            .WithName("GetSingleVehicleMake");

        group
            .MapPost(
                "/",
                async (VehicleMakeService service, VehicleMakeCreateDTO vehicleMakeDto) =>
                {
                    var vehicleMake = await service.CreateVehicleMake(vehicleMakeDto);
                    return vehicleMake;
                }
            )
            .WithName("CreateVehicleMake");

        group
            .MapPut(
                "/{id}",
                async (VehicleMakeService service, VehicleMakeUpdateDTO vehicleMakeDto, int id) =>
                {
                    var vehicleMake = await service.UpdateVehicleMake(id, vehicleMakeDto);

                    if (vehicleMake == null)
                        return Results.BadRequest("VehicleMake with ID: " + id + " not found!");

                    return Results.Ok(vehicleMake);
                }
            )
            .WithName("UpdateVehicleMake");

        group
            .MapDelete(
                "/{id}",
                async (VehicleMakeService service, int id) =>
                {
                    string message = await service.DeleteVehicleMake(id);

                    return Results.Ok(message);
                }
            )
            .WithName("DeleteVehicleMake");

        return group;
    }
}
