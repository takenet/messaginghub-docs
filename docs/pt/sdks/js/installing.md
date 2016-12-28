### Instalação

#### Node.js

Se você estiver usando `node.js` (ou `webpack`), é necessário instalar o pacote `messaginghub-client` que disponibiliza o cliente do MessagingHub e algum transporte (conexão) pelo `npm`.

    npm install --save messaginghub-client lime-websocket-transport

#### Browser

Caso esteja construindo uma aplicação web (no browser) e esteja utilizando Javascript "puro", é possível instalar pacote pelo `npm` e incluir o *script* com a tag `<script>`. Para utilizar o pacote  `messaginghub-client` desta forma, é necessário que seja também seja instalado e referenciado o pacote `lime-js`, além do pacote do transporte `lime-websocket-transport`:

```html
<script src="./node_modules/lime-js/dist/lime.js" type="text/javascript"></script>
<script src="./node_modules/lime-transport-websocket/dist/WebSocketTransport.js" type="text/javascript"></script>
<script src="./node_modules/messaginghub-client/dist/messaginghub-client.js" type="text/javascript"></script>
```

Você também pode utilizar as distribuições disponibilizadas pelo [unpkg](https://unpkg.com), caso não esteja utilizando o `npm` para desenvolvimento:
```html
<script src="https://unpkg.com/lime-js" type="text/javascript"></script>
<script src="https://unpkg.com/lime-transport-websocket" type="text/javascript"></script>
<script src="https://unpkg.com/messaginghub-client" type="text/javascript"></script>
```
Você precisará de um identificador e uma chave de acesso para sua aplicação, para realizar a conexão com o servidor do BLiP. Para obtê-los:
- Acesse o [Painel BLiP](http://omni.messaginghub.io/portal).
- Na aba `Chatbots` clique em `Criar chatbot`.
- Preencha com os parâmetros requeridos e na próxima etapa escolha a opção `SDK`
- Pronto, seu chatbot foi criado e o identificador e chave de acesso serão exibidos.
