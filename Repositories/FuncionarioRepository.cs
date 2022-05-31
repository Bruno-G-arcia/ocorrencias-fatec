using OcorrenciasWeb.Models;
using MySqlConnector;

namespace OcorrenciasWeb.Repositories
{
  public class FuncionarioRepository : DBContext
  {

    public void Create(Funcionario funcionario)
    { 
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = 
      @"INSERT INTO Funcionario (IdPessoa, IdUsuario, Cargo) 
      VALUES(@idPesoa, @idUsuario, @cargo);";

      cmd.Parameters.AddWithValue("@idPessoa",   funcionario.IdPessoa);
      cmd.Parameters.AddWithValue("@idUsuario",  funcionario.IdUsuario);
      cmd.Parameters.AddWithValue("@cargo",      funcionario.Cargo);

      cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"DELETE FROM vFuncionario 
      WHERE IdFuncionario = @id;";

      cmd.Parameters.AddWithValue("@id", id);

      cmd.ExecuteNonQuery();
    }

    public List<Funcionario> Read()
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"SELECT * FROM vFuncionario;";
      List<Funcionario> funcionarios = new List<Funcionario>();

      using (MySqlDataReader reader = cmd.ExecuteReader())
      {
        while (reader.Read())
        {
          funcionarios.Add(
          new Funcionario
          {
            IdFuncionario   = (int)reader["IdFuncionario"],
            Cargo           = (string)reader["Cargo"],
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
      return funcionarios;
    }
        
    public Funcionario Read(int id)
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"SELECT * FROM vFuncionario
      WHERE IdFuncionario = @id;";

      cmd.Parameters.AddWithValue("@id", id);
      Funcionario funcionario = new Funcionario();

      using (MySqlDataReader reader = cmd.ExecuteReader())
      {
        while (reader.Read())
        {
            funcionario.IdFuncionario = (int)reader["IdFuncionario"];
            funcionario.Cargo         = (string)reader["Cargo"];
            funcionario.IdUsuario     = (int)reader["IdUsuario"];
            funcionario.IdPessoa      = (int)reader["IdPessoa"];
            funcionario.Cpf           = (string)reader["Cpf"];
            funcionario.Telefone      = (string)reader["Telefone"];
            funcionario.Nome          = (string)reader["Nome"];
            funcionario.Email         = (string)reader["CPF"];
            funcionario.Senha         = (string)reader["Senha"];
        }
      }
      return funcionario;
    }

    public void Update(int id, Funcionario funcionario)
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = 
      @"UPDATE vFuncionario 
      SET 
      Cargo         = @cargo,
      WHERE IdFuncionario = @id;";

      cmd.Parameters.AddWithValue("@cargo",    funcionario.Cargo);
      cmd.Parameters.AddWithValue("@id",    id);

      cmd.ExecuteNonQuery();

    }
  }
}