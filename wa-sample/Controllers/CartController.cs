using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wa_sample.Data;
using wa_sample.Model;
namespace wa_sample.Controllers;

[ApiController]
[Route("cart/v1")]

public class CartController : ControllerBase
{

    private DataContext _context;

    public CartController(DataContext dataContext)
    {
        _context = dataContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<Cart>>> getList([FromServices] DataContext context)
    {
        var carts = await context.Carts.ToListAsync();
        return carts;
    }

    [HttpPost]
    public async Task<ActionResult<Cart>> post([FromServices] DataContext context, [FromBody] Cart cart)
    {
        context.Carts.Add(cart);
        await context.SaveChangesAsync();
        return cart;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Cart>> getById([FromServices] DataContext context, int id)
    {
        var cart = await context.Carts.FindAsync(id);
        return cart == null ? NotFound() : Ok(cart);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> put([FromServices] DataContext context, int id, [FromBody] Cart cart)
    {
        var cartExist = await context.Carts.FindAsync(id);
        if (cartExist == null) return NotFound();
        context.Entry(cartExist).State = EntityState.Detached;

        cart.Id = id;
        context.Entry(cart).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> delete([FromServices] DataContext context, int id)
    {
        var cartExist = await context.Carts.FindAsync(id);
        if (cartExist == null) return NotFound();
        context.Carts.Remove(cartExist);
        await context.SaveChangesAsync();
        return NoContent();
    }
}