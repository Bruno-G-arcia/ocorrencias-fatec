USE OCORRENCIAS;

CREATE TABLE Endereco(
  IdEndereco    INTEGER AUTO_INCREMENT NOT NULL,
  Cidade        VARCHAR(100),
  Estado        VARCHAR(100),
  Rua           VARCHAR(100),
  Numero        INTEGER,
  CEP           VARCHAR(100),
  PRIMARY KEY(IdEndereco)
);