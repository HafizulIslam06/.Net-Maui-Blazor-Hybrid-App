using Uapp.Shared.Core.Services;

namespace Uapp.Shared.Responses
{
    public class AuthResponse : IUserManagerResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public List<int> Permissions { get; set; }
        public List<MenuItemViewModel> MenuItems { get; set; }
        public DateTime ExpireDate { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
