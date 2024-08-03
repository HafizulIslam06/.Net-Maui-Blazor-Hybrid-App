using System.ComponentModel.DataAnnotations;
using Uapp.Shared.States;

namespace Uapp.Services.Auth.Models
{
    public class RegistrationStepTwo : IBaseState
    {
        [Required]
        public long Title { get; set; }

        [Required(ErrorMessage = "Tittle & First Name is required.")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
