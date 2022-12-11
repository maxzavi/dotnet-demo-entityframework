namespace wa_sample.Data;

using Microsoft.EntityFrameworkCore;
using wa_sample.Model;
public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options): base (options){

    }
    public DbSet <Cart> Carts {get;set;}
}