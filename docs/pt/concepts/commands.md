### Comandos

Um **comando** permite a consulta e manipulação de recursos do servidor e de extensões do **Omni Messaging Hub**. Provê uma interface pedido-resposta, semelhante ao HTTP, com verbos e URIs.

Cada comando possui:
- **id**: Identificador único do comando. O *id* é utilizado como referência nas respostas dos comandos. Este valor é obrigatório, exceto para comandos do método `observe`.
- **from**: Endereço do originador do comando. Este valor pode ser omitido nas requisições, sendo que por padrão é considerado o endereço do contato conectado.
- **to**: Endereço do destinatário do comando. Este valor pode ser omitido nas requisições, sendo que por padrão é considerado o endereço remoto (do servidor). Deve ser fornecido caso o comando seja enviado a uma **extensão**.
- **uri**: O caminho no destinatário do recurso que o comando se refere. Este valor é obrigatório nas requisições e pode ser omitido nas respostas. 
- **method** - Método para manipulação do recurso definido na **uri**. Este valor é obrigatório. Os valores possíveis são:
  * **get** - Obtém um valor existente.
  * **set** - Cria ou atualiza um valor.
  * **delete** - Remove um valor existente.
  * **subscribe** - Assina um recurso para recebimento de notificações de mudança do valor definido na **uri**.
  * **unsubscribe** - Remove uma assinatura de um recurso.
  * **observe** - Notifica sobre mudanças no valor de um recurso, normalmente emitidos pelo servidor ou uma extensão. Comandos com este método são emitidos são unidirecionais e o destinatário não deve enviar uma resposta aos mesmos. Por este motivo, não possuem **id**.

