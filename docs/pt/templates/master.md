### Master

O modelo **Master** permite que **múltiplos chatbots sejam encapsulados em um único bot**, sendo que em um dado momento, apenas um deles está ativo para cada cliente. Cada sub-bot é registrado com um **serviço** - por exemplo, *navegação* ou *atendimento* - e o chatbot ativo no momento consegue realizar o transbordo para um outro serviço. Neste caso, **somente o chatbot master precisa ser publicado nos canais externos**, sendo que os bots de serviço (ou *bots filhos*) conversam apenas com o master. Apesar disso, não há restrições de publicações em separado dos bots de serviço.

Este modelo facilita a realização do atendimento de **forma híbrida**, que é algo bastante útil para prover um serviço de qualidade aos clientes de um chatbot. Por exemplo, um chatbot do tipo SDK que utiliza uma navegação estruturada pode decidir em um dado momento que o cliente atual deve receber atendimento de um operador humano. 

As **regras de transição são de responsabilidade do chatbot ativo no momento**, mas o caso mais comum é caso o chatbot não esteja compreendendo as entradas do cliente, ou mesmo o cliente tenha solicitado o atendimento. Neste momento, o chatbot ativo deve enviar uma mensagem com o tipo de conteúdo [**redirecionamento**](https://portal.blip.ai/#/docs/content-types/redirect) informando em `address` o nome do serviço que deverá assumir o controle da conversa a partir deste momento. No caso de chatbots do modelo **atendimento manual**, a transição é realizada através do [**BLiP Web**](https://web.blip.ai), no botão **finalizar atendimento**.

