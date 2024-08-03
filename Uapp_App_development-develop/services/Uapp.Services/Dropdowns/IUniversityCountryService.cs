using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uapp.Services.Auth.Models;
using Uapp.Shared.Constants;
using Uapp.Shared.Core.Services;
using Uapp.Shared.Http;
using Uapp.Shared.Models;
using Uapp.Shared.Models.Common;
using Uapp.Shared.Responses;

namespace Uapp.Services.Dropdowns
{
    public interface IUniversityCountryService : IBaseService
    {
        Task<dynamic> GetSelects();
    }
    public class UniversityCountryService : IUniversityCountryService
    {
        private readonly NavigationManager _navigationManager;
        private readonly IHttpService httpService;

        public UniversityCountryService(NavigationManager navigationManager, IHttpService httpService)
        {
            _navigationManager = navigationManager;
            this.httpService = httpService;
        }
        public async Task<dynamic> GetSelects()
        {
            var response = await httpService.Request<OldResponse<List<EntitySelect>>>().Get($"{ApiConstants.ApiRoot}{ApiConstants.UniversityCountryDD}");

            return response?.Result;
        }
    }
}
