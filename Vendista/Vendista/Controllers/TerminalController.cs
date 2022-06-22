using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Vendista.DTO.Request;
using Vendista.DTO.Responce;
using Vendista.Interfaces;
using Vendista.Models;

namespace Vendista.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerminalController : ControllerBase
    {
        private ITerminalService _terminalService;

        public TerminalController(ITerminalService terminalService)
        {
            _terminalService = terminalService;
        }

        [HttpPost("{id}")]
        public async Task<TerminalCommand> SendCommand([FromBody] SentCommandRequestDto sentCommand, int id)
        {
            TerminalCommandDto result = null;
            try
            {
                 result = await _terminalService.SendCommandTerminal(id, sentCommand);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            return result.Item;
        }

        [HttpGet("{id}")]
        public async Task<TerminalsCommandsDto> GetSentCommand(int id)
        {
            TerminalsCommandsDto result = null;
            try
            {
                result = await _terminalService.GetCommandTerminal(id);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            return result;
        }
    }
}
