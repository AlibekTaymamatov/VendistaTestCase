using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Vendista.DTO.Responce;
using Vendista.Interfaces;

namespace Vendista.Service
{
    public class CommandService: TokenService, ICommandService
    {
        public async Task<CommandTypesDto> GetCommandTypes()
        {
            var token = await GetToken();
            CommandTypesDto result = new CommandTypesDto();
            HttpResponseMessage res = await httpClient.GetAsync($"commands/types?token={token}");
            if (res.IsSuccessStatusCode)
            {
                var response = res.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<CommandTypesDto>(response);
            }
            return result;
        }
    }
}