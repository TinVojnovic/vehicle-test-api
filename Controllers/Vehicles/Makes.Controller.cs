namespace CoachingApp.Api.Endpoints;

using Microsoft.AspNetCore.Http;
using VehiclesApp.Api;
using VehiclesApp.Api.Dtos;

public static class MakesController
{
    public static RouteGroupBuilder MapVehicleMakesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("vehicles/makes");

        //GET ALL VEHICLE MAKES
        group
            .MapGet(
                "/",
                async (GeneralService<VehicleMake> service) =>
                {
                    return await service.GetAllAsync<VehicleMakeDTO>();
                }
            )
            .WithName("GetVehicleMakes");

        //GET SINGLE VEHICLE MAKE
        group
            .MapGet(
                "/{id}",
                async (GeneralService<VehicleMake> service, int id) =>
                {
                    var vehicleMake = await service.GetByIdAsync<VehicleMake>(id);

                    if (vehicleMake == null)
                        return Results.BadRequest("VehicleMake with ID: " + id + " not found!");

                    return Results.Ok(vehicleMake);
                }
            )
            .WithName("GetSingleVehicleMake");

        //CREATE VEHICLE MAKE
        group
            .MapPost(
                "/",
                async (GeneralService<VehicleMake> service, VehicleMakeCreateDTO vehicleMakeDto) =>
                {
                    var vehicleMake = await service.CreateAsync<
                        VehicleMakeCreateDTO,
                        VehicleMakeDTO
                    >(vehicleMakeDto);
                    return vehicleMake;
                }
            )
            .WithName("CreateVehicleMake");

        //UPDATE VEHICLE MAKE
        group
            .MapPut(
                "/{id}",
                async (
                    GeneralService<VehicleMake> service,
                    VehicleMakeUpdateDTO vehicleMakeDto,
                    int id
                ) =>
                {
                    var vehicleMake = await service.UpdateAsync<
                        VehicleMakeUpdateDTO,
                        VehicleMakeDTO
                    >(id, vehicleMakeDto);

                    if (vehicleMake == null)
                        return Results.BadRequest("VehicleMake with ID: " + id + " not found!");

                    return Results.Ok(vehicleMake);
                }
            )
            .WithName("UpdateVehicleMake");

        //DELETE VEHICLE MAKE
        group
            .MapDelete(
                "/{id}",
                async (GeneralService<VehicleMake> service, int id) =>
                {
                    bool success = await service.DeleteAsync(id);

                    if (success)
                        return Results.Ok("Successfully deleted VehicleMake with ID: " + id);

                    return Results.NotFound("VehicleMake with ID: " + id + " not found!");
                }
            )
            .WithName("DeleteVehicleMake");

        return group;
    }
}
