# Teste-Web-CSharp

<!-- PROJECT LOGO -->
<br />
<p align="center">

  <h3 align="center">Teste-Web-CSharp1</h3>

  <p align="center">
    <br />
    <a href="https://github.com/gsoares2011/Teste-Web-CSharp/tree/main/Teste-Web-CSharp1"><strong>Explore os arquivos »</strong></a>
  </p>
</p>



<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary>Tabela de Conteúdos</summary>
  <ol>
    <li><a href="#status">Status</a></li>
    <li>
      <a href="#sobre">Sobre</a>
      <ul>
        <li><a href="#tecnologias">Tecnologias</a></li>
      </ul>
    </li>
    <li>
      <a href="#primeiros-passos">Primeiros Passos</a>
      <ul>
        <li><a href="#pre-requisitos">Pré-requisitos</a></li>
        <li><a href="#instalacao">Instalação</a></li>
      </ul>
    </li>
    <li><a href="#license">License</a></li>
    <li><a href="#contato">Contato</a></li>
  </ol>
</details>

<!-- Status -->
## Status

<h4 align="center"> 
	  Projeto Concluído 
</h4>

<!-- ABOUT THE PROJECT -->
## Sobre

Uma aplicação capaz de cadastrar pontos turísticos, por localização, no Brasil e listá-los de forma paginada. Também conta com um filtro para que fique mais fácil a caça de informações nos registros de dados.

O projeto contém os seguintes recursos:
* Cadastro simples e rápido, contado com API do IBGE para preencher os selects.
* Listagem paginada responsiva e adaptável, desenvolvida com o auxílio do plugin jQuery Table-Sortable.
* Busca completa por qualquer dado na tabela de registros. Também desenvolvida utulizando o plugin jQuery Table-Sortable.
* Opção de detalhar melhor o registro escolhido, montrando Nome, Descrição, Endereço ou Referência, Cidade e Estado.


### Tecnologias

* [Bootstrap](https://getbootstrap.com)
* [JQuery](https://jquery.com)
* [JQuery Table-Sortable](https://www.jqueryscript.net/table/Paginate-Sort-Filter-Table-Sortable.html)
* [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet/3.1)
* [SQL Server 2019](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)



<!-- GETTING STARTED -->
## Primeiros Passos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:

### Pré-requisitos

* [Git](https://git-scm.com)
* [Visual Studio](https://visualstudio.microsoft.com/pt-br/)
* [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

### Instalação

```bash
# Clone este repositório
$ git clone <https://github.com/gsoares2011/Teste-Web-CSharp.git>

# Acesse a pasta do projeto no Explorer/Finder do seu computador
Utilize a opção do GitApp ou vá até o local onde foi feita a clonagem do repositório.

# Execute o arquivo de solução do Visual Studio
Execute o arquivo com o nome "Teste-Web-CSharp1.sln".

# Crie as tabelas no banco de dados
Criar as tabelas no SQL Server de acordo com os comandos dentro do arquivo "Teste-Web-CSharp1/Database/SQL Server - Tables.sql".

# Ajustar a string de conexão com o banco de dados
Dentro da solução de Visual Studio seguir o seguinte caminho:

"Teste-Web-CSharp1/Database/ConnectSQLServer.cs"

Uma vez dentro da classe, atualizar a string de conexão para a correspondente de acordo com o seu banco de dados no SQL Server.

Salvar as alterações.

# Execute o programa com o ISS Express dentro do Visual Studio
Rode o programa dentro do Visual Studio, selecione a opção do ISS Express

# O servidor inciará na porta:44336
````

<!-- LICENSE -->
## License

Este projeto esta sobe a licença MIT.



<!-- CONTACT -->
## Contato

Gustavo Soares - gsoares2011@live.com

Project Link: [Teste-Web-CSharp](https://github.com/gsoares2011/Teste-Web-CSharp.git)
