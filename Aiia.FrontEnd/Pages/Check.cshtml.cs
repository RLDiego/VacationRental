using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace Aiia.FrontEnd.Pages
{
    public class CheckModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public CheckModel(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        
        public IActionResult OnGet(string code)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(10));

            _memoryCache.Set("OAuthKey", code, cacheEntryOptions);
            return Redirect("/");
        }

        public IActionResult OnGet()
        {
            return  View
        }
    }
}
