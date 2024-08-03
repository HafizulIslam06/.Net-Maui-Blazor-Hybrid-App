using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uapp.Shared.Responses
{
    public class LoginResponse : ILoginResponse
    {
        public string DisplayName { get; set; }
        public string DisplayEmail { get; set; }
        public string DisplayUserType { get; set; }
        public string DisplayImage { get; set; }
        public long UserTypeId { get; set; }
        public long ReferenceId { get; set; }
        public string RoleName { get; set; }
        public string UserViewId { get; set; }
        public bool IsActive { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; } = true;
    }
}
