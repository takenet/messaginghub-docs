---
layout: page
title: Serviços
---

**Serviços** são *building blocks* para aplicações de mensagem que encapsulam funcionalidades comuns para a construção das mesmas. Eles são como aplicações *especiais* que ao invés de possuirem um identificador simples (*name@msging.net*), possuem um subdomínio no Messaging Hub (*anything@myservice.msging.net*) recebendo todas mensagens, notificações e comandos endereçados ao mesmo.

Os serviços são encontrados no [portal](http://messaginghub.io) onde a documentação de cada um é disponibilizada para consulta. Para utilizar um serviço em uma aplicação, é necessário ativá-lo no portal. Um serviço pode requerer configurações específicas da aplicação, além de permissões para enviar mensagens em nome da mesma. Por exemplo, um serviço ```broadcast``` pode precisar da configuração ```windowSize```, além a permissão de enviar em nome da aplicação.  Tanto as configurações e permissões são fornecidas no momento da ativação no portal. 

Após a ativação, a aplicação pode interagir com o serviço através de mensagens e comandos. A mecânica de funcionamento de cada serviço pode variar e deve estar especificada na documentação do mesmo. Continuando o exemplo anterior, um serviço ```broadcast``` pode suportar comandos para adicionar destinatários em uma lista de distribuição, além de poder receber mensagens endereçadas a ```nome-da-lista@broadcast.msging.net``` e dispará-las para os membros desta lista. 
