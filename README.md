# crud-basico-dapper
Repositório para prática dos primeiros passos com docker e API. O objetivo não é aplicar as melhores práticas e padrões para o desenvolvimento desse mini projeto, e sim entender como funciona o uso de containers que se comunicam entre si. Tanto é que muitos tratamentos não foram feitos (por exemplo não rodar dois serviços de banco de dados sendo que apenas um é usado), e também existem formas de melhor organização do projeto para poder escalar o mesmo, mas, como dito, esse projeto é para dar os primeiros passos com Docker e com API.

Também não foi possível rodar o script inicial do banco de dados direto da imagem, ou seja, para rodar a aplicação em outra máquina, é preciso ter uma pasta `./Database/init.sql` no mesmo local em que estiver o `arquivo docker-compose.yaml`.

## v1.0

Persistência de dados usando Postgres.

## v2.0

Persistência de dados usando MySql.

### http://localhost:5000/listarProdutos (GET)

### http://localhost:5000/listarProduto/{id} (GET)

### http://localhost:5000/cadastrarProduto (POST)

<code>{
    "nome": "Produto",
    "valorun": 9.90,
    "qtde": 2
}</code>

### http://localhost:5000/atualizarProduto (PUT)

<code>{
    "id" : 1,
    "nome": "Doce de pão doce",
    "valorun": 8.90,
    "qtde": 10
}</code>

### http://localhost:5000/removerProduto/{id} (DELETE)
