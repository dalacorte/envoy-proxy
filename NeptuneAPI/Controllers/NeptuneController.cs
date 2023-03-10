using Microsoft.AspNetCore.Mvc;

namespace NeptuneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeptuneController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            using (var client = new HttpClient())
            {
                var builder = new UriBuilder("https://api.le-systeme-solaire.net/rest.php/bodies/neptune");

                var httpRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(builder.ToString())
                };

                var response = await client.SendAsync(httpRequest);

                return Ok(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
