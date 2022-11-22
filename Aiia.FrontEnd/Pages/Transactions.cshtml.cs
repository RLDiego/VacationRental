using Aiia.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace Aiia.FrontEnd.Pages
{
    public class TransactionsModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public TransactionsModel(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        
        public IActionResult OnGet(string account, string destination)
        {
            _memoryCache.Remove(Constants.Account);
            _memoryCache.CreateEntry(Constants.Account);
            _memoryCache.Set(Constants.Account, account, TimeSpan.FromMinutes(180));
            return Redirect($"/{destination}");
        }
    }
}