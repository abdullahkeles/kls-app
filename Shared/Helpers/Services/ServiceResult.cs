using System.Net;
using System.Text.Json.Serialization;

namespace Shared.Helpers.Services;
public class ServiceResult<T> : ServiceResult
{
    public T? Value { get; set; }

    public static ServiceResult<T> Success(HttpStatusCode statusCode, T value, List<string> messages) => new ServiceResult<T>
    {
        Value = value,
        Messages = messages,
        IsSuccess = true,
        StatusCode = statusCode
    };
    public static ServiceResult<T> Success(HttpStatusCode statusCode, T value, string? message) => new ServiceResult<T> { Value = value, Messages = message is null ? null : [message], IsSuccess = true, StatusCode = statusCode };
    public static ServiceResult<T> Success(HttpStatusCode statusCode, T value) => new ServiceResult<T> { Value = value, IsSuccess = true, StatusCode = statusCode };
}
public class ServiceResult<T, TPag> : ServiceResult<T>
{
    public required TPag Pagination { get; set; }

    public static ServiceResult<T, TPag> Success(HttpStatusCode statusCode, T value, TPag pagination, List<string> messages) => new ServiceResult<T, TPag>
    {
        Value = value,
        Messages = messages,
        IsSuccess = true,
        StatusCode = statusCode,
        Pagination = pagination
    };
    public static ServiceResult<T, TPag> Success(HttpStatusCode statusCode, T value, TPag pagination, string? message) => new ServiceResult<T, TPag> { Value = value, Pagination = pagination, Messages = message is null ? null : [message], IsSuccess = true, StatusCode = statusCode };
    public static ServiceResult<T, TPag> Success(HttpStatusCode statusCode, T value, TPag pagination) => new ServiceResult<T, TPag> { Value = value, Pagination = pagination, IsSuccess = true, StatusCode = statusCode };
}
public class ServiceResult
{
    public List<string>? Messages { get; set; }
    [JsonIgnore] public HttpStatusCode StatusCode { get; set; }
    [JsonIgnore] public bool IsSuccess { get; set; }

    public static ServiceResult Success(HttpStatusCode statusCode, List<string> messages)
    {
        return new ServiceResult
        {
            Messages = messages,
            IsSuccess = true,
            StatusCode = statusCode
        };
    }
    public static ServiceResult Success(HttpStatusCode statusCode, string message)
    {
        return new ServiceResult { Messages = [message], IsSuccess = true, StatusCode = statusCode };
    }
    public static ServiceResult Success(HttpStatusCode statusCode)
    {
        return new ServiceResult { IsSuccess = true, StatusCode = statusCode };
    }
    public static ServiceResult Fail(HttpStatusCode statusCode, List<string> messages)
    {
        return new ServiceResult
        {
            Messages = messages,
            IsSuccess = false,
            StatusCode = statusCode,
        };
    }
    public static ServiceResult Fail(HttpStatusCode statusCode, string message)
    {
        return new ServiceResult
        {
            StatusCode = statusCode,
            Messages = [message],
            IsSuccess = false
        };
    }
    public static ServiceResult Fail(HttpStatusCode statusCode)
    {
        return new ServiceResult
        {
            StatusCode = statusCode,
            IsSuccess = false
        };
    }
}