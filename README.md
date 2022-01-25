# DevFreela
Este é um projeto de API .NET 5 criado no treinamento **Formação ASP NET Core**. Trata-se de uma plataforma para o cadastro de projetos por um cliente que deseja contratar desenvolvedores freelancers que estão cadastrados na plataforma.

#As funcionalidades implementadas nesse projeto são:

- Cadastro, Atualização, Cancelamento e Consulta de Projetos.
- Cadastro de Usuário Freelancerse Clientes.
- Adicionar comentários para um Projeto
- Criar, iniciar, realizar pagamento e finalizar o projeto

# Os conceitos praticados foram:

- .NET 5
- SQL Server
- Entity Framework Core 
- Dapper
- Arquitetura Limpa
- Padrão de Projeto Repository
- Padrão CQRS
- FluentValidations 
- Autenticação com JWT 
- Testes Unitários com XUnit e Moq
- Mensageria com RabbitMQ

# Camadas do projeto
- Core: camada que representa as regras de negócio do domínio. 
- Infrastructure: implementação dos recursos necessários para acesso à dados e comunicação com serviços externos. É nesta camada que estão as classes repositórios para acessar os dados dos objetos.
- Application: representa os casos de usos do projeto, é nesta camada que estão presentes os Commands, Queries, Validators e Models.
- API: camada de apresentação do projeto, camada mais externa para a interação com o sistema.
