# Arquitetura de Software Distribuído - PUC MINAS - POC

### Sistema Integrado de Gestão e Operação

Repositório com código front-end e back-end da aplicação desenvolvida para o trabalho de conclusão do curso de Arquitetura de Software Distribuído da PUC Minas.

#### Front-End

- Angular
- Bootstrap

#### Back-End

- .NET Core
- Ocelot
- AutoMapper
- Entity Framework

## Estrutura de pastas

- NormasClient - Aplicação front-end desenvolvida em Angular e Bootstrap.
- Seguranca.WebAPI - API responsável pela autenticação e autorização do usuário.
- Normas.WebAPI - API de normas.
- ApiGateway - Gateway Ocelot que realiza o roteamento das requisições.
- NormasExternas.API - API de normas simulando uma base externa.
- Monitoramento.Worker - WebService de monitoramento de atualizações de normas externas.

## Execução e acesso à aplicação

Para executar a aplicação pode ser utilizado comandos docker-compose para subir os módulos de autenticação e normas. Para a aplicação de normas, módulo de normas externas e para o worker de atualização de normas, pode ser gerada a imagem através dos dockefiles e executá-las.

Para acessar a aplicação de normas utilizar usuário e senha: analistaqa