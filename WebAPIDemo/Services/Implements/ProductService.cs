using System;
using WebAPIDemo.Exceptions;
using WebAPIDemo.Infrastructures;
using WebAPIDemo.Models;
using WebAPIDemo.Services.Abstracts;

namespace WebAPIDemo.Services.Implements;

public class ProductService : IProductService
{
    private readonly INotiService _notiService;
    private readonly IApplicationDbContext _dbContext; // Sử dụng ApplicationDbContext để quản lý dữ liệu sản phẩm

    public ProductService(IApplicationDbContext dbContext, INotiService notiService)
    {
        _dbContext = dbContext;
        _notiService = notiService;
    }

    public Product Create(Product product)
    {
        product.Id = _dbContext.Products.Count > 0 ? _dbContext.Products.Max(p => p.Id) + 1 : 1;
        _dbContext.Products.Add(product);
        return product;
    }

    public void Delete(int id)
    {
        var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            throw new UserFriendlyException($"Product with id {id} not found.");
        }
        _dbContext.Products.Remove(product);
    }

    public List<Product> GetAll()
    {
        return _dbContext.Products;
    }

    public Product GetById(int id)
    {
        return _dbContext.Products.FirstOrDefault(p => p.Id == id);
    }

    public Product Update(int id, Product updatedProduct)
    {
        var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
        if (product == null) return null;
        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;
        return product;
    }
}
