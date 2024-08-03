using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uapp.Shared.Core
{
    public static class TokenHelper
    {
        public static bool IsExpired(string token)
        {
            if (token == null || ("").Equals(token))
            {
                return true;
            }
            var stringtoken = token.Replace("\"", "");
            var tokenHandler = new JwtSecurityTokenHandler();
            var decodedtoken = tokenHandler.ReadJwtToken(stringtoken);

            if (decodedtoken.ValidTo < DateTime.UtcNow)
            {
                return true;
            }
            return false;
        }
    }
}
