### Diretório
| Endereço                        | URI base     | Permissões requeridas   | C#                     |
|---------------------------------|--------------|-------------------------|------------------------|
| postmaster@<FQDN do canal> | `lime://<FQDN do canal>/accounts/<Identificador do cliente>`       | Nenhuma      | [DirectoryExtension](https://github.com/takenet/messaginghub-client-csharp/blob/master/src/Takenet.MessagingHub.Client/Extensions/Broadcast/DirectoryExtension.cs) |

A extensão **diretório** permite consultar informações da conta dos clientes conectados aos canais, como nome e outras informações pessoais. O comando deve ser enviado diretamente ao `postmaster` do canal, utilizando uma **URI** especial. 

> Esta funcionalidade depende do suporte pelo canal

#### Exemplos

1 - Obtendo informações do cliente `1042221589186385@messenger.gw.msging.net` no **Messenger**
```json
{  
  "id": "1",
  "to": "postmaster@messenger.gw.msging.net",
  "method": "get",
  "uri": "lime://messenger.gw.msging.net/accounts/1042221589186385"
}
```
Resposta em caso de sucesso:
```json
{
  "id": "1",
  "from": "postmaster@messenger.gw.msging.net/#hmgirismsging1",
  "to": "contact@msging.net/default",
  "type": "application/vnd.lime.account+json",
  "method": "get",
  "status": "success",
  "resource": {
    "fullName": "Astraugésilo de Athaíde",
    "photoUri": "https://fbcdn-profile-a.akamaihd.net/hprofile-ak-xtf1/v/t1.0-1/p200x200/14429_1013121325123122924983_n.jpg"
  }
}
```
