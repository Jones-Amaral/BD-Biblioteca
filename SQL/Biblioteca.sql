CREATE DATABASE Biblioteca;

USE Biblioteca;

CREATE TABLE Bibliotecas (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    Nome VARCHAR(255) NOT NULL,
    Endereco VARCHAR(255) NOT NULL,
    Telefone VARCHAR(20) NOT NULL
)

/* Tabela de Livros, o "conceito" livro */
CREATE TABLE Livro (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    Titulo VARCHAR(255) NOT NULL,
    Autor VARCHAR(255) NOT NULL,
    AnoPublicacao INT NOT NULL,
    Editora VARCHAR(255) NOT NULL
)

/* Tabela de Exemplares, os "itens" do livro */
CREATE TABLE Exemplar (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    Quantidade INT NOT NULL,
    LivroID INT,
    BibliotecaID INT,
    Disponivel BOOLEAN NOT NULL,
    Situacao VARCHAR(50) NOT NULL,
    FOREIGN KEY (LivroID) REFERENCES Livro (ID),
    FOREIGN KEY (BibliotecaID) REFERENCES Biblioteca (ID)
)

CREATE TABLE Autor (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    Nome VARCHAR(255) NOT NULL,
    Nacionalidade VARCHAR(255) NOT NULL
)

CREATE TABLE Categoria (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    Nome VARCHAR(255) NOT NULL
)

CREATE TABLE Emprestimo (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    ExemplarID INT,
    DataEmprestimo DATE NOT NULL,
    DataDevolucao DATE NOT NULL,
    Disponivel BOOLEAN NOT NULL,
    Multa DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (ExemplarID) REFERENCES Exemplar (ID)
)

/* Que pode ser aluno ou professor */
CREATE TABLE Usuario ( 
    ID INT PRIMARY KEY AUTO_INCREMENT,
    Nome VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    Telefone VARCHAR(20) NOT NULL,
    DataCadastro DATE NOT NULL,
    TipoUsuario VARCHAR(50) NOT NULL,
    Status VARCHAR(50) NOT NULL
)

CREATE TABLE Funcionario (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    Nome VARCHAR(255) NOT NULL,
    Cargo VARCHAR(255) NOT NULL,
    Salario DECIMAL(10, 2) NOT NULL,
    DataContratacao DATE NOT NULL
)