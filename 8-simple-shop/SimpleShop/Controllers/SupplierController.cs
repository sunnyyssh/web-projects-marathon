using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Constants;
using SimpleShop.Database;
using SimpleShop.Model;
using SimpleShop.ViewModel;

namespace SimpleShop.Controllers;

[Authorize(Roles = RolesConstants.AdminAndSupplier)]
[Route("supplier")]
public sealed class SupplierController : Controller
{
    private readonly ShopDbContext _shopDbContext;
    
    private readonly UserManager<IdentityUser> _userManager;

    public SupplierController(ShopDbContext shopDbContext, UserManager<IdentityUser> userManager)
    {
        _shopDbContext = shopDbContext;
        _userManager = userManager;
    }
    
    [HttpGet("list")]
    public async Task<IActionResult> ProductsList()
    {
        string supplierId = await GetQueryingSupplierIdAsync();

        var products = await _shopDbContext.Products
            .Where(p => p.SupplierId == supplierId)
            .Include(p => p.Category)
            .ToListAsync();

        return View("ProductsList", products);
    }

    [HttpGet("create")]
    public IActionResult CreateProduct()
    {
        return View("CreateProduct", new ProductViewModel());
    }
    
    [NonAction]
    public async Task<string> GetQueryingSupplierIdAsync() => (await _userManager.GetUserAsync(User))!.Id;
}