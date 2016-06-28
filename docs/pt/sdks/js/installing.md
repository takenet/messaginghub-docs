### Instalação

Se você estiver usando `node.js` (ou `webpack`), é necessário apenas instalar o pacote `messaginghub-client` do registro do `npm`.

    npm install --save messaginghub-client

Mas caso esteja construindo uma aplicação web (no browser) e esteja utilizando Javascript "puro", você pode instalar o pacote pelo `npm` e depois incluir o *script* com a tag `<script>`.
Lembrando que para utilizar o pacote  `messaginghub-client` desta forma, é necessário que seja também seja instalado e referenciado o pacote `lime-js`, além do pacote do transporte `lime-websocket-transport`:

```html
<script src="./node_modules/lime-js/dist/lime.js" type="text/javascript"></script>
<script src="./node_modules/lime-transport-websocket/dist/WebSocketTransport.js" type="text/javascript"></script>
<script src="./node_modules/messaginghub-client/dist/messaginghub-client.js" type="text/javascript"></script>
```

Você também pode utilizar o script disponibilizado pelo [npmcdn](https://npmcdn.com):
```html
<script src="https://npmcdn.com/lime-js" type="text/javascript"></script>
<script src="https://npmcdn.com/lime-transport-websocket" type="text/javascript"></script>
<script src="https://npmcdn.com/messaginghub-client" type="text/javascript"></script>
```
