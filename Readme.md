# Arquitetura de Software Distribu�do - PUC MINAS - POC

### Sistema Integrado de Gest�o e Opera��o

Reposit�rio com c�digo front-end e back-end da aplica��o desenvolvida para o trabalho de conclus�o do curso de Arquitetura de Software Distribu�do da PUC Minas.

#### Front-End

- Angular
- Bootstrap

#### Back-End

- .NET Core
- Ocelot
- AutoMapper
- Entity Framework

## Estrutura de pastas

- NormasClient - Aplica��o front-end desenvolvida em Angular e Bootstrap.
- Seguranca.WebAPI - API respons�vel pela autentica��o e autoriza��o do usu�rio.
- Normas.WebAPI - API de normas.
- ApiGateway - Gateway Ocelot que realiza o roteamento das requisi��es.
- NormasExternas.API - API de normas simulando uma base externa.
- Monitoramento.Worker - WebService de monitoramento de atualiza��es de normas externas.

## Execu��o e acesso � aplica��o

Para executar a aplica��o pode ser utilizado comandos docker-compose para subir os m�dulos de autentica��o e normas. Para a aplica��o de normas, m�dulo de normas externas e para o worker de atualiza��o de normas, pode ser gerada a imagem atrav�s dos dockefiles e execut�-las.

Para acessar a aplica��o de normas utilizar usu�rio e senha: analistaqa