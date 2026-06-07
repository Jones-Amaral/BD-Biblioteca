# BD-Biblioteca
Este projeto oferece uma solução integrada para gerenciar livros, autores, bibliotecas, usuários, empréstimos, funcionários e consultas SQL.

# Alunos
- Bernardo Maia Lomas Ameno
- Gustavo Almeida Reis
- João Vitor Alves Amaral
- Lucas Gabriel Adelino Araújo
- Matheus Henrique Borges Ferreira

##  Pre-requisitos

Antes de executar o projeto, certifique-se de ter os seguintes requisitos instalados:

- **.NET 10.0 SDK** ou superior ([Download](https://dotnet.microsoft.com/download))
- **MySQL Server** 8.0 ou superior ([Download](https://dev.mysql.com/downloads/mysql/))
- **Git** (opcional, para clonar o repositório)
- Um editor como **Visual Studio Code** ou **Visual Studio**

---

## Configuração Inicial

### 1. Clonar ou Baixar o Projeto
git clone https://github.com/Jones-Amaral/BD-Biblioteca.git

### 2. **IMPORTANTE: Configurar o appsettings.json**

#### Como fazer:

1. Abra o arquivo `appsettings.json` na raiz do projeto ou o crie se não for clonado
2. Configure a string de conexão com seus dados do MySQL, colocando esse código dentro do arquivo `appsettings.json`:

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=turntable.proxy.rlwy.net;Port=59566;Database=railway;Uid=root;Pwd=bWfRcKgdjABsQhaddzbVxzsQMAOzEPlt;"
  }
}
```

## 📁 Estrutura do Projeto

```
BD-BIBLIOTECA/
├── bin/
│   └── Debug/net10.0/
├── database/
│   ├── autores.sql
│   ├── Biblioteca.sql
│   ├── Bibliotecas.sql
│   ├── categorias.sql
│   ├── emprestimos.sql
│   ├── exemplares.sql
│   ├── funcionarios.sql
│   ├── livros.sql
│   └── usuarios.sql
├── docs/
│   ├── carga-dados.sql
│   └── consultas.md
├── Infrastructure/
│   └── Connection.cs
├── Interfaces/
│   ├── Infrastructure/
│   │   └── IConnection.cs
│   ├── Repositories/
│   │   ├── IAutorRepository.cs
│   │   ├── IBibliotecaRepository.cs
│   │   ├── IConsultaRepository.cs
│   │   ├── IEmprestimoRepository.cs
│   │   ├── IFuncionarioRepository.cs
│   │   ├── ILivroRepository.cs
│   │   └── IUsuarioRepository.cs
│   └── Services/
│       ├── IAutorService.cs
│       ├── IBibliotecaService.cs
│       ├── IConsultaService.cs
│       ├── IEmprestimoService.cs
│       ├── IFuncionarioService.cs
│       ├── ILivroService.cs
│       └── IUsuarioService.cs
├── model/
│   ├── AutorModel.cs
│   ├── BibliotecaModel.cs
│   ├── CategoriaModel.cs
│   ├── ConsultaResultadoModel.cs
│   ├── EmprestimoModel.cs
│   ├── ExemplarModel.cs
│   ├── FuncionarioModel.cs
│   ├── LivroModel.cs
│   └── UsuarioModel.cs
├── obj/
│   ├── Debug/net10.0/
│   ├── Library.Project.csproj.nuget.dgspec.json
│   ├── Library.Project.csproj.nuget.g.props
│   ├── Library.Project.csproj.nuget.g.targets
│   ├── project.assets.json
│   └── project.nuget.cache
├── Repositories/
│   ├── AutorRepository.cs
│   ├── BibliotecaRepository.cs
│   ├── ConsultaRepository.cs
│   ├── EmprestimoRepository.cs
│   ├── FuncionarioRepository.cs
│   ├── LivroRepository.cs
│   └── UsuarioRepository.cs
├── Services/
│   ├── AutorService.cs
│   ├── BibliotecaService.cs
│   ├── ConsultaService.cs
│   ├── EmprestimoService.cs
│   ├── FuncionarioService.cs
│   ├── LivroService.cs
│   └── UsuarioService.cs
├── .gitignore
├── appsettings.json
├── Biblioteca - UML.png
├── DER-Biblioteca.jpeg
├── Library.Project.csproj
├── Program.cs
└── README.md
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