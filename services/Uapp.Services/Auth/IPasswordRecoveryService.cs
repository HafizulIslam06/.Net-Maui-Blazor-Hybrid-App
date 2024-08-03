using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uapp.Shared.Responses;

namespace Uapp.Services.Auth
{
    public interface IPasswordRecoveryService : IBaseService
    {
        Task<OldResponse<bool>> SendPasswordRecoveryEmailAsync(string email);
    }
}
