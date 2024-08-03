using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uapp.Shared.Extensions;
using Uapp.Shared.Responses;

namespace Uapp.Shared.Core.Services.auth
{
    public class UserStorageService : IUserStorageService
    {
        private readonly string _useraccesskey;

        public UserStorageService()
        {
            _useraccesskey = "GetCurrentUser";
        }
        public async Task<LoginResponse> GetUserAsync()
        {
            return await SecureStorageHelper.GetObjectAsync<LoginResponse>(_useraccesskey);
        }

        public void RemoveUser()
        {
            SecureStorageHelper.RemoveObjectAsync(_useraccesskey);
        }

        public async Task<bool> SetUserAsync(LoginResponse model)
        {
            return await SecureStorageHelper.SetObjectAsync(_useraccesskey, model);
        }
    }
}
