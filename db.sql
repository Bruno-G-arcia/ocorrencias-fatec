USE OCORRENCIAS;
-- INSERT INTO Ocorrencia (Titulo, Descricao, Abertura, Prazo, Status, Prioridade, idCliente) 
--     VALUES("Botao nao funcionando", "Teste", 23/05/2022, 23/06/2022, "Suporte", "Urgente", 1);

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

SELECT * FROM Ocorrencia;