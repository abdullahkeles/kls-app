using System;

namespace Shared.Helpers.Services;

public class PaginationRequest
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
