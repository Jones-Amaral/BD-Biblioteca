# BD-Biblioteca - V1.0

Sistema gerenciador de bibliotecas desenvolvido em C# com .NET 10.0 e MySQL. Este projeto oferece uma solução integrada para gerenciar livros, autores, bibliotecas, usuários, empréstimos, funcionários e consultas SQL.

## Versão Atual

**V1.0** - Versão inicial com funcionalidades básicas de gerenciamento de biblioteca e consultas SQL documentadas.

---

##  Pre-requisitos

Antes de executar o projeto, certifique-se de ter os seguintes requisitos instalados:

- **.NET 10.0 SDK** ou superior ([Download](https://dotnet.microsoft.com/download))
- **MySQL Server** 8.0 ou superior ([Download](https://dev.mysql.com/downloads/mysql/))
- **Git** (opcional, para clonar o repositório)
- Um editor como **Visual Studio Code** ou **Visual Studio**

---

## ?? Configuração Inicial

### 1. Clonar ou Baixar o Projeto

```bash
git clone https://github.com/Jones-Amaral/BD-Biblioteca.git
cd BD-Biblioteca
```

### 2. **IMPORTANTE: Configurar o appsettings.json**

O arquivo `appsettings.json` contém as configurações de conexão com o banco de dados. Você **DEVE** adicionar este arquivo à sua máquina com suas próprias credenciais.

#### Como fazer:

1. Abra o arquivo `appsettings.json` na raiz do projeto
2. Configure a string de conexão com seus dados do MySQL:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Persist Security Info=False;Server=SEU_SERVIDOR;Port=PORTA;Database=NOME_DO_BANCO;uid=USUARIO;pwd=SENHA;"
  }
}
```

#### Exemplo com dados locais:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Persist Security Info=False;Server=localhost;Port=3306;Database=biblioteca;uid=root;pwd=sua_senha_aqui;"
  }
}
```

**?? Aten��o:**
- Substitua `SEU_SERVIDOR` pelo endere�o do seu servidor MySQL
- Substitua `PORTA` pela porta do MySQL (padr�o: 3306)
- Substitua `NOME_DO_BANCO` pelo nome do banco de dados
- Substitua `USUARIO` pelo usu�rio do MySQL
- Substitua `SENHA` pela senha do usu�rio MySQL

---

## 🗄️ Criar o Banco de Dados

### 1. Acessar o MySQL

```bash
mysql -u root -p
```

### 2. Criar o banco de dados

```sql
CREATE DATABASE biblioteca;
USE biblioteca;
```

### 3. Executar os scripts SQL

Execute todos os scripts SQL fornecidos na pasta `database/` nesta ordem:

```sql
-- Execute cada arquivo SQL nesta sequ�ncia:
source database/autores.sql;
source database/Biblioteca.sql;
source database/categorias.sql;
source database/usuarios.sql;
source database/funcionarios.sql;
source database/livros.sql;
source database/exemplares.sql;
source database/emprestimos.sql;
```

### 4. Carga de dados de demonstra��o

Para demonstrar as consultas de `JOIN`, `UNION`, `INTERSECT`, `EXCEPT` e agrega��es com `GROUP BY`/`HAVING`, use:

```sql
source docs/carga-dados.sql;
```

---

## ▶️ Executar o Projeto

### 1. Restaurar Depend�ncias

```bash
dotnet restore
```

### 2. Compilar o Projeto

```bash
dotnet build
```

### 3. Executar a Aplica��o

```bash
dotnet run
```

A aplica��o iniciar� e testar� a conex�o com o banco de dados.

Se houver erro, verifique:
- As credenciais no `appsettings.json`
- Se o MySQL está rodando
- Se o banco de dados foi criado corretamente

---

## 📋 Menu Principal

A aplica��o agora suporta os seguintes cadastros e a��es:

- Registrar livro
- Registrar autor
- Registrar biblioteca
- Registrar funcionário
- Registrar empréstimo
- Consultar livros
- Consultar autores
- Consultar bibliotecas
- Consultar funcionários
- Excluir livro
- Excluir funcionário
- Consultas SQL avançadas

### Observação sobre datas

- O cadastro de empréstimo utiliza o formato de data `DD/MM/YYYY`
- O cadastro de funcionário utiliza `DD/MM/YYYY`

---

## 📁 Estrutura do Projeto

```
BD-Biblioteca/
+-- appsettings.json           # Configura��es de conex�o (CONFIGURE LOCALMENTE)
+-- Program.cs                 # Ponto de entrada da aplica��o
+-- Library.Project.csproj     # Arquivo de projeto
+-- README.md                  # Este arquivo
+-- docs/                      # Documentação adicional e scripts de demonstração
�   +-- carga-dados.sql
�   +-- consultas.md
+-- database/                  # Scripts SQL para criar tabelas
�   +-- autores.sql
�   +-- Biblioteca.sql
�   +-- categorias.sql
�   +-- emprestimos.sql
�   +-- exemplares.sql
�   +-- funcionarios.sql
�   +-- livros.sql
�   +-- usuarios.sql
+-- model/                     # Classes de modelo de dados
�   +-- AutorModel.cs
�   +-- BibliotecaModel.cs
�   +-- CategoriaModel.cs
�   +-- EmprestimoModel.cs
�   +-- ExemplarModel.cs
�   +-- FuncionarioModel.cs
�   +-- LivroModel.cs
�   +-- UsuarioModel.cs
+-- Interfaces/                # Interfaces de repositórios e serviços
+-- Repositories/              # Implementa��es de acesso a dados
+-- Services/                  # Implementa��es de regras de neg�cio
+-- bin/, obj/                 # Diretórios de build (ignorados)
```

---

## 📊 Modelos de Dados

O projeto trabalha com as seguintes entidades:

- **Autor** - Cadastro de autores de livros
- **Biblioteca** - Informações da biblioteca
- **Categoria** - Categorias de livros
- **Livro** - Cadastro de livros
- **Exemplar** - Cópias dos livros
- **Usuário** - Usuários que pegam empréstimos
- **Funcionário** - Funcionários da biblioteca
- **Empréstimo** - Registro de empréstimos

---

## ?? Documenta��o Adicional

A pasta `docs/` cont�m:

- `docs/carga-dados.sql` - carga de dados de exemplo para demonstra��o
- `docs/consultas.md` - explica��o das consultas SQL implementadas

---

## 📦 Dependências do Projeto

- **Microsoft.Extensions.Configuration.Json** v10.0.8 - Gerenciar configura��es JSON
- **MySql.Data** v9.7.0 - Driver MySQL para .NET

---

## ⚠️ Notas Importantes

1. **appsettings.json é obrigatório**: Este arquivo não está sob versionamento por questões de segurança.
2. **Banco de dados em nuvem**: Se usar um servidor MySQL em nuvem, certifique-se de que o servidor está acessível.
3. **Firewalls**: Se a conexão falhar, verifique se o firewall não está bloqueando a porta do MySQL.
4. **.NET 10.0**: Este projeto usa a versão mais recente do .NET. Se receber erro de versão, instale o SDK correto.

---

## 💬 Suporte

Se encontrar problemas:

1. Verifique se todas as depend�ncias est�o instaladas
2. Confirme que o MySQL est� rodando
3. Valide a string de conex�o no `appsettings.json`
4. Verifique os logs de erro na console

---

**Desenvolvido pela equipe de BD**
