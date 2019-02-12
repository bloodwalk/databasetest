using Microsoft.AspNetCore.Mvc;

namespace MyFirstASPNETCoreWebApp.Controllers
{
    [Route("about")]
    public class AboutController
    {
        [Route("")]
        public string Phone()
        {
            return "555+555+555";
        }
        [Route("address")]
        public string Address()
        {
            return "USA";
        }
    }
}
