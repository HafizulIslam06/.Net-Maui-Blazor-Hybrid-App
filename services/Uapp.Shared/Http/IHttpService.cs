using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using System.Collections;
using Uapp.Shared.Core.Services.auth;

namespace Uapp.Shared.Http;

public interface IHttpService
{
    IHttpClientService<TRes> Request<TRes>() where TRes : IResponse, new();
    IHttpClientService<TRes, T> Request<TRes, T>() where TRes : IResponse, new() where T : class;
}
public class HttpService : IHttpService
{
    private readonly NavigationManager _navigationManager;
    private readonly IToastService _toastService;
    private readonly ITokenStorageService _tokenService;
    private readonly IHttpClientFactory _clientFactory;
    private Hashtable _requestCache;

    public HttpService(NavigationManager navigationManager, IToastService toastService, ITokenStorageService tokenService, IHttpClientFactory clientFactory)
    {
        _navigationManager = navigationManager;
        _toastService = toastService;
        _tokenService = tokenService;
        _clientFactory = clientFactory;
        _requestCache = new Hashtable();
    }

    public IHttpClientService<TRes> Request<TRes>()
        where TRes : IResponse, new()
    {
        return CreateServiceInstance<TRes, object>() as IHttpClientService<TRes>;
    }

    public IHttpClientService<TRes, T> Request<TRes, T>()
        where TRes : IResponse, new()
        where T : class
    {
        return CreateServiceInstance<TRes, T>() as IHttpClientService<TRes, T>;
    }

    private object CreateServiceInstance<TRes, T>()
        where TRes : IResponse, new()
        where T : class
    {
        var key = typeof(T).Name + typeof(TRes).Name;
        _requestCache = new Hashtable();

        if (!_requestCache.ContainsKey(key))
        {
            var repositoryType = typeof(HttpClientService<,>);
            var repositoryInstance = Activator.CreateInstance(
                repositoryType.MakeGenericType(typeof(TRes), typeof(T)),
                _navigationManager,
                _toastService,
                _tokenService,
                _clientFactory);

            _requestCache.Add(key, repositoryInstance);
        }

        return _requestCache[key];
    }
}

