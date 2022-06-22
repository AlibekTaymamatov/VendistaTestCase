using System.Collections.Generic;
using Vendista.Models;

namespace Vendista.DTO.Responce
{
    public class CommandTypesDto
    {
        public CommandTypesDto()
        {
            this.Items = new List<CommandType>();
        }

        public List<CommandType> Items { get; set; }
    }
}
