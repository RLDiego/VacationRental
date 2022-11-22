using Aiia.Contracts;
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
        
        public IActionResult OnGet(string authorizationId)
        {
            _memoryCache.Remove(Constants.Transaction);
            _memoryCache.CreateEntry(Constants.Transaction);
            _memoryCache.Set(Constants.Transaction, authorizationId, TimeSpan.FromMinutes(180));
            return Redirect("/paymentinfo");
        }
    }
}