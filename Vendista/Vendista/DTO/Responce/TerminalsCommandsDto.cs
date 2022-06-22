using System.Collections.Generic;
using Vendista.Models;

namespace Vendista.DTO.Responce
{
    public class TerminalsCommandsDto
    {
        public TerminalsCommandsDto()
        {
            this.Items = new List<TerminalCommand>();
        }

        public List<TerminalCommand> Items { get; set; }
    }
}
