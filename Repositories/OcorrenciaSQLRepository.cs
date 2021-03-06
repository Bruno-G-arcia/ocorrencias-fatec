using OcorrenciasWeb.Models;
using MySqlConnector;

namespace OcorrenciasWeb.Repositories
{
  public class OcorrenciaSQLRepository : DBContext, IOcorrenciaRepository
  {

    public void Create(Ocorrencia ocorrencia)
    {

      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"INSERT INTO Ocorrencia (Titulo, Descricao, Abertura, Prazo, Status, Prioridade, idCliente) 
    VALUES(@titulo, @descricao, @abertura, @prazo, @status, @prioridade, @idCliente);";

      var abertura = DateTime.Now.ToString("yyyy-MM-dd");
      var prazo = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd");

      cmd.Parameters.AddWithValue("@titulo", ocorrencia.Titulo);
      cmd.Parameters.AddWithValue("@descricao", ocorrencia.Descricao);
      cmd.Parameters.AddWithValue("@abertura", abertura);
      cmd.Parameters.AddWithValue("@prazo", prazo);
      cmd.Parameters.AddWithValue("@status", "Suporte");
      cmd.Parameters.AddWithValue("@prioridade", "Normal");
      cmd.Parameters.AddWithValue("@idCliente", ocorrencia.IdCliente);

      cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"DELETE FROM Ocorrencia WHERE 
      Ocorrencia.IdOcorrencia = @id;";

      cmd.Parameters.AddWithValue("@id", id);

      cmd.ExecuteNonQuery();
    }

    public List<Ocorrencia> Read()
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"SELECT * FROM Ocorrencia;";
      List<Ocorrencia> ocorrencias = new List<Ocorrencia>();

      using (MySqlDataReader reader = cmd.ExecuteReader())
      {
        while (reader.Read())
        {
          ocorrencias.Add(
          new Ocorrencia
          {
            IdOcorrencia = (int)reader["IdOcorrencia"],
            Titulo = (string)reader["Titulo"],
            Descricao = (string)reader["Descricao"],
            Abertura = (DateTime)reader["Abertura"],
            Prazo = (DateTime)reader["Prazo"],
            Prioridade = (string)reader["Prioridade"],
            IdCliente = (int)reader["IdCliente"],
            Status = (string)reader["Status"]
          });
        }
      }

      return ocorrencias;
    }

    public List<Ocorrencia> ReadCliente(int id)
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"SELECT * FROM Ocorrencia
      WHERE Ocorrencia.IdCliente = @id;";

      cmd.Parameters.AddWithValue("@id", id);

      List<Ocorrencia> ocorrencias = new List<Ocorrencia>();
      using (MySqlDataReader reader = cmd.ExecuteReader())
      {
        while (reader.Read())
        {
          ocorrencias.Add(
          new Ocorrencia
          {
            IdOcorrencia = (int)reader["IdOcorrencia"],
            Titulo = (string)reader["Titulo"],
            Abertura = (DateTime)reader["Abertura"],
            Prazo = (DateTime)reader["Prazo"],
            Prioridade = (string)reader["Prioridade"],
            IdCliente = (int)reader["IdCliente"],
            Status = (string)reader["Status"]

          });
        }

      }

      return ocorrencias;
    }

    public Ocorrencia Read(int id)
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"SELECT * FROM Ocorrencia
    WHERE IdOcorrencia = @id;";


      cmd.Parameters.AddWithValue("@id", id);
      Ocorrencia ocorrencia = new Ocorrencia();

      using (MySqlDataReader reader = cmd.ExecuteReader())
      {
        while (reader.Read())
        {
          ocorrencia.IdOcorrencia = (int)reader["IdOcorrencia"];
          ocorrencia.Titulo = (string)reader["Titulo"];
          ocorrencia.Descricao = (string)reader["Descricao"];
          ocorrencia.Abertura = (DateTime)reader["Abertura"];
          ocorrencia.Prazo = (DateTime)reader["Prazo"];
          ocorrencia.Prioridade = (string)reader["Prioridade"];
          ocorrencia.IdCliente = (int)reader["IdCliente"];
          ocorrencia.Status = (string)reader["Status"];
        }
      }
      return ocorrencia;
    }

    public override string? ToString()
    {
      return base.ToString();
    }

    public void Update(int id, Ocorrencia ocorrencia)
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"UPDATE Ocorrencia 
      SET Titulo  = @titulo,
      Descricao   = @descricao,
      Abertura    = @abertura,
      Prazo       = @prazo,
      Prioridade  = @prioridade,
      Status      = @status,
      IdCliente   = @idCliente
      WHERE Ocorrencia.IdOcorrencia = @id;";


      cmd.Parameters.AddWithValue("@id", id);
      cmd.Parameters.AddWithValue("@titulo", ocorrencia.Titulo);
      cmd.Parameters.AddWithValue("@descricao", ocorrencia.Descricao);
      cmd.Parameters.AddWithValue("@abertura", ocorrencia.Abertura);
      cmd.Parameters.AddWithValue("@prazo", ocorrencia.Prazo);
      cmd.Parameters.AddWithValue("@prioridade", ocorrencia.Prioridade);
      cmd.Parameters.AddWithValue("@idCliente", ocorrencia.IdCliente);
      cmd.Parameters.AddWithValue("@status", ocorrencia.Status);

      cmd.ExecuteNonQuery();

    }

    public List<Ocorrencia> ReadCargo(string cargo)
    {
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = @"SELECT * FROM Ocorrencia
      WHERE Ocorrencia.Status = @cargo;";

      cmd.Parameters.AddWithValue("@carg", cargo);
      List<Ocorrencia> ocorrencias = new List<Ocorrencia>();

      using (MySqlDataReader reader = cmd.ExecuteReader())
      {
        while (reader.Read())
        {
          ocorrencias.Add(
          new Ocorrencia
          {
            IdOcorrencia = (int)reader["IdOcorrencia"],
            Titulo = (string)reader["Titulo"],
            Descricao = (string)reader["Descricao"],
            Abertura = (DateTime)reader["Abertura"],
            Prazo = (DateTime)reader["Prazo"],
            Prioridade = (string)reader["Prioridade"],
            IdCliente = (int)reader["IdCliente"],
            Status = (string)reader["Status"]
          });
        }
      }

      return ocorrencias;
    }



  }




}