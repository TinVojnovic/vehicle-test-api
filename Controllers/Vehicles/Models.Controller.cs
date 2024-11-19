namespace CoachingApp.Api.Endpoints;

using Microsoft.AspNetCore.Http;
using VehiclesApp.Api;
using VehiclesApp.Api.Dtos;

public static class ModelsController
{
    public static RouteGroupBuilder MapVehicleModelsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("vehicles/models");

        //GET ALL VEHICLE MODELS
        group
            .MapGet(
                "/",
                async (GeneralService<VehicleModel> service) =>
                {
                    return await service.GetAllAsync<VehicleModelDTO>();
                }
            )
            .WithName("GetVehicleModels");

        //GET SINGLE VEHICLE MODELS
        group
            .MapGet(
                "/{id}",
                async (GeneralService<VehicleModel> service, int id) =>
                {
                    var vehicleModel = await service.GetByIdAsync<VehicleModelDTO>(id);

                    if (vehicleModel == null)
                        return Results.BadRequest("VehicleModel with ID: " + id + " not found!");

                    return Results.Ok(vehicleModel);
                }
            )
            .WithName("GetSingleVehicleModels");

        //CREATE VEHICLE MODELS
        group
            .MapPost(
                "/",
                async (GeneralService<VehicleModel> service, VehicleModelCreateDTO vehicleMakeDto) =>
                {
                    var createdVehicleModel = await service.CreateAsync<VehicleModelCreateDTO, VehicleModelDTO>(vehicleMakeDto);

                    //TODO: Figure out why VehicleMake isn't being return like in the getById route
                    var vehicleModel = await service.GetByIdAsync<VehicleModelDTO>(createdVehicleModel.Id); //To eagerly load VehicleMake
                    
                    return vehicleModel;
                }
            )
            .WithName("CreateVehicleModels");

        //UPDATE VEHICLE MODELS
        group
            .MapPut(
                "/{id}", async (GeneralService<VehicleModel> service, VehicleModelUpdateDTO vehicleModelDto, int id) =>
                {
                    var vehicleModel = await service.UpdateAsync<VehicleModelUpdateDTO, VehicleModelDTO>(id, vehicleModelDto);

                    if (vehicleModel == null)
                        return Results.BadRequest("VehicleModel with ID: " + id + " not found!");

                    return Results.Ok(vehicleModel);
                }
            )
            .WithName("UpdateVehicleModels");

        //DELETE VEHICLE MODELS
        group
            .MapDelete(
                "/{id}",
                async (GeneralService<VehicleModel> service, int id) =>
                {
                    bool success = await service.DeleteAsync(id);

                    if (success)
                        return Results.Ok("Successfully deleted VehicleModel with ID: " + id);

                    return Results.NotFound("VehicleModel with ID: " + id + " not found!");
                }
            )
            .WithName("DeleteVehicleModels");

        return group;
    }
}
