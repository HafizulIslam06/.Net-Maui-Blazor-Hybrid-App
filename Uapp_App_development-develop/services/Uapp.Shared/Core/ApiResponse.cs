using System.Net;
using Uapp.Shared.Http;

namespace Uapp.Shared.Core;

public class ApiResponse : IResponse
{
    public object Data { get; set; } = null!;
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    public ApiResponse(bool isSuccess, string message, HttpStatusCode statusCode)
    {
        IsSuccess = isSuccess;
        Message = message;
        StatusCode = statusCode;
    }
}
