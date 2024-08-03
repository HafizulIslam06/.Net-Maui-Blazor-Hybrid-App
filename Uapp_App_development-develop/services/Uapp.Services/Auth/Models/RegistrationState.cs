using System.ComponentModel.DataAnnotations;
using Uapp.Services.Auth.Models;
using Uapp.Shared.States;

namespace Uapp.Services.Auth
{
    public class RegistrationState : IBaseState
    {
        public RegistrationStepOne Step1 { get; set; } = new RegistrationStepOne();
        public RegistrationStepTwo Step2 { get; set; } = new RegistrationStepTwo();
        public RegistrationStepThree Step3 { get; set; } = new RegistrationStepThree();
    }
}
