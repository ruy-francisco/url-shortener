using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UrlShortenerController: Controller
    {
        [HttpGet("{url}")]
        public string Shorten (string url) {
            return url;
        }
    }
}