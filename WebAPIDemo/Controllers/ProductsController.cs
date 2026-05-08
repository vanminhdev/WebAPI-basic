using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Dtos;
using WebAPIDemo.Exceptions;
using WebAPIDemo.Models;
using WebAPIDemo.Services.Abstracts;
using WebAPIDemo.Services.Implements;

namespace WebAPIDemo.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService; // Dependency Injection

    /// <summary>
    /// Constructor with dependency injection of IProductService. The actual implementation (ProductService) will be provided by the DI container at runtime.
    /// Đang áp dụng SOLID - Dependency Inversion Principle (DIP) khi controller phụ thuộc vào abstraction (interface) thay vì implementation cụ thể. Điều này giúp tăng tính linh hoạt và khả năng mở rộng của ứng dụng. Nếu sau này muốn thay đổi cách quản lý sản phẩm, chỉ cần tạo một class mới implement IProductService mà không cần sửa code trong controller.
    /// </summary>
    /// <param name="productService"></param>
    public ProductsController(IProductService productService) // Dependency Injection
    {
        _productService = productService;
    }

    [HttpGet("get-all")]
    public ActionResult<IEnumerable<Product>> GetAll([FromQuery] FilterDto filter)
    {
        return Ok(_productService.GetAll(filter));
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = _productService.GetById(id);
        if (product == null) return NotFound();
        return Ok();
    }

    [HttpPost]
    public ActionResult<Product> Create(Product product)
    {
        var createdProduct = _productService.Create(product);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public ActionResult<Product> Update(int id, Product updatedProduct)
    {
        var product = _productService.Update(id, updatedProduct);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _productService.Delete(id);
        }
        catch (UserFriendlyException ex)
        {
            return Ok(new { errorCode = ex.ErrorCode, message = ex.Message });
        }
        return NoContent();
    }
}
