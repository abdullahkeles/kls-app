namespace Shared.Helpers.Services;

public record class PaginationResponse<T>(int PageNumber, int PageSize, int TotalPages, int TotalRecords, T Value);
