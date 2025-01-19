# VeggieVibes

API para gerenciamento de receitas vegetarianas e veganas.

## Tecnologias

- .NET 8
- Entity Framework Core
- SQL Server

## Como executar

1. Clone o repositório
2. Configure o arquivo docker-compose.yml com suas credenciais
3. Execute o SQL Server com Docker:
   ```bash
   docker-compose up -d
   ```
4. Execute a API:
   ```bash
   cd src/VeggieVibes.Api
   dotnet run
   ```

## Estrutura do Projeto

- VeggieVibes.Api: API REST
- VeggieVibes.Application: Regras de negócio
- VeggieVibes.Domain: Entidades e interfaces
- VeggieVibes.Infrastructure: Acesso a dados
- VeggieVibes.Communication: DTOs e contratos
- VeggieVibes.Exception: Exceções customizadas
