
using System.Configuration;

namespace apr.Repository
{
    public class ConnectionDB
    {
        public static string getConnectionStrings()
        {
            return ConfigurationManager.ConnectionStrings["cndbpedidos"].ToString();
        }
    }
}
