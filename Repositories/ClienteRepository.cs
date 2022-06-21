using OcorrenciasWeb.Models;
using MySqlConnector;
using System.Diagnostics;

namespace OcorrenciasWeb.Repositories
{
  public class ClienteRepository : DBContext, IClienteRepository
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

    public void CreateCompleto(Cliente cliente)
    { 
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = 
      @"INSERT INTO Pessoa (Nome, CPF, Telefone) 
      VALUES(@nome, @cpf, @telefone);
      SET @vIdPessoa = @@IDENTITY;
      INSERT INTO Usuario (Email, Senha, Tipo)
      VALUES (@email, @senha, @tipo);
      SET @vIdUsuario = @@IDENTITY;
      INSERT into Cliente (IdUsuario, IdPessoa )
      VALUES(@vIdUsuario, @vIdPessoa);
      ";

      cmd.Parameters.AddWithValue("@nome",      cliente.Nome);
      cmd.Parameters.AddWithValue("@cpf",       cliente.Cpf);
      cmd.Parameters.AddWithValue("@telefone",  cliente.Telefone);
      cmd.Parameters.AddWithValue("@email",     cliente.Email);
      cmd.Parameters.AddWithValue("@senha",     cliente.Senha);
      cmd.Parameters.AddWithValue("@tipo",      "Cliente");
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
        }
      }
      
      return cliente;
    }

    public Cliente ReadUsuario(int id)
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"SELECT * FROM vCliente
      WHERE IdUsuario = @id;";

      cmd.Parameters.AddWithValue("@id", id);
      Cliente cliente = new Cliente();

      using (MySqlDataReader reader = cmd.ExecuteReader())
      {
        while (reader.Read())
        {
          cliente.IdCliente = (int)reader["IdCliente"];
          cliente.IdUsuario = (int)reader["IdUsuario"];
          cliente.IdPessoa  = (int)reader["IdPessoa"];
          cliente.Cpf       = (string)reader["CPF"];
          cliente.Telefone  = (string)reader["Telefone"];
          cliente.Nome      = (string)reader["Nome"];
          cliente.Email     = (string)reader["Email"];
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
      Email               = @email,
      WHERE IdCliente = @id;";

      cmd.Parameters.AddWithValue("@email",    cliente.Email);
      cmd.Parameters.AddWithValue("@id",    id);

      cmd.ExecuteNonQuery();

    }

    public void UpdateClientePessoa(int id, Cliente cliente)
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText =
      @"UPDATE vCliente
      SET
      Nome = @nome,
      CPF  = @cpf,
      Telefone = @telefone
      WHERE IdCliente = @id;";

      cmd.Parameters.AddWithValue("@nome",      cliente.Nome);
      cmd.Parameters.AddWithValue("@cpf",       cliente.Cpf);
      cmd.Parameters.AddWithValue("@telefone",  cliente.Telefone);

      cmd.Parameters.AddWithValue("@id", id);

      cmd.ExecuteNonQuery();

    }

  }
}