using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uapp.Services.Auth.Models;
using Uapp.Shared.Constants;
using Uapp.Shared.Http;
using Uapp.Shared.Responses;

namespace Uapp.Services.Auth
{
    public class PasswordRecoveryService : IPasswordRecoveryService
    {
        private readonly IHttpService _httpClientService;

        public PasswordRecoveryService(IHttpService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<OldResponse<bool>> SendPasswordRecoveryEmailAsync(string email)
        {

            return await _httpClientService.Request<OldResponse<bool>>().Put($"{ApiConstants.ApiRoot}{ApiConstants.PasswordRecovery}?email={email}");

        }
    }
}
