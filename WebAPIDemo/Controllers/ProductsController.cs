using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private static List<Product> products = new List<Product>
    {
        new Product { Id = 1, Name = "Banh mi", Price = 15000 },
        new Product { Id = 2, Name = "Sua tuoi", Price = 12000 },
        new Product { Id = 3, Name = "Ca phe", Price = 20000 }
    };

    [HttpGet("get-all")]
    public ActionResult<IEnumerable<Product>> GetAll()
    {
        return Ok(products);
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public ActionResult<Product> Create(Product product)
    {
        product.Id = products.Count > 0 ? products.Max(p => p.Id) + 1 : 1;
        products.Add(product);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public ActionResult<Product> Update(int id, Product updatedProduct)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound();
        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound();
        products.Remove(product);
        return NoContent();
    }
}
