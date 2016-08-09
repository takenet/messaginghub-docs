### Menu
| MIME type                                 | C#                                        |
|-------------------------------------------|-------------------------------------------|
| application/vnd.lime.select+json | [Lime.Messaging.Contents.Select](https://github.com/takenet/lime-csharp/blob/master/src/Lime.Messaging/Contents/Select.cs) |

Permite o envio de um menu de opções aos clientes para a realização de uma escolha. O cabeçalho e as opções são do tipo texto, sendo possível definir um documento que deve ser entregue ao contato quando o cliente realiza uma escolha (depende de suporte do canal). As opções podem opcionalmente serem numeradas.

Alguns canais suportam a limitação do escopo das opções, que determina por quanto tempo as mesmas são válidas para seleção por parte do usuário. Por exemplo, em alguns casos as opções enviadas só podem ser selecionadas pelo cliente naquele momento e devem desaparecer após a escolha. Neste caso, o escopo é **imediato**. Em outros, as opções são válidas para seleção em qualquer momento, sendo o escopo **persistente**.

Para mais detalhes, consulte a especificação do [protocolo LIME](http://limeprotocol.org/content-types.html#select).
