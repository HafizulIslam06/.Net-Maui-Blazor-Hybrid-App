using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uapp.Services.Auth.Models
{
    public class PasswordRecoveryModel
    {
        [Required]
        public string Email { get; set; }
    }
}
