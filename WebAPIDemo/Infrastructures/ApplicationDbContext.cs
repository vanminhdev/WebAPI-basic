using System;
using WebAPIDemo.Models;

namespace WebAPIDemo.Infrastructures;

public class ApplicationDbContext : IApplicationDbContext
{   
    public List<Product> Products { get; set; } = new List<Product>
    {
        new Product { Id = 1, Name = "Banh mi", Price = 15000 },
        new Product { Id = 2, Name = "Sua tuoi", Price = 12000 },
        new Product { Id = 3, Name = "Ca phe", Price = 20000 }
    };
}
