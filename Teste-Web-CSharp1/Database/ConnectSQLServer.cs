using System.Data.SqlClient;

namespace Teste_Web_CSharp1.Database
{
    public class ConnectSQLServer
    {
        public SqlConnection GetConnection()
        {
            string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;";

            return new SqlConnection(connection);
        }
    }
}
