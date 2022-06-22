using System;
using System.ComponentModel.DataAnnotations;

namespace Vendista.Models
{
    public class TerminalCommand
    {
        public int Terminal_id { get; set; }

        public int Command_id { get; set; }

        public int Parameter1 { get; set; }

        public int Parameter2 { get; set; }

        public int Parameter3 { get; set; }

        public string State_name { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Time_created { get; set; }
    }
}
