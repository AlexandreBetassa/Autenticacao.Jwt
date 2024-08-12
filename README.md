# Autenticacao JWT

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

Você precisará também possuir o Sql Server Management Studio, ou outro gerenciados de banco de dados, para execução do script de criação do banco de dados e da tabela.
No seu gerenciador de sua preferencia, execute o script de banco de dados, localizado na pasta "scripts" presente no repositório.

ESTE PASSO É ESSENCIAL, CASO CONTRÁRIO, NÃO CONSEGUIRÁ CADASTRAR UM USUÁRIO

### Execução do projeto
Este projeto já possui seu Dockerfile, caso deseje executá-lo em um container. Porém poderá somente abrir o VisualStudio e executar o projeto normalmente pela ferramenta. 
Caso opte, por executá-lo em um container Docker, acesse a pasta onde o arquivo Dockerfile se encontra e execute o seguinte comando para criar a imagem:

```bash
docker build . -t <seu_repositorio_docker>/<nome_projeto>:<versao_projeto>
```

Faça o push para seu repositório com o comando:

```bash
docker push <seu_repositorio_docker>/<nome_projeto>:<versao_projeto>
```

Em seguida:
```bash
docker run -p 8000:80 -n <nome_do_container> -d <seu_repositorio_docker>/<nome_projeto>:<versao_projeto>
```

Você poderá acessar o swagger, abrindo seu navegador e inserindo o endereço:

```bash
127.0.0.1:8000/swagger/index.html