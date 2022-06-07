USE OCORRENCIAS;

CREATE VIEW vFuncionario AS
SELECT Usuario.IdUsuario, Usuario.Email,
Usuario.Tipo, Pessoa.CPF, Pessoa.IdPessoa,
Pessoa.Nome, Pessoa.Telefone,
Funcionario.IdFuncionario,
Funcionario.Cargo
FROM Funcionario, Pessoa, Usuario
WHERE Pessoa.IdPessoa = Funcionario.IdPessoa
AND Usuario.IdUsuario = Funcionario.IdUsuario;

SELECT * FROM vFuncionario;
