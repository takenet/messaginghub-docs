### Link de mídia
| MIME type                            | 
|--------------------------------------|
| application/vnd.lime.media-link+json |

Permite o envio e recebimento de links para conteúdos multimídia. O link pode ser qualquer **URI** válida, mas a maioria dos canais suportam apenas conteúdos servidos pelo protocolo **HTTP/HTTPS**. É possível incluir um título e um texto, além de *metadados* da imagem como MIME type, tamanho e *preview*.

> Nota: O suporte a metadados varia por canal podendo ser ignorados se não suportado

#### Exemplos
Enviando o link de uma imagem incluindo título, texto descritivo e metadados:

```json
{
    "id": "1",
    "to": "553199991111@0mn.io",
    "type": "application/vnd.lime.media-link+json",
    "content": {
        "title": "Gato",
        "text": "Segue uma imagem de um gato",
        "type": "image/jpeg",
        "uri": "http://2.bp.blogspot.com/-pATX0YgNSFs/VP-82AQKcuI/AAAAAAAALSU/Vet9e7Qsjjw/s1600/Cat-hd-wallpapers.jpg",
        "size": 227791,
        "previewUri": "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcS8qkelB28RstsNxLi7gbrwCLsBVmobPjb5IrwKJSuqSnGX4IzX",
        "previewType": "image/jpeg"
    }
}
```

Enviando o link de um audio:

```json
{
    "id": "1",
    "to": "553199991111@0mn.io",
    "type": "application/vnd.lime.media-link+json",
    "content": {
        "type": "audio/mp3",
        "uri": "http://soundbible.com/grab.php?id=1954&type=mp3"
    }
}
```

Para mais detalhes, consulte a especificação do [protocolo LIME](http://limeprotocol.org/content-types.html#media-link).
