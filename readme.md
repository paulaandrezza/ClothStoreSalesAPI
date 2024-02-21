# Cloth Store Sales API

Esta � uma API RESTful constru�da com ASP.NET para gerenciar vendas em uma loja de roupas.
Este projeto � uma atividade do m�dulo de Programa��o Web II (ASP.NET MVC / WEB AP) do curso Diversedev na Ada tech, com o objetivo de treinar o uso de endpoints, filtros, middlewares, logs e pol�ticas de CORS.

## Sum�rio

- [Recursos](#recursos)
- [Configura��o](#configura��o)
- [Endpoints](#endpoints)
- [Contribui��es](#contribui��es)

## Recursos

- Permite registrar vendas.
- Permite registrar devolu��es ou trocas.
- Fornece endpoints para listar vendas, devolu��es e trocas.
- Suporta busca com par�metros para filtrar vendas, devolu��es e trocas.
- Implementa valida��es para campos relevantes nas solicita��es.
- Filtros para capturar exce��es.
- Middlewares e filtros para fazer log no in�cio e no fim das a��es.
- Aplica diferentes n�veis de logs em locais chave, como o in�cio e o fim da recupera��o de dados, valida��es, etc.
- Inclui uma pol�tica global de CORS para permitir acesso de origens espec�ficas.

## Configura��o

Para configurar e executar o projeto localmente, siga estes passos:

1. Certifique-se de ter o Visual Studio instalado em sua m�quina.
2. Clone o reposit�rio do projeto.
3. Abra o projeto no Visual Studio.
4. Pressione F5 ou clique em "Iniciar" para rodar a aplica��o.
5. Abra o navegador e acesse a URL `https://localhost:5072/swagger` para visualizar a documenta��o da API e testar os endpoints dispon�veis.

## Endpoints

Os seguintes endpoints est�o dispon�veis:

### Item
- `POST /item`: Adiciona um novo item.
- `DELETE /item/{itemId}`: Exclui um item pelo ID.
- `GET /item`: Obt�m todos os itens.
- `GET /item/{itemId}`: Obt�m um item pelo ID.
- `PUT /item/{itemId}`: Atualiza um item pelo ID.

### Sale
- `POST /sale`: Adiciona uma nova venda.
- `GET /sale`: Obt�m todas as vendas.
- `GET /sale/{saleId}`: Obt�m uma venda pelo ID.

### Return
- `POST /return`: Adiciona uma nova devolu��o.
- `GET /return`: Obt�m todas as devolu��es.

### Exchange
- `POST /exchange`: Adiciona uma nova troca.
- `GET /exchange`: Obt�m todas as trocas.

## Contribui��es

Contribui��es s�o bem-vindas! Se voc� deseja contribuir para este projeto, por favor fa�a um fork do reposit�rio e envie um pull request com suas altera��es.
