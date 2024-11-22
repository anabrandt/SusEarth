namespace SusEarth.Models
{
    public class Address
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
