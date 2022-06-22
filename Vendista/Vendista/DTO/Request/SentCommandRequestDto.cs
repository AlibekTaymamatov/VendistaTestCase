using Vendista.Models;

namespace Vendista.DTO.Request
{
    public class SentCommandRequestDto: IDtoMapper<SentCommand>
    {
        public int Command_id { get; set; }

        public int Parameter1 { get; set; }

        public int Parameter2 { get; set; }

        public int Parameter3 { get; set; }

        public SentCommand ToModel()
        {
            return new SentCommand()
            {
                Command_id = this.Command_id,
                Parameter1 = this.Parameter1,
                Parameter2 = this.Parameter2,
                Parameter3 = this.Parameter3,
            };
        }
    }
}
