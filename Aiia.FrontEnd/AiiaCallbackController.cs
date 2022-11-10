using Microsoft.AspNetCore.Mvc;

namespace Aiia.FrontEnd
{
    [Route("api/[controller]")]
    [ApiController]
    public class AiiaCallbackController : ControllerBase
    {
        public AiiaCallbackController()
        {
        }       

        [HttpGet("login")]
        public RedirectResult GetSignIn([FromQuery] string code)
        {
            return Redirect("/");
        }

        [HttpGet("payment")]
        public RedirectResult GetPayment([FromBody] string value)
        {
            return Redirect("/payment");
        }        
    }
}
