namespace SIPT.BL.DTO.DTO
{
    public class PtuModeloDTO
    {
        public string type { get; set; }
        public string value { get; set; }
        public string label { get; set; }
        public Opcion[] options { get; set; }
        public Reglas rules { get; set; }

        /*public int Id { get; set; }
        public string Title { get; set; }
        public string WarehouseName { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; set; } = new Dictionary<string, JToken>();
        */
    }

    public class PtuModelo2DTO
    {
        public string type { get; set; }
        public string value { get; set; }
        public string label { get; set; }
        public Opcion[] options { get; set; }
    }

    public class Opcion
    {
        public Opcion()
        {

        }
        public Opcion(string label, string value)
        {
            this.label = label;
            this.value = value;
        }
        public string label { get; set; }
        public string value { get; set; }
    }

    public class Reglas
    {
        public Reglas(bool requerido)
        {
            required = requerido;
        }
        public bool required { get; set; }
    }
}
