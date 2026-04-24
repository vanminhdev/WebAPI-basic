using System;
using WebAPIDemo.Models;

namespace WebAPIDemo.Services.Abstracts;

public interface IProductService
{
    public List<Product> GetAll();
    public Product GetById(int id);
    public Product Create(Product product);
    public Product Update(int id, Product updatedProduct);
    public void Delete(int id);
}
