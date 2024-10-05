using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using Shared.Models;
using TicketApi.DAL;

namespace TicketApi.Services;

public class PrioridadesService(Context _context) : IGenericService<Prioridades>
{
    public async Task<Prioridades> Get(int id)
    {
        return (await _context.Prioridades.FindAsync(id))!;
    }

    public async Task<List<Prioridades>> GetAll()
    {
        return await _context.Prioridades.ToListAsync();
    }

    public async Task<Prioridades> Add(Prioridades type)
    {
        _context.Prioridades.Add(type);
        await _context.SaveChangesAsync();
        return type;
    }

    public async Task<bool> Update(Prioridades type)
    {
        _context.Entry(type).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(int id)
    {
        var type = await _context.Prioridades.FindAsync(id);
        if(type is null) return false;
        _context.Prioridades.Remove(type);
        return await _context.SaveChangesAsync() > 0;
    }
}
