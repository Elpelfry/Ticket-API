using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace TicketApi.DAL;

public class Context :DbContext
{
    public Context(DbContextOptions<Context> options) : base(options){}

    public DbSet<Prioridades> Prioridades { get; set; }
    public DbSet<Clientes> Clientes { get; set; }
    public DbSet<Tickets> Tickets { get; set; }
    public DbSet<TicketsDetalle> TicketsDetalle { get; set; }
    public DbSet<Sistemas> Sistemas { get; set; }
    public DbSet<Products> Products { get; set; }
}
