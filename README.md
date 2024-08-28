# Aplicação .NET Core 8 com RabbitMQ e MassTransit

Este repositório contém um exemplo de aplicação simples, sem arquitetura nenhuma aplicada, desenvolvida em .NET Core 8, que utiliza RabbitMQ como broker de mensagens e MassTransit.
O projeto demonstra como configurar e usar MassTransit para enviar e receber mensagens através do RabbitMQ, por padrão a exchange utilizada é do tipo fanout.

## Pré-requisitos

Antes de começar, verifique se você tem o seguinte instalado:

- [.NET Core 8 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/get-started) (para RabbitMQ)
- [RabbitMQ](https://www.rabbitmq.com/download.html) (opcional, se não usar Docker)

## Configuração do RabbitMQ

Você pode iniciar o RabbitMQ usando Docker com o seguinte comando:

```bash
docker-compose up -d
