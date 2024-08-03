using Microsoft.Maui.Storage;

namespace Uapp.Shared.Core.Services.auth
{
    public class TokenStorageService : ITokenStorageService
    {
        private readonly string _accessTokenKey;
        private readonly string _refreshTokenKey;

        public TokenStorageService()
        {
            _accessTokenKey = "AccessToken";
            _refreshTokenKey = "RefreshToken";
        }

        public async Task<string> GetAccessToken()
        {
            return await SecureStorage.GetAsync(_accessTokenKey);
        }

        public async Task SaveAccessToken(string token)
        {
            await SecureStorage.SetAsync(_accessTokenKey, token);
        }

        public async Task<string> GetRefreshToken()
        {
            return await SecureStorage.GetAsync(_refreshTokenKey)!;
        }

        //public async Task SaveRefreshToken(string token)
        //{
        //    await SecureStorage.SetAsync(_refreshTokenKey, token);
        //}

        public async Task SaveTokens(string accessToken)
        {
           await SaveAccessToken(accessToken);
           //await SaveRefreshToken(refreshToken);
        }

        public void RemoveTokens()
        {
            SecureStorage.Remove(_accessTokenKey);
            SecureStorage.Remove(_refreshTokenKey);
        }
    }
}
