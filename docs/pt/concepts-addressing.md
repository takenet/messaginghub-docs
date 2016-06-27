# Endereçamento

Toda mensagem e notificação trocadas entre **contatos** e **clientes** no **Omni Messaging Hub** possui **endereços** do *originador* e *destinatário*.

O endereço é apresentado no formato `nome@domínio/instância`, sendo:
- **nome**: Identificador do cliente no canal. O formato do nome varia de acordo com o canal, podendo ser o número de telefone em alguns canais (como SMS) ou identificadores internos de cada plataforma (como no Messenger). Este valor é obrigatório.
- **domínio**: Identificador do canal de origem do cliente. O formato é sempre um [FQDN](https://pt.wikipedia.org/wiki/FQDN), sendo que cada canal possuí um identificador único. Este valor está sempre presente no endereço. Este valor é obrigatório.
- **instância**: Identificador opcional da conexão do cliente com o canal. É utilizado em canais que o cliente pode ter mais de uma conexão ativa com o canal (exemplo, no celular e no computador).
