# Autenticacao-jwt

## OBJETIVO DO PROJETO
Este projeto tem como objetivo a prática do desenvolvimento de um projeto de autenticação, utilizando token JWT Bearer e armazenamento do mesmo em um redis. Com este projeto você cria um usuário informando, um Username, Email, Password e Role que posteriormente será utilizado para autenticação

## TECNOLOGIAS
 - Redis
 - Dapper
 - SqlServer
 - Docker (Para Redis e SqlServer)

## PADRÕES DE PROJETO
 - UnityOfWork
 - CQRS

## COMO EXECUTAR

### Redis
Crie um container utilizando a CLI do Docker, executando o comando:

```bash
docker run -p 6379:6379 --name redis -d redis
```

### SqlServer com Docker

Por motivos didáticos, foi executado um container do SqlServer no docker, para facilitar exclusão, deleção ou qualquer outra manipulação com o banco de dados.
Crie um container utilizando a CLI do Docker, executando o comando:

```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=*SQLestudo2024" -p 14444:1433 --name sql-estudo --hostname sql-estudo -d mcr.microsoft.com/mssql/server:2022-latest
```

### Abra o projeto c