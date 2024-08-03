using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uapp.Shared.Responses;

namespace Uapp.Shared.Core.Services.auth
{
    public interface IUserStorageService
    {
        Task<bool> SetUserAsync(LoginResponse model);
        void RemoveUser();
        Task<LoginResponse> GetUserAsync();

    }
}
