using Microsoft.Extensions.Configuration;

namespace SusEarth.API.Data
{
    public class OracleConnection
    {
        private readonly IConfiguration _configuration;

        public OracleConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("OracleDbConnection");
        }
    }
}
