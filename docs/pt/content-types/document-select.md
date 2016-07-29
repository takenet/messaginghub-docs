### Menu multimídia
| MIME type                            | 
|--------------------------------------|
| application/vnd.lime.document-select+json |

Permite o envio de um menu de opções aos clientes, podendo o cabeçalho e as opções serem, além de **texto**, outros tipos de conteúdo como **link de mídia** ou **link web**. Para cada opção, é possível definir um documento que é entregue ao contato quando o cliente realiza uma escolha (depende de suporte do canal).

####Exemplos

Menu com imagem no cabeçalho e um link e texto como opções
```json
{
    "id":"3",
    "to":"5531999900000@0mn.io",
    "type":"application/vnd.lime.document-select+json",
    "content":{
        "header":{
            "type":"application/vnd.lime.media-link+json",
            "value":{
                "title":"Seja bem-vindo ao Chapeleiro Maluco",
                "text":"Aqui temos o melhor chapéu para sua cabeça.",
                "type":"image/jpeg",
                "uri":"http://petersapparel.parseapp.com/img/item100-thumb.png"
            }
        },
        "options":[
            {
                "label":{
                    "type":"application/vnd.lime.web-link+json",
                    "value":{
                        "text":"Visitar site",
                        "uri":"https://petersapparel.parseapp.com/view_item?item_id=100"
                    }
                }
            },
            {
                "label":{
                    "type":"text/plain",
                    "value":"Ver estoque"
                },
                "value":{
                    "type":"application/json",
                    "value":{
                        "action":"show-items"
                    }
                }
            }
        ]
    }
}
```

Para mais detalhes, consulte a especificação do [protocolo LIME](http://limeprotocol.org/content-types.html#document-select).
