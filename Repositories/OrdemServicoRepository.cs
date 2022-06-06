using OcorrenciasWeb.Models;
using MySqlConnector;

namespace OcorrenciasWeb.Repositories
{
  public class OrdemServicoRepository : DBContext, IOrdemServicoRepository
  {

    public void Create(OrdemServico ordemServico)
    { 
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText =
      @"INSERT INTO OrdemServico (IdOcorrencia, Titulo, Descricao, Abertura, Status, IdFuncionario) 
      VALUES(@idOcorrencia, @titulo, @descricao, @abertura, @status, @idFuncionario);";

      cmd.Parameters.AddWithValue("@idOcorrencia",  ordemServico.IdOcorrencia);
      cmd.Parameters.AddWithValue("@titulo",        ordemServico.Titulo);
      cmd.Parameters.AddWithValue("@descricao",     ordemServico.Descricao);
      cmd.Parameters.AddWithValue("@abertura",      ordemServico.Abertura);
      cmd.Parameters.AddWithValue("@status",        ordemServico.Status);
      cmd.Parameters.AddWithValue("@idFuncionario", ordemServico.IdFuncionario);

      cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"DELETE FROM OrdemServico 
      WHERE IdOrdemServico = @id;";

      cmd.Parameters.AddWithValue("@id", id);

      cmd.ExecuteNonQuery();
    }

    public List<OrdemServico> Read()
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"SELECT * FROM OrdemServico;";
      List<OrdemServico> ordemServicos  = new List<OrdemServico>();

      using (MySqlDataReader reader = cmd.ExecuteReader())
      {
        while (reader.Read())
        {
          ordemServicos.Add(
          new OrdemServico
          {
            IdOcorrencia    = (int)reader["IdOcorrencia"],
            Titulo          = (string)reader["Titulo"],
            Descricao       = (string)reader["Descricao"],
            Abertura        = (DateTime)reader["Abertura"],
            Status          = (string)reader["Status"],
            IdFuncionario   = (int)reader["IdFuncionario"]
          });
        }

      }
      return ordemServicos;
    }
        
    public OrdemServico Read(int id)
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"SELECT * FROM OrdemServico
      WHERE IdOrdemServico = @id;";

      cmd.Parameters.AddWithValue("@id", id);
      OrdemServico ordemServico = new OrdemServico();

      using (MySqlDataReader reader = cmd.ExecuteReader())
      {
        while (reader.Read())
        {
          ordemServico.IdOcorrencia = (int)reader["IdOcorrencia"];
          ordemServico.Titulo = (string)reader["Titulo"];
          ordemServico.Descricao = (string)reader["Descricao"];
          ordemServico.Abertura = (DateTime)reader["Abertura"];
          ordemServico.Status = (string)reader["Status"];
          ordemServico.IdFuncionario = (int)reader["IdFuncionario"];

        }
      }
      return ordemServico;
    }

    public void Update(int id, OrdemServico ordemServico)
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = 
      @"UPDATE OrdemServico 
      SET
      IdOcorrencia  = @idOcorrencia,
      Titulo        = @titulo,
      Descricao     = @descricao,
      Abertura      = @abertura,
      Status        = @status,
      IdFuncionario = @IdFuncionario
      WHERE IdFuncionario = @id;";

      cmd.Parameters.AddWithValue("@idOcorrencia", ordemServico.IdOcorrencia);
      cmd.Parameters.AddWithValue("@titulo", ordemServico.Titulo);
      cmd.Parameters.AddWithValue("@descricao", ordemServico.Descricao);
      cmd.Parameters.AddWithValue("@abertura", ordemServico.Abertura);
      cmd.Parameters.AddWithValue("@status", ordemServico.Status);
      cmd.Parameters.AddWithValue("@idFuncionario", ordemServico.IdFuncionario);
      cmd.Parameters.AddWithValue("@id", id);

      cmd.ExecuteNonQuery();

    }
  }
}