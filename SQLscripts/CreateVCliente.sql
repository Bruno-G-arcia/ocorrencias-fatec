USE OCORRENCIAS;

CREATE VIEW vCliente AS
SELECT usuario.IdUsuario, usuario.Email,
Usuario.Tipo, pessoa.CPF, pessoa.IdPessoa,
Pessoa.Nome, Pessoa.Telefone,
Cliente.IdCliente
FROM Cliente
LEFT JOIN Pessoa
ON Pessoa.IdPessoa = Cliente.IdPessoa
LEFT JOIN Usuario
ON Usuario.IdUsuario = Cliente.IdUsuario;

SELECT * FROM vCliente;
