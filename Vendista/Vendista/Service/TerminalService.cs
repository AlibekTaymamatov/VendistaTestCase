using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Vendista.DTO.Request;
using Vendista.DTO.Responce;
using Vendista.Interfaces;
using Vendista.Models;

namespace Vendista.Service
{
    public class TerminalService: TokenService, ITerminalService
    {
        public async Task<TerminalCommandDto> SendCommandTerminal(int terminal_id, SentCommandRequestDto sentCommand)
        {
            var token = await GetToken();
            SentCommand model = sentCommand.ToModel();
            TerminalCommandDto result = new TerminalCommandDto();
            HttpResponseMessage res = await httpClient.PostAsJsonAsync($"terminals/{terminal_id}/commands?token={token}", model);
            try {
                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<TerminalCommandDto>(response);
                }
                else
                {
                    throw new Exception(res.StatusCode.ToString());
                }
            } catch (Exception err) {

                throw new Exception(err.Message);
            }

            return result;
        }

        public async Task<TerminalsCommandsDto> GetCommandTerminal(int terminal_id)
        {
            var token = await GetToken();
            TerminalsCommandsDto result = new TerminalsCommandsDto();
            HttpResponseMessage res = await httpClient.GetAsync($"terminals/{terminal_id}/commands?token={token}");
            if (res.IsSuccessStatusCode)
            {
                var response = res.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<TerminalsCommandsDto>(response);
            }
            else
            {
                throw new Exception(res.StatusCode.ToString());
            }
            return result;
        }
    }
}