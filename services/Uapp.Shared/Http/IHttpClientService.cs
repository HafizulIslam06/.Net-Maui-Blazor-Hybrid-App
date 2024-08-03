namespace Uapp.Shared.Http;

public interface IHttpClientService<TResponse, T> where TResponse : IResponse, new() where T : class
{
    Task<TResponse> Post<T>(string url, T data, bool isForm = false, string redirectUrl = null, bool isToast = false);
    Task<TResponse> Put<T>(string url, T data, bool isForm = false, string redirectUrl = null, bool isToast = false);
}

public interface IHttpClientService<TResponse> where TResponse : IResponse, new()
{
    Task<TResponse> Get(string url);
    Task<TResponse> Post(string url, object data, bool isForm = false, string redirectUrl = null, bool isToast = false);
    Task<TResponse> Put(string url, string redirectUrl = null, bool isToast = false);
    Task<TResponse> Delete(string url, string redirectUrl = null, bool isToast = false);
}
