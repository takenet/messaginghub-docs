### Diretório
| Endereço                        | URI base     | Permissões requeridas   | C#                     |
|---------------------------------|--------------|-------------------------|------------------------|
| postmaster@<FQDN do canal> | `lime://<FQDN do canal>/accounts/<Identificador do cliente>`       | Nenhuma      | [DirectoryExtension](https://github.com/takenet/messaginghub-client-csharp/blob/master/src/Takenet.MessagingHub.Client/Extensions/Broadcast/DirectoryExtension.cs) |

A extensão **diretório** permite consultar informações da conta dos clientes conectados aos canais, como nome e outras informações pessoais. O comando deve ser enviado diretamente ao `postmaster` do canal, utilizando uma **URI** especial.

> Esta funcionalidade depende do suporte no canal

