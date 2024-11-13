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

    public async Task<IEnumerable<VehicleMakeDTO>> GetAllVehicleMakes()
    {
        var vehicleMakes = await _context.VehicleMakes.ToListAsync();
        return _mapper.Map<IEnumerable<VehicleMakeDTO>>(vehicleMakes);
    }

    public async Task<VehicleMakeDTO?> GetVehicleMakeById(int id)
    {
        var vehicleMake = await _context.VehicleMakes.FirstOrDefaultAsync(vm => vm.Id == id);

        return vehicleMake == null ? null : _mapper.Map<VehicleMakeDTO>(vehicleMake);
    }

    public async Task<VehicleMakeDTO> CreateVehicleMake(VehicleMakeCreateDTO vehicleMakeDto)
    {
        var vehicleMake = _mapper.Map<VehicleMake>(vehicleMakeDto);

        _context.VehicleMakes.Add(vehicleMake);
        await _context.SaveChangesAsync();

        var createdVehicleMake = await _context.VehicleMakes.FirstOrDefaultAsync(vm =>
            vm.Id == vehicleMake.Id
        );

        return _mapper.Map<VehicleMakeDTO>(createdVehicleMake);
    }

    public async Task<VehicleMakeDTO> UpdateVehicleMake(int id, VehicleMakeUpdateDTO vehicleMakeDto)
    {
        var existingVehicleMake = await _context.VehicleMakes.FirstOrDefaultAsync(vm =>
            vm.Id == id
        );

        if (existingVehicleMake != null)
        {
            if (vehicleMakeDto.Name != null)
                existingVehicleMake.Name = vehicleMakeDto.Name;

            if (vehicleMakeDto.Abrv != null)
                existingVehicleMake.Abrv = vehicleMakeDto.Abrv;

            await _context.SaveChangesAsync();

            return _mapper.Map<VehicleMakeDTO>(existingVehicleMake);
        }

        return null;
    }

    public async Task<string> DeleteVehicleMake(int id)
    {
        var vehicleMake = await _context.VehicleMakes.FirstOrDefaultAsync(vm => vm.Id == id);

        if (vehicleMake != null)
        {
            _context.VehicleMakes.Remove(vehicleMake);
            await _context.SaveChangesAsync();

            return "Successfully deleted vehicle make.";
        }

        return "VehicleMake with ID: " + id + " not found!";
    }
}
