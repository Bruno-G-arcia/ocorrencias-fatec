using OcorrenciasWeb.Models;
using MySqlConnector;

namespace OcorrenciasWeb.Repositories
{
  public class UsuarioRepository : DBContext, IUsuarioRepository
  {

    public void Create(Usuario usuario)
    { 
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"INSERT INTO Usuario (Email, Senha, Tipo) 
      VALUES(@email, @senha, @tipo);";

      cmd.Parameters.AddWithValue("@email", usuario.Email);
      cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
      cmd.Parameters.AddWithValue("@tipo",  usuario.Tipo);

      cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"DELETE FROM Usuario WHERE 
      Usuario.IdUsuario = @id;";

      cmd.Parameters.AddWithValue("@id", id);

      cmd.ExecuteNonQuery();
    }

    public List<Usuario> Read()
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"SELECT * FROM Usuario;";
      List<Usuario> usuarios = new List<Usuario>();

      using (MySqlDataReader reader = cmd.ExecuteReader())
      {
        while (reader.Read())
        {
          usuarios.Add(
          new Usuario
          {
            IdUsuario  = (int)reader["IdUsuario"],
            Email      = (string)reader["Email"],
            Senha      = (string)reader["Senha"],
            Tipo       = (string)reader["Tipo"],
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