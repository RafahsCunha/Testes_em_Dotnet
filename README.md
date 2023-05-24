Dependências

*Pacotes

- .Net 5.0
- Mysql Workbench 8.0.32
- xUnit 2.4.1 -> Ferramenta para testes unitários
- EntityFramework 5.0.11 -> Framework para fazer persistências do banco de dados
- Moq 4.16.1 -> Biblioteca para simular criação de um banco de dados em memória


*Referenciar projeto de testes


- Adicionar projeto de testes à "Referencia de projetos" e selecionar o projeto que será testado 
- (A ação acima seleciona a camada que será testada)


*Criação das tabelas 


- Configurar String de conexão
- Console do gerenciador de Pacotes - Selecionar pasta do projeto + Dados: dotnet ef database update
- Adicionar uma migração (popular o banco com mais informações):  dotnet ef migrations add PopularBanco 
