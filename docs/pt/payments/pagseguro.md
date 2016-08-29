### PagSeguro
| FQDN                     | Tipo de identificador                                         | 
|--------------------------|---------------------------------------------------------------|
| @pagseguro.gw.msging.net | Identidade ([nome e domínio](./#/docs/concepts/addressing))   | 

O canal **PagSeguro** é o canal de pagamentos do [UOL](https://pagseguro.uol.com.br/) para receber e enviar pagamentos com flexibilidade e segurança.

#### Delegação
Para dar as permissões requeridas pela extensão, é necessário enviar um comando de delegação:

```json
{  
  "id": "5",
  "method": "set",
  "type": "application/vnd.lime.delegation+json",
  "uri": "/delegations",
  "resource": {  
    "target": "postmaster@pagseguro.gw.msging.net",
    "envelopeTypes": [  
      "message"
    ]
  }
}
```
Resposta em caso de sucesso:

```json
{
  "id": "5",
  "from": "postmaster@msging.net/#irismsging1",
  "to": "contact@msging.net/default",
  "method": "set",
  "status": "success"
}
```

#### Exemplo

Enviando uma solicitação de pagamento para um usuário do Facebook Messenger usando o [PagSeguro](./#/docs/payments/pagseguro):

```json
{
    "id": "1",
    "to": "1042221589186385%40messenger.gw.msging.net@pagseguro.gw.msging.net",
    "type": "application/vnd.lime.invoice+json",
    "content": {
        "created": "2016-08-26T19:03:37.024Z",
        "dueTo": "2016-08-27T19:03:37.024Z",
        "currency": "BLR",
        "total": 10.85,
        "items": [{
                "quantity": 1.0,
                "unit": 0.01,
                "currency": "BRL",
                "total" :10.85,
                "description": "Item 1"
            }
        ]
    }
}
```

Será gerada uma transação no PagSeguro que será enviada para o usuário `1042221589186385@messenger.gw.msging.net` como um [link web](./#/docs/content-types/web-link), o identificador da mensagem será o mesmo da solicitação de pagamento.

```json
{
    "id": "1",
    "to": "1042221589186385@messenger.gw.msging.net",
    "pp": "postmaster@pagseguro.gw.msging.net",
    "type": "application/vnd.lime.web-link+json",
    "content": { 
        "uri": "https://pagseguro.uol.com.br/pagamento",
        "text": "Segue link do pagamento"
    }
}
```

Quando usuário efetuar o pagamento será enviada uma mensagem do tipo [status do pagamento](./#/docs/content-types/invoice-status), o identificador da mensagem será o mesmo da solicitação de pagamento.

```json
{
    "id": "1",
    "from": "1042221589186385%40messenger.gw.msging.net@pagseguro.gw.msging.net",
    "pp": "postmaster@pagseguro.gw.msging.net",
    "type": "application/vnd.lime.invoice-status+json",
    "content": {
        "status": "completed",
        "date": "2016-08-26T19:31:31.000Z",
        "code": "215BF6B5-01EF-4F9A-A944-0BC05FD0F228"
    }
}
```

Opcionalmente pode ser enviado um [recibo de pagamento](./#/docs/content-types/payment-receipt) 

```json
{
    "id": "1",
    "to": "1042221589186385@messenger.gw.msging.net",
    "type": "application/vnd.lime.payment-receipt+json",
    "content": {
        "paidOn": "2016-08-26T19:03:37.024Z",
        "code": "215BF6B5-01EF-4F9A-A944-0BC05FD0F228",
        "currency": "BLR",
        "total": 10.85,
        "items": [{
                "quantity": 1.0,
                "unit": 0.01,
                "currency": "BRL",
                "total": 10.85,
                "description": "Item 1"
            }
        ]
    }
}
```