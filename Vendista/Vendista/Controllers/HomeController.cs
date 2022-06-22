using Microsoft.AspNetCore.Mvc;
using Vendista.Interfaces;

namespace Vendista.Controllers
{
    public class HomeController : Controller
    {
        private ICommandService _commadService;

        public HomeController(ICommandService commadService)
        {
            _commadService = commadService;
        }

        public IActionResult Index()
        {
            var items = _commadService.GetCommandTypes();
            return View(items.Result.Items);
        }
    }
}