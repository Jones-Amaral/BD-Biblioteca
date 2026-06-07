# Carga de Dados e Consulta SQL

Este documento descreve a carga de dados de exemplo e explica as consultas SQL pedidas pelo PO para apresentação.

## Estrutura da carga de dados

O arquivo `docs/carga-dados.sql` contém os inserts de exemplo para as tabelas principais:

- `Bibliotecas`
- `Livro`
- `Exemplar`
- `Emprestimo`
- `Usuario`

### Objetivo da carga

A carga foi criada para demonstrar claramente:

- `JOIN` entre `Livro`, `Exemplar` e `Bibliotecas`
- `JOIN` entre `Emprestimo`, `Exemplar`, `Livro` e `Bibliotecas`
- `UNION`, `INTERSECT` e `EXCEPT` com duas bibliotecas distintas
- consultas de agregação com `SUM`, `COUNT`, `AVG`, `MAX`, `MIN`
- condições `GROUP BY` + `HAVING`

## Por que essa carga funciona para os exemplos

### 1) JOINs

- `GetLivrosComExemplaresAsync()` usa `Livro`, `Exemplar` e `Bibliotecas`
  - A carga tem exemplares em ambas as bibliotecas para mostrar títulos e quantidades por local.

- `GetEmprestimosComLivroEBibliotecaAsync()` usa `Emprestimo`, `Exemplar`, `Livro` e `Bibliotecas`
  - A carga de empréstimos está ligada a exemplares existentes, permitindo relacionar livro e biblioteca.

### 2) Operações de conjuntos

- `UNION`
  - A carga insere exemplares dos mesmos livros em Biblioteca 1 e Biblioteca 2.
  - Isso permite mostrar títulos que aparecem em uma ou outra biblioteca.

- `INTERSECT`
  - Os livros `O Senhor dos Anéis`, `O Hobbit` e `1984` existem nas duas bibliotecas.
  - Esses títulos aparecem no resultado comum entre as duas consultas.

- `EXCEPT`
  - O livro `Dom Quixote` está apenas na Biblioteca 1.
  - `EXCEPT` mostra títulos que existem na Biblioteca 1 e não aparecem na Biblioteca 2.

### 3) Agregações e `HAVING`

- `GetTotalExemplaresPorBibliotecaAsync()`
  - `SUM(e.Quantidade)` por biblioteca mostra a soma total de exemplares por local.
  - `HAVING SUM(e.Quantidade) >= 0` é um `HAVING` simples para manter a cláusula no exemplo.

- `GetLivrosDisponiveisPorAutorAsync()`
  - `COUNT(*)` de livros disponíveis por autor.
  - `HAVING COUNT(*) > 1` garante que apenas autores com mais de um título disponível sejam exibidos.

- `GetMediaExemplaresPorBibliotecaAsync()`
  - `AVG(e.Quantidade)` por biblioteca.
  - `HAVING AVG(e.Quantidade) > 2` filtra bibliotecas com média maior que 2 exemplares por registro.

- `GetMultasMaxMinMediaAsync()`
  - `MAX(Multa)`, `MIN(Multa)` e `AVG(Multa)` sobre todas as multas de empréstimo.
  - A carga traz multas diferentes para demonstrar os três valores.

## Como usar

1. Garanta que o banco de dados esteja criado e a conexão esteja funcionando.
2. Execute o script de schema principal do banco.
3. Execute `docs/carga-dados.sql` para popular os dados de exemplo.
4. Inicie o projeto e vá até o menu principal.
5. Escolha `4 - Consultas SQL` e selecione qualquer consulta do submenu.

## Resultados esperados

Alguns exemplos de resultados que devem aparecer com a carga de dados exemplo:

- `Total de exemplares por biblioteca`
  - Biblioteca Central -> soma de quantidades
  - Biblioteca Secundária -> soma de quantidades

- `Livros disponíveis por autor`
  - `J.R.R. Tolkien` deve aparecer com mais de um livro disponível.
  - `George Orwell` deve aparecer com mais de um livro disponível.

- `Média de exemplares por biblioteca`
  - Exibe bibliotecas com média de quantidade acima de 2.

- `Multa máxima, mínima e média`
  - Mostra valores agregados de multas para os empréstimos inseridos.

## Observação

A carga foi feita para refletir o padrão de consulta já implementado no repositório, com variáveis `sql` claras e consultas legíveis.
