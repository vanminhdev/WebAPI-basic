using System;
using WebAPIDemo.Dtos;
using WebAPIDemo.Dtos.Products;
using WebAPIDemo.Models;

namespace WebAPIDemo.Services.Abstracts;

public interface IProductService
{
    public PagingDto<Product> GetAll(FilterProductDto filter);
    public Product GetById(int id);
    public Product Create(Product product);
    public Product Update(int id, Product updatedProduct);
    public void Delete(int id);
}
