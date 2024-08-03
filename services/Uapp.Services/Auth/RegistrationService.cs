using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Uapp.Services.Auth.Models;
using Uapp.Shared.Constants;
using Uapp.Shared.Core.Services;
using Uapp.Shared.Core.Services.auth;
using Uapp.Shared.Http;
using Uapp.Shared.Responses;

namespace Uapp.Services.Auth
{
    public class RegistrationService : IRegistrationService
    {
        private IHttpService _httpClientService;
        private readonly RegistrationStepOne stepOne;
        private readonly RegistrationStepTwo stepTwo;
        private readonly RegistrationStepThree stepThree;

        public RegistrationService(IHttpService httpClientService, RegistrationStepOne stepOne, RegistrationStepTwo stepTwo, RegistrationStepThree stepThree)
        {
            _httpClientService = httpClientService;
            this.stepOne = stepOne;
            this.stepTwo = stepTwo;
            this.stepThree = stepThree;
        }


        public async Task<OldResponse<bool>> SubmitForm()
        {
            var model = new RegistrationModel()
            {
                Email = stepTwo.Email,
                FirstName = stepTwo.FirstName,
                InvitationCode = stepThree.InvitationCode,
                LastName = stepTwo.LastName,
                NameTittleId = stepTwo.Title,
                Password = stepThree.Password,
                PreferredCountry = stepOne.PreferedCountry,
            };
            return await _httpClientService.Request<OldResponse<bool>, RegistrationModel>().Post($"{ApiConstants.ApiRoot}{ApiConstants.SignUp}", model);
        }
    }

}
