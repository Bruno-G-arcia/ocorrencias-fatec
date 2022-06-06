using OcorrenciasWeb.Models;
using MySqlConnector;

namespace OcorrenciasWeb.Repositories
{
  public class PessoaRepository : DBContext, IPessoaRepository
  {

    public void Create(Pessoa pessoa)
    { 
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"INSERT INTO Pessoa (Nome, Cpf, Telefone) 
      VALUES(@nome, @cpf, @telefone);";

      cmd.Parameters.AddWithValue("@nomel",     pessoa.Nome);
      cmd.Parameters.AddWithValue("@cpf",       pessoa.Cpf);
      cmd.Parameters.AddWithValue("@telefone",  pessoa.Telefone);

      cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"DELETE FROM Pessoa WHERE 
      Pessoa.IdPessoa = @id;";

      cmd.Parameters.AddWithValue("@id", id);

      cmd.ExecuteNonQuery();
    }

    public List<Pessoa> Read()
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"SELECT * FROM Pessoa;";
      List<Pessoa> pessoas = new List<Pessoa>();

      using (MySqlDataReader reader = cmd.ExecuteReader())
      {
        while (reader.Read())
        {
          pessoas.Add(
          new Pessoa
          {
            IdPessoa  = (int)reader["IdPessoa"],
            Nome      = (string)reader["Nome"],
            Cpf       = (string)reader["Cpf"],
            Telefone  = (string)reader["Telefone"],
          });
        }

      }
      return pessoas;
    }

    public Pessoa Read(int id)
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"SELECT * FROM Pessoa
      WHERE IdPessoa = @id;";

      cmd.Parameters.AddWithValue("@id", id);
      Pessoa pessoa = new Pessoa();

      using (MySqlDataReader reader = cmd.ExecuteReader())
      {
        while (reader.Read())
        {
          pessoa.IdPessoa = (int)reader["IdPessoa"];
          pessoa.Nome     = (string)reader["Nome"];
          pessoa.Cpf      = (string)reader["Cpf"];
          pessoa.Telefone = (string)reader["Telefone"];
        }
      }
      return pessoa;
    }

    public void Update(int id, Pessoa pessoa)
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"UPDATE Pessoa 
      SET Nome    = @nome,
      Cpf         = @cpf,
      Telefone    = @telefone
      WHERE IdPessoa = @id;";

      cmd.Parameters.AddWithValue("@nomel", pessoa.Nome);
      cmd.Parameters.AddWithValue("@cpf", pessoa.Cpf);
      cmd.Parameters.AddWithValue("@telefone", pessoa.Telefone);
      cmd.Parameters.AddWithValue("@id", id);

      cmd.ExecuteNonQuery();
    }




  }
}