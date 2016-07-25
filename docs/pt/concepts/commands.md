### Comandos

Um **comando** permite a consulta e manipulação de recursos do servidor e de extensões do **Omni Messaging Hub**. 

Cada comando possui:
- **id**: Identificador único do comando. O *id* é utilizado como referência nas respostas dos comandos. Este valor é obrigatório, exceto para comandos do método `observe`.
- **from**: Endereço do originador do comando. Este valor pode ser omitido nas requisições, sendo que por padrão é considerado o endereço do contato conectado.
- **to**: Endereço do destinatário do comando. Este valor pode ser omitido nas requisições, sendo que por padrão é considerado o endereço remoto (do servidor). Deve ser fornecido caso o comando seja enviado a uma **extensão**.

- **content**: Conteúdo da mensagem.
