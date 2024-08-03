using System.ComponentModel.DataAnnotations;
using Uapp.Shared.States;

namespace Uapp.Services.Auth.Models
{
    public class RegistrationStepOne:IBaseState
    {
        [Required]
        public long PreferedCountry { get; set; } 
    }
}
