using System;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIDemo.Dtos.Products;

public class FilterProductDto : FilterDto
{
    [FromQuery(Name = "minPrice")]
    public int? MinPrice { get; set; }

    [FromQuery(Name = "maxPrice")]
    public int? MaxPrice { get; set; }
}
