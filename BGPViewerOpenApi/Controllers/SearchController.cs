using System.Threading.Tasks;
using BGPViewerOpenApi.Service;
using BGPViewerOpenApi.Validators;
using Microsoft.AspNetCore.Mvc;

namespace BGPViewerOpenApi.Controllers
{
    [Route("api/search")]
    [ApiController]
    [ValidateSelectedApiExistence]
    public class SearchByController : Controller
    {
        private readonly SearchProvider provider;

        public SearchByController(SearchProvider provider)
        {
            this.provider = provider;
        }

        [HttpGet("{queryTerm}/{apiId}")]
        public async Task<IActionResult> Search(string queryTerm, int apiId)
            => Ok(await provider.Search(queryTerm, apiId));
    }
}