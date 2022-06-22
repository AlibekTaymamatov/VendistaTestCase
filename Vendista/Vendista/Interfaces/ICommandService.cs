using System.Threading.Tasks;
using Vendista.DTO.Responce;

namespace Vendista.Interfaces
{
    public interface ICommandService
    {
        public Task<CommandTypesDto> GetCommandTypes();
    }
}
