using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Vendista.Interfaces;
using Vendista.Models;

namespace Vendista.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private ICommandService _commadService;

        public CommandController(ICommandService commadService)
        {
            _commadService = commadService;
        }

        [HttpGet("{id}")]
        public async Task<CommandType> GetCommandTypes(int id)
        {
            var result  = await _commadService.GetCommandTypes();
            var res = result.Items.Where(x => x.Id == id).First();
            return res;
        }
    }
}
