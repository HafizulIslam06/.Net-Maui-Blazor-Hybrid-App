using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uapp.Services.Auth.Models
{
    public class RegistrationModel
    {
        public long PreferredCountry { get; set; }
        public long NameTittleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string InvitationCode { get; set; }
    }
}
