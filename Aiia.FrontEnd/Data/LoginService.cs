using Microsoft.Extensions.Caching.Memory;

namespace Aiia.FrontEnd.Data
{
    public class LoginService
    {

        private readonly IMemoryCache _memoryCache;
        public LoginService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task<bool> IsLoged()
        {
            return Task.FromResult(_memoryCache.TryGetValue("OAuthKey", out _));
        }

        public Task SignOut()
        {
            _memoryCache.Remove("OAuthKey");
            return Task.FromResult(true);
        }
    }
}
