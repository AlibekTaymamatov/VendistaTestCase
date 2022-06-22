using System.Threading.Tasks;
using Vendista.DTO.Request;
using Vendista.DTO.Responce;

namespace Vendista.Interfaces
{
    public interface ITerminalService
    {
        public Task<TerminalCommandDto> SendCommandTerminal(int terminal_id, SentCommandRequestDto sentCommand);

        public Task<TerminalsCommandsDto> GetCommandTerminal(int terminal_id);
    }
}
