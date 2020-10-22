# Rodonaves API

Essa projeto tem como objetivo tornar as entidades Cliente, ClienteTelefones, Fornecedor e FornecedorTelegones acessível através de uma api.

### Instalação
Ao clonar o respositório, é necessário baixar todas as dependências do projeto. Em seguida, é necessário executar as Migration para criar o banco de dados e as entidades. Para realizar esse procedimento, execute o comando abaixo no console do gerenciador de pacotes do visual studio:
```sh
Update-Database
```

Para criação desse projeto, foi adotado o MySQL como SGBD. Por tanto, caso não queira utilizá-lo, será necessário instalar os pacotes do SGBD que deseja utilizar, assim como alterar as configurações de acesso a base no arquivo `appsethings.json` e na classe `Startup.cs`, de acordo com o banco a ser utilizado. 

### Utilização
Ao executar a aplicação, será carregada a página de documentação da api (\swagger), a qual trará todos os endpoints disponíveis assim como a possíbilidade de testá-los atráves de sua interface.

### Desenvolvedor
* [rafaelocoelho] - Desenvolvimento de api para teste

License
----

MIT
