using Uapp.Services.Auth.Models;
using Uapp.Shared.Responses;

namespace Uapp.Services.Auth;

public interface IRegistrationService : IBaseService
{
    Task<OldResponse<bool>> SubmitForm();
}
