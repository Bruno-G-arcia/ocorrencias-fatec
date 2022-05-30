USE OCORRENCIAS;
INSERT INTO Usuario (Email, Senha, Tipo) 
VALUES("cliente", "1", "Cliente");

-- ALTER TABLE Ocorrencia
-- ADD COLUMN IdCliente INT AFTER Prioridade;

-- ALTER TABLE Ocorrencia 
-- DROP CodFuncionario;

-- UPDATE Ocorrencia
--     SET Titulo  = 'teste',
--     Descricao   = 'teste',
--     Abertura    = '2022-05-25',
--     Prazo       = '2022-06-25',
--     Prioridade  = 'Normal',
--     IdCliente   = 1
--     WHERE Ocorrencia.IdOcorrencia <  99;

SELECT * FROM Usuario;