using System.Data.SqlClient;

namespace Server_Teste_Web_CSharp.Database
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
