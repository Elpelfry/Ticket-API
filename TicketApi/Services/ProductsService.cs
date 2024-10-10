using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using Shared.Models;
using TicketApi.DAL;

namespace TicketApi.Services;

public class ProductsService(Context _context) : IGenericService<Products>
{
    public async Task<Products> Get(int id)
    {
        return (await _context.Products.FindAsync(id))!;
    }

    public async Task<List<Products>> GetAll()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Products> Add(Products type)
    {
        _context.Products.Add(type);
        await _context.SaveChangesAsync();
        return type;
    }

    public async Task<bool> Update(Products type)
    {
        _context.Entry(type).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(int id)
    {
        var type = await _context.Products.FindAsync(id);
        if (type is null) return false;
        _context.Products.Remove(type);
        return await _context.SaveChangesAsync() > 0;
    }
}