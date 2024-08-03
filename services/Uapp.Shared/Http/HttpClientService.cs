using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Uapp.Shared.Core.Services.auth;

namespace Uapp.Shared.Http;


public class HttpClientService<TResponse, T> : IHttpClientService<TResponse, T>, IHttpClientService<TResponse> where TResponse : IResponse, new() where T : class
{
    private readonly HttpClient _httpClient;
    private readonly NavigationManager _navigationManager;
    private readonly IToastService _toastService;
    private readonly ITokenStorageService _tokenService;
    private readonly TResponse _result;

    public HttpClientService(NavigationManager navigationManager, IToastService toastService, ITokenStorageService tokenService, IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ServerAPI");
        _navigationManager = navigationManager;
        _toastService = toastService;
        _result = new TResponse()
        {
            Message = "Failed!",
            IsSuccess = false
        };
        _tokenService = tokenService;
    }
    internal async Task ResolveAuthClient()
    {
        var accessToken = await _tokenService.GetAccessToken();

        if (!string.IsNullOrEmpty(accessToken))
        {

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken.Replace("\"", ""));
        }

    }
    public async Task<TResponse> Get(string url)
    {
        try
        {
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var jsonResult = JsonConvert.DeserializeObject<TResponse>(result)!;
                return jsonResult;
            }
            else
            {
                await HandleResponse(response);
                return _result!;
            }
        }
        catch (Exception ex)
        {
            _result.Message = ex.Message;

            HandleException(ex);
            return _result!;
        }
    }

    public async Task<TResponse> Post<T>(string url, T data, bool isForm = false, string redirectUrl = null, bool isToast = false)
    {
        try
        {
            HttpResponseMessage result;
            if (isForm)
            {
                var formContent = ConvertToFormData(data);
                result = await _httpClient.PostAsync(url, formContent);
            }
            else
            {
                result = await _httpClient.PostAsJsonAsync(url, data);
            }

            var res = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TResponse>(res);
            if (result.IsSuccessStatusCode)
            {
                if (isToast)
                    _toastService.ShowSuccess(response!.Message);

                if (!string.IsNullOrWhiteSpace(redirectUrl))
                    _navigationManager.NavigateTo(redirectUrl);
            }
            else
            {
                await HandleResponse(result);

            }
            return response!;
        }
        catch (Exception ex)
        {
            _result.Message = ex.Message;
            return _result!;
        }
    }

    public async Task<TResponse> Put<T>(string url, T data, bool isForm = false, string redirectUrl = null, bool isToast = false)
    {
        HttpResponseMessage result;
        if (isForm)
        {
            var formContent = ConvertToFormData(data);
            result = await _httpClient.PutAsync(url, formContent);
        }
        else
        {
            result = await _httpClient.PutAsJsonAsync(url, data);
        }

        try
        {
            var res = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TResponse>(res);

            if (result.IsSuccessStatusCode)
            {
                if (isToast)
                    _toastService.ShowSuccess(response!.Message);

                if (!string.IsNullOrWhiteSpace(redirectUrl))
                    _navigationManager.NavigateTo(redirectUrl);
            }
            else
            {
                await HandleResponse(result);

            }
            return response!;
        }
        catch (Exception ex)
        {
            _result.Message = ex.Message;

            return _result;
        }
    }

    public async Task<TResponse> Delete(string url, string redirectUrl = null, bool isToast = false)
    {
        var result = await _httpClient.DeleteAsync(url);

        try
        {
            var res = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TResponse>(res);

            if (result.IsSuccessStatusCode)
            {
                if (isToast)
                    _toastService.ShowSuccess(response!.Message);

                if (!string.IsNullOrWhiteSpace(redirectUrl))
                    _navigationManager.NavigateTo(redirectUrl);
            }
            else
            {
                await HandleResponse(result);

            }
            return response!;
        }
        catch (Exception ex)
        {
            _result.Message = ex.Message;

            return _result;
        }
    }

    public async Task<TResponse> Post(string url, object data, bool isForm = false, string redirectUrl = null, bool isToast = false)
    {
        try
        {
            HttpResponseMessage result;
            if (isForm)
            {
                var formContent = ConvertToFormData(data);
                result = await _httpClient.PostAsync(url, formContent);
            }
            else
            {
                result = await _httpClient.PostAsJsonAsync(url, data);
            }
            var res = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TResponse>(res);
            if (result.IsSuccessStatusCode)
            {
                if (isToast)
                    _toastService.ShowSuccess(response!.Message);

                if (!string.IsNullOrWhiteSpace(redirectUrl))
                    _navigationManager.NavigateTo(redirectUrl);
            }
            else
            {
                await HandleResponse(result);

            }
            return response!;
        }
        catch (Exception ex)
        {
            _result.Message = ex.Message;

            return _result!;
        }
    }

    public async Task<TResponse> Put(string url, string redirectUrl = null, bool isToast = false)
    {
        HttpResponseMessage result;
        result = await _httpClient.PutAsJsonAsync(url, new Object());

        try
        {
            var res = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TResponse>(res);

            if (result.IsSuccessStatusCode)
            {
                if (isToast)
                    _toastService.ShowSuccess(response!.Message);

                if (!string.IsNullOrWhiteSpace(redirectUrl))
                    _navigationManager.NavigateTo(redirectUrl);
            }
            else
            {
                await HandleResponse(result);

            }
            return response!;
        }
        catch (Exception ex)
        {
            _result.Message = ex.Message;

            return _result;
        }
    }

    private MultipartFormDataContent ConvertToFormData<Tdata>(Tdata data)
    {
        var formContent = new MultipartFormDataContent();
        var properties = typeof(Tdata).GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(data);
            if (value != null)
            {
                if (value is byte[] fileBytes) // Example of handling byte[] for file upload
                {
                    formContent.Add(new ByteArrayContent(fileBytes), property.Name, "filename.ext");
                }
                else
                {
                    formContent.Add(new StringContent(value.ToString()), property.Name);
                }
            }
        }
        return formContent;
    }

    private async Task HandleResponse(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    _navigationManager.NavigateTo("/login");
                    break;
                case HttpStatusCode.NotFound:
                    _toastService.ShowError("Resource not found");
                    break;
                default:
                    _toastService.ShowError($"Error: {response.StatusCode}");
                    break;
            }
        }
    }

    private void HandleException(Exception ex)
    {
        _toastService.ShowError($"An error occurred: {ex.Message}");
    }
}