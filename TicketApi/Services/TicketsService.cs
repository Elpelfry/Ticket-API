using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using Shared.Models;
using TicketApi.DAL;

namespace TicketApi.Services;

public class TicketsService(Context _context) : IGenericService<Tickets>
{
    public async Task<Tickets> Get(int id)
    {
        return (await _context.Tickets
            .Include(t => t.TicketsDetalle)
                .FirstOrDefaultAsync(t => t.TicketId == id))!;
    }

    public async Task<List<Tickets>> GetAll()
    {
        return await _context.Tickets
            .Include(t => t.TicketsDetalle)
                .ToListAsync();
    }

    public async Task<Tickets> Add(Tickets type)
    {
        _context.Tickets.Add(type);
        await _context.SaveChangesAsync();
        return type;
    }

    public async Task<bool> Update(Tickets type)
    {
        _context.Entry(type).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(int id)
    {
        var type = await _context.Tickets.FindAsync(id);
        if (type is null) return false;

        await _context.TicketsDetalle
            .Where(t => t.TicketId == id)
                .ExecuteDeleteAsync();

        _context.Tickets.Remove(type);
        return await _context.SaveChangesAsync() > 0;
    }
}
