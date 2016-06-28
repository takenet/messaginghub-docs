# Endereçamento

Toda mensagem e notificação trocadas entre **contatos** e **clientes** no **Omni Messaging Hub** possui **endereços** do *originador* e *destinatário*.

O endereço é apresentado no formato `nome@domínio/instância`, sendo:
- **nome**: Identificador do cliente no canal. O formato do nome varia de acordo com o canal, podendo ser o número de telefone em alguns canais (como SMS) ou identificadores internos de cada plataforma (como no Messenger). Este valor é obrigatório.
- **domínio**: Identificador do canal de origem do cliente. O formato é sempre um [FQDN](https://pt.wikipedia.org/wiki/FQDN), sendo que cada canal possuí um identificador único. Este valor é obrigatório.
- **instância**: Identificador *opcional* da conexão do cliente com o canal. É utilizado em canais que o cliente pode ter mais de uma conexão ativa com o canal (exemplo, no celular e no computador).

Normalmente, a interação de um contato com o cliente começa após o recebimento de uma mensagem, que por sua vez possui um endereço de origem. Neste caso, basta o contato responder a este endereço - de maneira inalterada - para que seja garantida a entrega da mensagem. 

Os endereços podem ter ciclo de vida diferentes dependendo dos canais, podendo ser **transientes** - válidos apenas por um certo tempo (como no *Telegram*, por exemplo), **por escopo** - válidos em certas condições (como no *Messenger*, onde o endereço é válido apenas para um determinado originador) e **persistentes** - sempre válidos (no *SMS* e *Omni*). Os contatos devem levar estas características em consideração ao construir as interações.

Para maiores detalhes, consulte a especificação do [protocolo LIME](http://limeprotocol.org/index.html#concepts).
