using OcorrenciasWeb.Models;
using MySqlConnector;


namespace OcorrenciasWeb.Repositories
{
  public class FuncionarioRepository : DBContext, IFuncionarioRepository
  {

    public void Create(Funcionario funcionario)
    { 
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = 
      @"INSERT INTO Pessoa (Nome, CPF, Telefone) 
      VALUES(@nome, @cpf, @telefone);
      SET @vIdPessoa = LAST_INSERT_ID();
      INSERT INTO Usuario (Email, Senha, Tipo)
      VALUES (@email, @senha, @tipo);
      SET @vIdUsuario = LAST_INSERT_ID();
      INSERT into Funcionario (IdUsuario, IdPessoa, Cargo )
      VALUES(@vIdUsuario, @vIdPessoa, @Cargo);
      ";

      cmd.Parameters.AddWithValue("@nome",      funcionario.Nome);
      cmd.Parameters.AddWithValue("@cpf",       funcionario.Cpf);
      cmd.Parameters.AddWithValue("@telefone",  funcionario.Telefone);
      cmd.Parameters.AddWithValue("@email",     funcionario.Email);
      cmd.Parameters.AddWithValue("@senha",     funcionario.Senha);
      cmd.Parameters.AddWithValue("@cargo",     funcionario.Cargo);
      cmd.Parameters.AddWithValue("@tipo",      "Funcionario");
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

    public Funcionario ReadUsuario(int id)
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"SELECT * FROM vFuncionario
      WHERE IdUsuario = @id;";

      cmd.Parameters.AddWithValue("@id", id);
      Funcionario funcionario = new Funcionario();

      using (MySqlDataReader reader = cmd.ExecuteReader())
      {
        while (reader.Read())
        {
          funcionario.IdFuncionario= (int)reader["IdFuncionario"];
          funcionario.IdUsuario = (int)reader["IdUsuario"];
          funcionario.IdPessoa  = (int)reader["IdPessoa"];
          funcionario.Cargo     = (string)reader["Cargo"];
          funcionario.Cpf       = (string)reader["CPF"];
          funcionario.Telefone  = (string)reader["Telefone"];
          funcionario.Nome      = (string)reader["Nome"];
          funcionario.Email     = (string)reader["Email"];
        }
      }
      return funcionario;
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

    public void UpdateFuncionarioPessoa(int id, Funcionario funcionario)
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText =
      @"UPDATE vFuncionario
      SET
      Nome = @nome,
      CPF  = @cpf,
      Telefone = @telefone
      WHERE IdFuncionario = @id;";

      cmd.Parameters.AddWithValue("@nome",      funcionario.Nome);
      cmd.Parameters.AddWithValue("@cpf",       funcionario.Cpf);
      cmd.Parameters.AddWithValue("@telefone",  funcionario.Telefone);

      cmd.Parameters.AddWithValue("@id", id);

      cmd.ExecuteNonQuery();

    }
  }
}