using Aiia.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace Aiia.FrontEnd.Pages
{
    public class AcceptPaymentModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public AcceptPaymentModel(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        
        public IActionResult OnGet(string paymentId)
        {
            _memoryCache.Remove(Constants.AcceptPayment);
            _memoryCache.CreateEntry(Constants.AcceptPayment);
            _memoryCache.Set(Constants.AcceptPayment, paymentId, TimeSpan.FromMinutes(180));
            return Redirect("/apaymentinfo");
        }
    }
}