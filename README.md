# BD-Biblioteca - V1.0

Sistema gerenciador de bibliotecas desenvolvido em C# com .NET 10.0 e MySQL. Este projeto oferece uma solução integrada para gerenciar livros, usuários, empréstimos, funcionários e categorias em uma biblioteca.

## Versão Atual

**V1.0** - Versão inicial com funcionalidades básicas de gerenciamento de biblioteca.

---

## 📋 Pré-requisitos

Antes de executar o projeto, certifique-se de ter os seguintes requisitos instalados:

- **.NET 10.0 SDK** ou superior ([Download](https://dotnet.microsoft.com/download))
- **MySQL Server** 8.0 ou superior ([Download](https://dev.mysql.com/downloads/mysql/))
- **Git** (opcional, para clonar o repositório)
- Um editor como **Visual Studio Code** ou **Visual Studio**

---

## 🔧 Configuração Inicial

### 1. Clonar ou Baixar o Projeto

```bash
git clone <seu-repositório>
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

**⚠️ Atenção:**
- Substitua `SEU_SERVIDOR` pelo endereço do seu servidor MySQL
- Substitua `PORTA` pela porta do MySQL (padrão: 3306)
- Substitua `NOME_DO_BANCO` pelo nome do banco de dados
- Substitua `USUARIO` pelo usuário do MySQL
- Substitua `SENHA` pela senha do usuário MySQL

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
-- Execute cada arquivo SQL nesta sequência:
source database/autores.sql;
source database/Biblioteca.sql;
source database/categorias.sql;
source database/usuarios.sql;
source database/funcionarios.sql;
source database/livros.sql;
source database/exemplares.sql;
source database/emprestimos.sql;
```

Ou, alternativamente, no MySQL Workbench, abra cada arquivo e execute.

---

## ▶️ Executar o Projeto

### 1. Restaurar Dependências

```bash
dotnet restore
```

### 2. Compilar o Projeto

```bash
dotnet build
```

### 3. Executar a Aplicação

```bash
dotnet run
```

A aplicação iniciará e testará a conexão com o banco de dados. Se bem-sucedida, você verá:

```
Conexão aberta com sucesso!
```

Se houver erro, verifique:
- As credenciais no `appsettings.json`
- Se o MySQL está rodando
- Se o banco de dados foi criado corretamente

---

## 📁 Estrutura do Projeto

```
BD-Biblioteca/
├── appsettings.json           # Configurações de conexão (CONFIGURE LOCALMENTE)
├── Program.cs                 # Ponto de entrada da aplicação
├── Library.Project.csproj     # Arquivo de projeto
├── README.md                  # Este arquivo
├── database/                  # Scripts SQL para criar tabelas
│   ├── autores.sql
│   ├── Biblioteca.sql
│   ├── categorias.sql
│   ├── emprestimos.sql
│   ├── exemplares.sql
│   ├── funcionarios.sql
│   ├── livros.sql
│   └── usuarios.sql
├── model/                     # Classes de modelo de dados
│   ├── AutorModel.cs
│   ├── BibliotecaModel.cs
│   ├── CategoriaModel.cs
│   ├── EmprestimoModel.cs
│   ├── ExemplarModel.cs
│   ├── FuncionarioModel.cs
│   ├── LivroModel.cs
│   └── UsuarioModel.cs
├── shared/                    # Classes compartilhadas
│   └── Connection.cs          # Gerenciador de conexão com banco
└── bin/, obj/                 # Diretórios de build (ignorados)
```

---

## 📊 Modelos de Dados

O projeto trabalha com as seguintes entidades:

- **Autor** - Cadastro de autores de livros
- **Biblioteca** - Informações da biblioteca
- **Categoria** - Categorias de livros
- **Livro** - Cadastro de livros
- **Exemplar** - Cópias dos livros
- **Usuário** - Usuários que pegam emprestado
- **Funcionário** - Funcionários da biblioteca
- **Empréstimo** - Registro de empréstimos

---

## 🛠️ Dependências do Projeto

- **Microsoft.Extensions.Configuration.Json** v10.0.8 - Gerenciar configurações JSON
- **MySql.Data** v9.7.0 - Driver MySQL para .NET

---

## 📝 Notas Importantes

1. **appsettings.json é obrigatório**: Este arquivo não está sob versionamento por questões de segurança. Você deve configurá-lo em sua máquina com as credenciais corretas.

2. **Banco de dados em nuvem**: Se usar um servidor MySQL em nuvem (como Railway, AWS RDS, etc.), certifique-se de que o servidor está acessível de sua máquina.

3. **Firewalls**: Se a conexão falhar, verifique se o firewall não está bloqueando a porta do MySQL.

4. **.NET 10.0**: Este projeto usa a versão mais recente do .NET. Se receber erro de versão, instale o SDK correto.

---

## 🤝 Suporte

Se encontrar problemas:

1. Verifique se todas as dependências estão instaladas
2. Confirme que o MySQL está rodando
3. Valide a string de conexão no `appsettings.json`
4. Verifique os logs de erro na console

---

**Desenvolvido com ❤️**