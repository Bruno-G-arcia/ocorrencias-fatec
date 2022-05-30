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
      cmd.CommandText = @"INSERT INTO Funcionario (Cargo) 
      VALUES(@Cargo);";

      cmd.Parameters.AddWithValue("@cargo", funcionario.Cargo);

      cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"DELETE FROM Funcionario 
      WHERE IdFuncionario = @id;";

      cmd.Parameters.AddWithValue("@id", id);

      cmd.ExecuteNonQuery();
    }

    public List<Funcionario> Read()
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"SELECT * FROM vFuncionarioPessoa;";
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
            Email           = (string)reader["Email"],
            Tipo            = (string)reader["Tipo"],
            Nome            = (string)reader["Nome"]
          });
        }

      }
      return usuarios;
    }

    public Usuario Auth(string email, string senha)
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"SELECT * 
      FROM Usuario
      LEFT JOIN Funcionario
      ON Usuario.IdUsuario = Funcionario.IdUsuario
      LEFT JOIN Cliente
      ON Usuario.IdUsuario = Cliente.IdUsuario
      LEFT JOIN Pessoa
      ON Pessoa.IdPessoa = Funcionario.IdPessoa
      OR
      Pessoa.IdPessoa = Cliente.IdPessoa
      WHERE Usuario.Email = @email 
      AND Usuario.Senha = @senha";

      cmd.Parameters.AddWithValue("@email", email);
      cmd.Parameters.AddWithValue("@senha", senha);
      Usuario usuario = new Usuario();

      using (MySqlDataReader reader = cmd.ExecuteReader())
      {
        while (reader.Read())
        {
          usuario.IdUsuario = (int)reader["IdUsuario"];
          usuario.Email     = (string)reader["Email"];
          usuario.Senha     = (string)reader["Senha"];
          usuario.Tipo      = (string)reader["Tipo"];
        }
      }
      return usuario;
    }

    public Usuario Read(int id)
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"SELECT * FROM Usuario
      WHERE IdUsuario = @id;";

      cmd.Parameters.AddWithValue("@id", id);
      Usuario usuario = new Usuario();

      using (MySqlDataReader reader = cmd.ExecuteReader())
      {
        while (reader.Read())
        {
          usuario.IdUsuario = (int)reader["IdUsuario"];
          usuario.Email = (string)reader["Email"];
          usuario.Senha = (string)reader["Senha"];
          usuario.Tipo = (string)reader["Tipo"];
        }
      }
      return usuario;
    }

    public void Update(int id, Usuario usuario)
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"UPDATE Usuario 
      SET Email   = @email,
      Senha       = @senha,
      Tipo        = @tipo,
      WHERE IdUsuario = @id;";

      cmd.Parameters.AddWithValue("@email", usuario.Email);
      cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
      cmd.Parameters.AddWithValue("@tipo", usuario.Tipo);
      cmd.Parameters.AddWithValue("@id", id);


      cmd.ExecuteNonQuery();

    }




  }
}