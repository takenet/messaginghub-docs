### Hospedagem

Quando o chatbot é criado via SDK, a hospedagem fica a cargo do usuário. O ambiente que a aplicação fica hospedado precisa de acesso à internet para que a conexão com o servidor seja estabelecida.

Uma conexão *TCP* é estabelecida na porta 443 do servidor do BLiP. Esta conexão irá servir como camada de transporte do protocolo [Lime](http://limeprotocol.org/), que é o protocolo utilizado para comunicação.

#### Implantação

Com o .NET Core, existem duas opções de implantação dos binários de sua aplicação:

- Dependende de estrutura: Neste modo, é necessário que o SDK do .NET Core (e suas dependências) esteja instalado no servidor de destino. Os binários gerados são portáveis.
- Autocontida: Neste modo, gera-se os binários nativos do sistema operacional e são inclusas todas as dependências, inclusive o runtime. 

Para maiores informações, consulte a documentação do [.NET Core](https://docs.microsoft.com/pt-br/dotnet/core/deploying/).

#### Hospedando como um serviço Windows

Os chatbots criados através do template `blip-console` podem ser instalados como serviços Windows, caso esteja sendo executado neste sistema operacional.Isso permite que o mesmo continue sua execução em um servidor sem a necessidade de uma sessão de usuário conectada a máquina.

Para isso, basta executar o seguinte comando:
```
mhh.exe install -serviceName NomeDoServico
```

O serviço criado pode ser iniciado através do utilitário `services.msc` do Windows ou através do comando `sc`, como abaixo:
```
sc start NomeDoServico
```

Para remover o serviço, utilize o comando abaixo:
```
mhh.exe uninstall -serviceName NomeDoServico
```
