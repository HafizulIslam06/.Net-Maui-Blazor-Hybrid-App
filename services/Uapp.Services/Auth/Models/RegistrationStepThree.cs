using System.ComponentModel.DataAnnotations;
using Uapp.Shared.States;

namespace Uapp.Services.Auth.Models
{
    public class RegistrationStepThree: IBaseState
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
        public string InvitationCode { get; set; } = string.Empty;
    }
}
