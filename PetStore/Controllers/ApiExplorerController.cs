using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace PetStore.Controllers
{
    [Route("api-explorer")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ApiExplorerController : Controller
    {
        private readonly IApiDescriptionGroupCollectionProvider _apiExplorer;

        public ApiExplorerController(IApiDescriptionGroupCollectionProvider apiExplorer)
        {
            _apiExplorer = apiExplorer;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_apiExplorer);
        }
    }
}