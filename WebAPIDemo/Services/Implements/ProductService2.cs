using System;
using WebAPIDemo.Dtos;
using WebAPIDemo.Dtos.Products;
using WebAPIDemo.Models;
using WebAPIDemo.Services.Abstracts;

namespace WebAPIDemo.Services.Implements;

public class ProductService2 : IProductService
{
    public Product Create(Product product)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public PagingDto<Product> GetAll(FilterProductDto filter)
    {
        throw new NotImplementedException();
    }

    public Product GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Product Update(int id, Product updatedProduct)
    {
        throw new NotImplementedException();
    }
}
