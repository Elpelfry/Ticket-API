using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using Shared.Models;
using TicketApi.DAL;

namespace TicketApi.Services;

public class SistemasService(Context _context) : IGenericService<Sistemas>
{
    public async Task<Sistemas> Get(int id)
    {
        return (await _context.Sistemas.FindAsync(id))!;
    }

    public async Task<List<Sistemas>> GetAll()
    {
        return await _context.Sistemas.ToListAsync();
    }

    public async Task<Sistemas> Add(Sistemas type)
    {
        _context.Sistemas.Add(type);
        await _context.SaveChangesAsync();
        return type;
    }

    public async Task<bool> Update(Sistemas type)
    {
        _context.Entry(type).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(int id)
    {
        var type = await _context.Sistemas.FindAsync(id);
        if (type is null) return false;
        _context.Sistemas.Remove(type);
        return await _context.SaveChangesAsync() > 0;
    }
}
