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

    public CartController([FromServices] DataContext dataContext)
    {
        _context = dataContext;
    }
    [HttpGet]
    public async Task<ActionResult<List<Cart>>> getList()
    {
        var carts = await _context.Carts.ToListAsync();
        return carts;
    }
    [HttpPost]
    public async Task<ActionResult<Cart>> post([FromBody] Cart cart)
    {
        _context.Carts.Add(cart);
        await _context.SaveChangesAsync();
        return cart;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Cart>> getById( int id)
    {
        var cart = await _context.Carts.FindAsync(id);
        return cart == null ? NotFound() : Ok(cart);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> put(int id, [FromBody] Cart cart)
    {
        var cartExist = await _context.Carts.FindAsync(id);
        if (cartExist == null) return NotFound();
        _context.Entry(cartExist).State = EntityState.Detached;

        cart.Id = id;
        _context.Entry(cart).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> delete(int id)
    {
        var cartExist = await _context.Carts.FindAsync(id);
        if (cartExist == null) return NotFound();
        _context.Carts.Remove(cartExist);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}