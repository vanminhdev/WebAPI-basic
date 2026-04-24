using System;
using WebAPIDemo.Models;

namespace WebAPIDemo.Infrastructures;

public interface IApplicationDbContext
{
    public List<Product> Products { get; set; }
}
