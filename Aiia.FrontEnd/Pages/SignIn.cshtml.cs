using System.Text;
using System.Web;
using Aiia.Contracts;
using Aiia.Contracts.Entities;
using Aiia.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Aiia.FrontEnd.Pages
{
    public class SignInModel : PageModel
    {
        private readonly ITokenRepository _tokenRepository;

        public SignInModel(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }
        
        public  async Task<IActionResult> OnGet([FromQuery]string code)
        {
            if (!string.IsNullOrEmpty(code) && !(await _tokenRepository.Exists()))
            {
                await _tokenRepository.SaveToken(code);
            }

            return Redirect("/");
        }
    }
}
