using OcorrenciasWeb.Models;
using MySqlConnector;

namespace OcorrenciasWeb.Repositories
{
  public class ClienteRepository : DBContext
  {

    public void Create(Cliente cliente)
    { 
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = 
      @"INSERT INTO Cliente (IdPessoa, IdUsuario) 
      VALUES(@idPessoa, @idUsuario);";

      cmd.Parameters.AddWithValue("@idPessoa",  cliente.IdPessoa);
      cmd.Parameters.AddWithValue("@idUsuario", cliente.IdUsuario);

      cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"DELETE FROM Cliente 
      WHERE IdCliente = @id;";

      cmd.Parameters.AddWithValue("@id", id);

      cmd.ExecuteNonQuery();
    }

    public List<Cliente> Read()
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"SELECT * FROM vCliente;";
      List<Cliente> clientes = new List<Cliente>();

      using (MySqlDataReader reader = cmd.ExecuteReader())
      {
        while (reader.Read())
        {
          clientes.Add(
          new Cliente
          {
            IdCliente       = (int)reader["IdCliente"],
            IdUsuario       = (int)reader["IdUsuario"],
            IdPessoa        = (int)reader["IdPessoa"],
            Email           = (string)reader["Email"],
            Tipo            = (string)reader["Tipo"],
            Nome            = (string)reader["Nome"],
            Cpf             = (string)reader["CPF"],
            Telefone        = (string)reader["Telefone"]
            
          });
        }

      }
      return clientes;
    }
        
    public Cliente Read(int id)
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"SELECT * FROM vCliente
      WHERE IdCliente = @id;";

      cmd.Parameters.AddWithValue("@id", id);
      Cliente cliente = new Cliente();

      using (MySqlDataReader reader = cmd.ExecuteReader())
      {
        while (reader.Read())
        {
            cliente.IdCliente     = (int)reader["IdCliente"];
            cliente.IdUsuario     = (int)reader["IdUsuario"];
            cliente.IdPessoa      = (int)reader["IdPessoa"];
            cliente.Cpf           = (string)reader["Cpf"];
            cliente.Telefone      = (string)reader["Telefone"];
            cliente.Nome          = (string)reader["Nome"];
            cliente.Email         = (string)reader["CPF"];
            cliente.Senha         = (string)reader["Senha"];
        }
      }
      return cliente;
    }

    public void Update(int id, Cliente cliente)
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = 
      @"UPDATE Cliente 
      SET 
      Cargo         = @email,
      WHERE IdFuncionario = @id;";

      cmd.Parameters.AddWithValue("@email",    cliente.Email);
      cmd.Parameters.AddWithValue("@id",    id);

      cmd.ExecuteNonQuery();

    }
  }
}