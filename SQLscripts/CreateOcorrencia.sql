USE OCORRENCIAS;

CREATE TABLE Ocorrencia(
  IdOcorrencia      INTEGER AUTO_INCREMENT NOT NULL,
  Titulo            VARCHAR(100),
  Descricao         VARCHAR(500),
  Abertura          DATE,
  Prazo             DATE,
  Status            VARCHAR(100),
  Prioridae         VARCHAR(100),
  IdCliente         INTEGER,
  PRIMARY KEY(IdOcorrencia)
);