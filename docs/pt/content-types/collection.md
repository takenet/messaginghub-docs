### Coleção
| MIME type                            | 
|--------------------------------------|
| application/vnd.lime.collection+json |

Permite o envio de **múltiplos conteúdos** do mesmo tipo em uma única mensagem. Alguns canais suportam este tipo de agregação com layouts especiais (por exemplo, no Facebook Messenger uma coleção de **menu multimídia** é exibido como um *carousel*). Nos demais canais, são enviadas múltiplas mensagens.

É possível enviar conteúdos de tipos diferentes, utilizando uma coleção do tipo **container**.

#### Exemplos
Uma coleção de **texto**
```json
{
	"to": "553199990000@0mn.io",
	"type": "application/vnd.lime.collection+json",
	"content": {
		"itemType": "text/plain",
		"items": [
            "Texto 1",
            "Texto 2",
            "Texto 3"
		]
	}
}
```

Uma coleção de tipos diferentes, utilizando **container**
```json
{
	"to": "553199990000@0mn.io",
	"type": "application/vnd.lime.collection+json",
	"content": {
		"itemType": "application/vnd.lime.container+json",
		"items": [
			{
				"type": "application/vnd.lime.media-link+json",
				"value": {
					"text": "Seja bem-vindo a nossa loja!",
					"type": "image/jpeg",
					"uri": "http://petersapparel.parseapp.com/img/item100-thumb.png"
				}
			},
			{
				"type": "application/vnd.lime.select+json",
				"value": {
					"text": "Escolha o que deseja fazer",
					"options": [
					    {
					        "order": 1,
					        "text": "Ver nosso estoque"
					    },
					    {
					        "order": 2,
					        "text": "Acompanhar um pedido"
					    }
					]
				}
			}			
		]
	}
}

```

Uma coleção de **menu multimídia**
```json
{
    "id": "5",
    "to": "1042221589186385@messenger.gw.msging.net",
    "type": "application/vnd.lime.collection+json",
    "content": {
        "itemType": "application/vnd.lime.document-select+json",
        "items": [
            {
                "header": {
                    "type": "application/vnd.lime.media-link+json",
                    "value": {
                        "title": "Titulo",
                        "text": "Este é o primeiro item",
                        "type": "image/jpeg",
                        "uri": "http://www.isharearena.com/wp-content/uploads/2012/12/wallpaper-281049.jpg"
                    }
                },
                "options": [
                    {
                        "label": {
                            "type": "application/vnd.lime.web-link+json",
                            "value": {
                                "title": "Link",
                                "uri": "https://server.com/first/link1"
                            }
                        }
                    },
                    {
                        "label": {
                            "type": "text/plain",
                            "value": "Texto 1"
                        },
                        "value": {
                            "type": "application/json",
                            "value": {
                                "key1": "value1",
                                "key2": 2
                            }
                        }
                    }
                ]
            },
            {
                "header": {
                    "type": "application/vnd.lime.media-link+json",
                    "value": {
                        "title": "Titulo 2",
                        "text": "Este é outro item",
                        "type": "image/jpeg",
                        "uri": "http://www.freedigitalphotos.net/images/img/homepage/87357.jpg"
                    }
                },
                "options": [
                    {
                        "label": {
                            "type": "application/vnd.lime.web-link+json",
                            "value": {
                                "title": "Segundo link",
                                "text": "Weblink",
                                "uri": "https://server.com/second/link2"
                            }
                        }
                    },
                    {
                        "label": {
                            "type": "text/plain",
                            "value": "Segundo texto"
                        },
                        "value": {
                            "type": "application/json",
                            "value": {
                                "key3": "value3",
                                "key4": 4
                            }
                        }
                    },
                    {
                        "label": {
                            "type": "text/plain",
                            "value": "Mais um texto"
                        },
                        "value": {
                            "type": "application/json",
                            "value": {
                                "key5": "value5",
                                "key6": 6
                            }
                        }
                    }
                ]
            }
        ]
    }
}
```
