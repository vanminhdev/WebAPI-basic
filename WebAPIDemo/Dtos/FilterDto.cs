using System;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIDemo.Dtos;

public class FilterDto
{
    [FromQuery(Name = "pageSize")]
    public int PageSize { get; set; }

    [FromQuery(Name = "pageIndex")]
    public int PageIndex { get; set; }

    [FromQuery(Name = "keyword")]
    public string Keyword { get; set; }

    public int GetSkipCount()
    {
        return (PageIndex - 1) * PageSize;
    }
}
