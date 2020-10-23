# Api .NET CORE

Api feita com .NET CORE e Entity Framework Core.

## Explicação de como foi gerado o projeto e instalado os pacotes

Primeiramente foi verificado se o dotnet esta instalado, com o comando:

```sh
dotnet --version
```

Para iniciar um projeto com .NET Core execute o comando:

```sh
dotnet new webapi -n nomeDoProjeto
```

Em seguida foram instalados os pacotes do Microsoft.EntityFrameworkCore com os comandos a seguir:

```sh
dotnet add package Microsoft.EntityFrameworkCore
```

```sh
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

```sh
dotnet add package Microsoft.EntityFrameworkCore.Design
```

```sh
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```

```sh
dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson
```

**Obs:** Depois de instalados os pacotes, as configurações devem ser feitas conforme o arquivo **Startup.cs**

## Instalar Ferramentas Locais

Para configurar as migrations foram feitos os seguintes procedimentos:

Para instalar ferramentas locais.
Primeiro rode o comendo **dotnet new tool-manifest**, em seguida rode o comando para instalar a ferramenta que deseja, Ex: **dotnet tool install dotnet-ef**.

_Referência_: https://docs.microsoft.com/pt-br/dotnet/core/tools/global-tools#install-a-local-tool

## Comandos para rodar as migrations

Criar as migrations.

```sh
dotnet ef migrations add NomeDaMigration
```

Remover as migrations criadas.

```sh
dotnet ef migrations remove
```

Criar/Atualizar esquema de tabelas do banco de dados configurado.

```sh
dotnet ef database update
```

_Referência_: https://docs.microsoft.com/pt-br/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
