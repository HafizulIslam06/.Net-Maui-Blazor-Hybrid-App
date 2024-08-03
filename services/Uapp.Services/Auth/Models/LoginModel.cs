using System.ComponentModel.DataAnnotations;

namespace Uapp.Services.Auth.Models;

public class LoginModel
{
    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
    public string? IpAddress { get; set; }
    public string? GeoLocationInfo { get; set; }
}
