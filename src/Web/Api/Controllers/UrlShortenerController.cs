using System.Threading.Tasks;
using Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.Api.DTO;
using System.Text.RegularExpressions;

namespace Web.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UrlShortenerController: Controller
    {
        private readonly IUrlShortener _service;

        public UrlShortenerController(IUrlShortener service) => _service = service;

        [HttpPost]
        public async Task<ActionResult> Shorten ([FromBody] UrlRequest urlRequest) {
            var shortenedUrl = await _service.Shorten(urlRequest.url);

            var urlResponse = new UrlResponse {
                ShortenedUrl = shortenedUrl,
                OriginalUrl = urlRequest.url
            };

            var jsonResponse = JsonConvert.SerializeObject(urlResponse);
            
            return Ok(jsonResponse);
        }

        [HttpPost]
        public async Task<ActionResult> RedirectToOriginalUrl([FromBody] string url) {
            var myRegex = new Regex(@"(http||https)\:\/{2}ru\.y\/");
            url = myRegex.Replace(url, string.Empty);

            var originalUrl = await _service.GetOriginalUrl(url);

            return Redirect(originalUrl);
        }
    }
}