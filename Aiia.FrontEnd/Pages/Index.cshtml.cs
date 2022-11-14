using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace Aiia.FrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public IndexModel(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        
        public ActionResult OnGet(string code)
        {
            
            return View("Index", _memoryCache.TryGetValue("OAuthKey", out _));
        }
    }
}