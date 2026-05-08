using System;

namespace WebAPIDemo.Dtos.Products;

public class FilterProductDto : FilterDto
{
    public int? MinPrice { get; set; }
    public int? MaxPrice { get; set; }
}
