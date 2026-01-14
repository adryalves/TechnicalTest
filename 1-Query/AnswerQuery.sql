-- Afim de conseguir testar, eu criei o banco de dados e as tabelas descritas na atividade. Por isso essas primeiras queries são disso.
CREATE DATABASE Teste;
Use teste;

CREATE TABLE Departamento (
    Id INT PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL
);

CREATE TABLE Pessoa (
    Id INT PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL,
    Salario INT NOT NULL,
    DeptId INT,
    FOREIGN KEY (DeptId) REFERENCES Departamento(Id)
);

-- RESPOSTA DA ATIVIDADE. Aqui tem a query que foi pedida, com o intuito de encontrar os colaboradores que tem o salário mais alto em cada um dos departamentos.

Select * FROM Pessoa AS p
Inner JOIN Departamento AS d
WHERE p.DeptId = d.Id;

SELECT 
    d.Nome AS Departamento,
    p.Nome AS Pessoa,
    p.Salario
FROM Pessoa p
JOIN Departamento d 
    ON p.DeptId = d.Id
WHERE p.Salario = (
    SELECT MAX(p2.Salario)
    FROM Pessoa p2
    WHERE p2.DeptId = p.DeptId
) ORDER BY  p.Salario DESC ;
