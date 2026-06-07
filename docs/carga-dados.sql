USE Biblioteca;

-- Dados de bibliotecas para demonstrar consultas de JOIN e de conjuntos
INSERT INTO Bibliotecas (Nome, Endereco, Telefone) VALUES
('Biblioteca Central', 'Rua Principal, 123', '1234-5678'),
('Biblioteca Secundária', 'Avenida Secundária, 456', '9876-5432');

-- Livros com autores que aparecem em múltiplas entradas para permitir GROUP BY + HAVING
INSERT INTO Livro (Titulo, Autor, AnoPublicacao, Editora) VALUES
('O Senhor dos Anéis', 'J.R.R. Tolkien', 1954, 'Allen & Unwin'),
('O Hobbit', 'J.R.R. Tolkien', 1937, 'Allen & Unwin'),
('1984', 'George Orwell', 1949, 'Secker & Warburg'),
('A Revolução dos Bichos', 'George Orwell', 1945, 'Secker & Warburg'),
('Dom Quixote', 'Miguel de Cervantes', 1605, 'Francisco de Robles'),
('Sense and Sensibility', 'Jane Austen', 1811, 'T. Egerton'),
('Orgulho e Preconceito', 'Jane Austen', 1813, 'T. Egerton');

-- Exemplares distribuídos entre as duas bibliotecas para UNION, INTERSECT, EXCEPT e agregações
INSERT INTO Exemplar (Quantidade, LivroID, BibliotecaID, Disponivel, Situacao) VALUES
(5, 1, 1, TRUE, 'Bom estado'),
(3, 2, 1, TRUE, 'Bom estado'),
(2, 3, 1, TRUE, 'Regular'),
(4, 4, 1, FALSE, 'Regular'),
(1, 5, 1, TRUE, 'Bom estado'),
(2, 1, 2, TRUE, 'Bom estado'),
(3, 2, 2, TRUE, 'Bom estado'),
(4, 6, 2, TRUE, 'Reformado'),
(2, 7, 2, FALSE, 'Reformado'),
(5, 3, 2, TRUE, 'Bom estado');

-- Empréstimos com multas diferentes para demonstrar MAX, MIN e AVG
INSERT INTO Emprestimo (ExemplarID, DataEmprestimo, DataDevolucao, Disponivel, Multa) VALUES
(1, '2024-06-01', '2024-06-10', FALSE, 0.00),
(2, '2024-06-03', '2024-06-14', FALSE, 1.50),
(3, '2024-06-05', '2024-06-16', FALSE, 2.00),
(4, '2024-06-07', '2024-06-18', FALSE, 0.00),
(5, '2024-06-09', '2024-06-20', FALSE, 3.50),
(6, '2024-06-11', '2024-06-22', FALSE, 0.00),
(7, '2024-06-13', '2024-06-24', FALSE, 2.50),
(8, '2024-06-15', '2024-06-26', FALSE, 1.00);

-- Usuários de exemplo para completar a base; não são necessários para as consultas atuais,
-- mas ajudam a ilustrar um cenário de biblioteca completo.
INSERT INTO Usuario (Nome, Email, Telefone, DataCadastro, TipoUsuario, Status) VALUES
('Alice Silva', 'alice.silva@email.com', '21999990000', '2024-01-10', 'Aluno', 'Ativo'),
('Bruno Costa', 'bruno.costa@email.com', '21999990001', '2024-02-03', 'Professor', 'Ativo'),
('Carla Sousa', 'carla.sousa@email.com', '21999990002', '2024-03-05', 'Aluno', 'Ativo');
