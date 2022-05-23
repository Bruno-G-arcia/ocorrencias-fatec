using MySqlConnector;

namespace OcorrenciasWeb.Repositories
{
  public class DBContext
  {
    
    private string strConn = "server=localhost;uid=onurb;" +
    "pwd=SQL123@;database=OCORRENCIAS";

    protected MySqlConnection conn;

    public DBContext()
    {
      conn = new MySqlConnection(strConn);
      conn.Open();
    }
    public void Dispose()
    {
      conn.Close();
    }
   
    
  }
}