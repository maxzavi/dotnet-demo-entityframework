using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wa_sample.Data;
using wa_sample.Model;
namespace wa_sample.Controllers;

[ApiController]
[Route("cart/v1")]

public class CartController: ControllerBase
{
    
    private DataContext _context;

    public CartController(DataContext dataContext){
        _context= dataContext;
    }

    [HttpGet] 
    public async Task<ActionResult<List<Cart>>> getList ([FromServices] DataContext context){
        var carts = await context.Carts.ToListAsync();
        return carts;
    }

    [HttpPost]
    public async Task<ActionResult<Cart>> post ([FromServices] DataContext context, [FromBody] Cart cart){
        context.Carts.Add(cart);
        await context.SaveChangesAsync();
        return cart;
    } 
}