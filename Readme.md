# Exemplo de Aplicação utilizando DDD

  Este projeto foi criado basedo no artigo ["Uma arquitetura, em .Net Core, baseada nos princípios do DDD"](https://medium.com/@alexalvess/criando-uma-api-em-net-core-baseado-na-arquitetura-ddd-2c6a409c686) escrito pelo [*Alex Alves*](https://github.com/alex250195).

  Implementei todo o projeto utilizando as seguintes ferramentas:
  - [dotnet CLI](https://dotnet.microsoft.com/download)
  - [Visual Studio Code](https://code.visualstudio.com/)
  - [Insomnia](https://insomnia.rest/)

  Fiz algumas modificações no projeto original do *Alex*:
  - Migração para a versão 3.1 do Dotnet;
  - Utilização do SQLLite para simplificar os testes e diminuir as dependencias externas;
  - Alterei a forma de utilização do **DbContext**, para utilizar o conceito de *Injeção de Dependencia*. Com esta alteração acredito ter conseguido os seguintes benefícios:
    - Permitir a troca do banco de dados facilmente;
    - Facilitar a realização de testes;
  - Na classe de repositório começei a utilizar os acessos assincronos nos métodos de *pesquisa";

  ### Outras referencias utilizadas
    - https://tutexchange.com/how-to-use-fluentvalidation-in-asp-net-core/


## Procedimentos para criação dos Projetos através do "Dotnet CLI"

  Segue a lista dos comandos do **dotnet CLI** necessários para criação dos projetos envolvido e adição das referencias e packages necessários:

  1. Criar os projetos (*Você deve estar posicionado na pasta "ModeloApp"*)
      - `dotnet new webapi -n Application`
      - `dotnet new classlib -n Domain`
      - `dotnet new classlib -o Infra/Data -n Infra.Data`
      - `dotnet new classlib -o Infra/CrossCutting -n Infra.CrossCutting`
      - `dotnet new classlib -n Service`

  1. Adicionar os projetos na Solução (*Você deve estar posicionado na pasta "ModeloApp"*)
      - `dotnet sln TesteModeloApp.sln add Application`
      - `dotnet sln TesteModeloApp.sln add Domain`
      - `dotnet sln TesteModeloApp.sln add Infra/Data`
      - `dotnet sln TesteModeloApp.sln add Infra/CrossCutting`
      - `dotnet sln TesteModeloApp.sln add Service`

  1. Adicionar as dependencias entre a nossa Aplicação e as nossas bibliotecas
      - `dotnet add Application reference Domain`
      - `dotnet add Application reference Service`
      - `dotnet add Infra/Data reference Domain`
      - `dotnet add Service reference Domain`
      - `dotnet add Service reference Infra/Data`

  1. Adicionar os pacotes via **nuget**
      - `dotnet add Application package Microsoft.EntityFrameworkCore.Design --version 3.1.5`
      - `dotnet add Application package Microsoft.EntityFrameworkCore.Sqlite --version 3.1.5`
      - `dotnet add Application package FluentValidation.AspNetCore --version 8.6.2`
      - `dotnet add Domain package FluentValidation.AspNetCore --version 8.6.2`
      - `dotnet add Infra/Data package Microsoft.EntityFrameworkCore.Design --version 3.1.5`
      - `dotnet add Infra/Data package Microsoft.EntityFrameworkCore.Relational --version 3.1.5`
      - `dotnet add Service package FluentValidation.AspNetCore --version 8.6.2`

  Abaixo está a *estrutura final* das pastas:
  ```
    - ModeloApp
      - Application
        - Controllers
        - Data
          - Context
      - Domain
        - Entities
        - Interfaces
      - Infra
        - CrossCutting
        - Data
          - Context
          - Mapping
          - Repository
      - Service
        - Services
        - Validators
  ```
