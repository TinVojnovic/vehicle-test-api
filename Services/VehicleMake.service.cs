using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VehiclesApp.Api;
using VehiclesApp.Api.Data;
using VehiclesApp.Api.Dtos;

public class VehicleMakeService
{
    private readonly VehiclesAppContext _context;
    private readonly IMapper _mapper;

    public VehicleMakeService(VehiclesAppContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
}
