### Instalação

Se você estiver usando `node.js` (ou `webpack`), é necessário apenas instalar o pacote `messaginghub-client` pelo `npm`.

    npm install --save messaginghub-client

Mas caso esteja construindo uma aplicação web (no browser) e esteja utilizando Javascript "puro", é possível instalar pacote pelo `npm` e incluir o *script* com a tag `<script>`. Para utilizar o pacote  `messaginghub-client` desta forma, é necessário que seja também seja instalado e referenciado o pacote `lime-js`, além do pacote do transporte `lime-websocket-transport`:

```html
<script src="./node_modules/lime-js/dist/lime.js" type="text/javascript"></script>
<script src="./node_modules/lime-transport-websocket/dist/WebSocketTransport.js" type="text/javascript"></script>
<script src="./node_modules/messaginghub-client/dist/messaginghub-client.js" type="text/javascript"></script>
```

Você também pode utilizar as distribuições disponibilizadas pelo [npmcdn](https://npmcdn.com), caso não esteja utilizando o `npm` para desenvolvimento:
```html
<script src="https://npmcdn.com/lime-js" type="text/javascript"></script>
<script src="https://npmcdn.com/lime-transport-websocket" type="text/javascript"></script>
<script src="https://npmcdn.com/messaginghub-client" type="text/javascript"></script>
```
Você precisará de um identificador e uma chave de acesso para sua aplicação, para poder interagir com o Messaging Hub. Para obtê-los, faça o seguinte:
- Acesse o [Painel Omni](http://omni.messaginghub.io/portal).
- Na aba `Contatos` clique em `Criar Contato`.
- Preencha com os parâmetros requeridos e na próxima etapa escolha a opção `Chat Bot (SDK)`
- Pronto, seu contato foi criado e o identificador e chave de acesso serão exibidos.

