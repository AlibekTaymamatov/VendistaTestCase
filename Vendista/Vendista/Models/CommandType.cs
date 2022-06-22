namespace Vendista.Models
{
    public class CommandType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Parameter_Name1 { get; set; }

        public string Parameter_Name2 { get; set; }

        public string Parameter_Name3 { get; set; }

        public string Parameter_Name4 { get; set; }

        public int? Parameter_Default_Value1 { get; set; }

        public int? Parameter_Default_Value2 { get; set; }

        public int? Parameter_Default_Value3 { get; set; }

        public int? Parameter_Default_Value4 { get; set; }
    }
}
