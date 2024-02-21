# Cloth Store Sales API

Esta é uma API RESTful construída com ASP.NET para gerenciar vendas em uma loja de roupas.
Este projeto é uma atividade do módulo de Programação Web II (ASP.NET MVC / WEB AP) do curso Diversedev na Ada tech, com o objetivo de treinar o uso de endpoints, filtros, middlewares, logs e políticas de CORS.

## Sumário

- [Recursos](#recursos)
- [Configuração](#configuração)
- [Endpoints](#endpoints)
- [Contribuições](#contribuições)

## Recursos

- Permite registrar vendas.
- Permite registrar devoluções ou trocas.
- Fornece endpoints para listar vendas, devoluções e trocas.
- Suporta busca com parâmetros para filtrar vendas, devoluções e trocas.
- Implementa validações para campos relevantes nas solicitações.
- Filtros para capturar exceções.
- Middlewares e filtros para fazer log no início e no fim das ações.
- Aplica diferentes níveis de logs em locais chave, como o início e o fim da recuperação de dados, validações, etc.
- Inclui uma política global de CORS para permitir acesso de origens específicas.

## Configuração

Para configurar e executar o projeto localmente, siga estes passos:

1. Certifique-se de ter o Visual Studio instalado em sua máquina.
2. Clone o repositório do projeto.
3. Abra o projeto no Visual Studio.
4. Pressione F5 ou clique em "Iniciar" para rodar a aplicação.
5. Abra o navegador e acesse a URL `https://localhost:5072/swagger` para visualizar a documentação da API e testar os endpoints disponíveis.

## Endpoints

Os seguintes endpoints estão disponíveis:

### Item
- `POST /item`: Adiciona um novo item.
- `DELETE /item/{itemId}`: Exclui um item pelo ID.
- `GET /item`: Obtém todos os itens.
- `GET /item/{itemId}`: Obtém um item pelo ID.
- `PUT /item/{itemId}`: Atualiza um item pelo ID.

### Sale
- `POST /sale`: Adiciona uma nova venda.
- `GET /sale`: Obtém todas as vendas.
- `GET /sale/{saleId}`: Obtém uma venda pelo ID.

### Return
- `POST /return`: Adiciona uma nova devolução.
- `GET /return`: Obtém todas as devoluções.

### Exchange
- `POST /exchange`: Adiciona uma nova troca.
- `GET /exchange`: Obtém todas as trocas.

## Contribuições

Contribuições são bem-vindas! Se você deseja contribuir para este projeto, por favor faça um fork do repositório e envie um pull request com suas alterações.
