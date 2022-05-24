USE OCORRENCIAS;

CREATE TABLE OrdemServico(
  IdOrdemServico    INTEGER AUTO_INCREMENT NOT NULL,
  Titulo            VARCHAR(100),
  Descricao         VARCHAR(100),
  Abertura          VARCHAR(100),
  IdFuncionario     INTEGER,
  IdOcorrencia      INTEGER,
  PRIMARY KEY(IdOrdemServico)
);