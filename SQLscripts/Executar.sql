USE OCORRENCIAS;

ALTER TABLE Ocorrencia
ADD COLUMN Prioridade VARCHAR(100) AFTER Status;

SELECT * FROM Ocorrencia;