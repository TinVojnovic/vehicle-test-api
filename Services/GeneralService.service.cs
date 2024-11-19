using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VehiclesApp.Api.Data;

public class GeneralService<TEntity> where TEntity : class
{
    private readonly VehiclesAppContext _context;
    private readonly DbSet<TEntity> _dbSet;
    private readonly IMapper _mapper;

    public GeneralService(VehiclesAppContext context, IMapper mapper)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
        _mapper = mapper;
    }

    public async Task<IEnumerable<TDto>> GetAllAsync<TDto>() where TDto : class
    {
        var entities = await _dbSet.ToListAsync();
        return _mapper.Map<IEnumerable<TDto>>(entities);
    }

    public async Task<TDto?> GetByIdAsync<TDto>(int id) where TDto : class
    {
        var entity = await _dbSet.FindAsync(id);
        return entity == null ? null : _mapper.Map<TDto>(entity);
    }

    public async Task<TDto> CreateAsync<TCreateDto, TDto>(TCreateDto dto) where TDto : class
    {
        var entity = _mapper.Map<TEntity>(dto);
        _dbSet.Add(entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<TDto>(entity);
    }

    public async Task<TDto?> UpdateAsync<TUpdateDto, TDto>(int id, TUpdateDto dto) where TDto : class
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) return null;

        _mapper.Map(dto, entity);
        await _context.SaveChangesAsync();
        return _mapper.Map<TDto>(entity);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) return false;

        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
