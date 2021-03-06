USE OCORRENCIAS;

drop VIEW vCliente;

CREATE VIEW vCliente AS
SELECT Usuario.IdUsuario, Usuario.Email,
Usuario.Tipo, Pessoa.CPF, Pessoa.IdPessoa,
Pessoa.Nome, Pessoa.Telefone,
Cliente.IdCliente
FROM Cliente, Pessoa, Usuario
WHERE Pessoa.IdPessoa = Cliente.IdPessoa
AND Usuario.IdUsuario = Cliente.IdUsuario;

SELECT * FROM vCliente;
