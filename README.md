# Plataforma de Colaboração entre Projetos Sociais e Colaboradores

Bem-vindo ao repositório da Plataforma de Colaboração entre profissionais e projetos sociais. Este projeto visa criar uma plataforma online que conecta instituições públicas e seus projetos sociais com colaboradores em potencial.

## Tecnologias Utilizadas

### Frontend
- **Vue.js**: O framework JavaScript para construção do frontend.
- **Tailwind CSS**: Tailwind CSS é uma estrutura CSS de código aberto.

### Backend
  - **.NET 6.0:** Certifique-se de ter o ambiente de desenvolvimento .NET 6 instalado. Você pode baixá-lo em [dotnet.microsoft.com](https://dotnet.microsoft.com/download/dotnet/6.0).
 - **SQL Server:** A aplicação requer um banco de dados SQL Server para armazenar informações de projetos, usuários e colaborações. Certifique-se de configurar uma conexão válida no arquivo de configuração.

## Funcionalidades Principais

- **Exploração, Filtragem e Pesquisa de Projetos Sociais**: Nossos usuários podem facilmente explorar, filtrar e buscar projetos sociais, personalizando sua busca com tags que correspondam aos seus interesses.
<img src="./docs/feed.png">

- **Cadastro de Colaboradores** [Em desenvolvimento]: Os colaboradores podem criar perfis pessoais, onde e possivel listar suas habilidades e interesses. Isso possibilita a correspondência precisa de projetos com as preferências de cada colaborador.
<img src="./docs/interests.png">

<!-- 
- **Cadastro de Instituições Públicas**: As instituições públicas podem se registrar na plataforma, criando perfis e adicionando informações sobre suas demandas de projetos.

- **Solicitações de Colaboração**: As instituições públicas podem criar demandas de projeto e os desenvolvedores podem solicitar colaboração em projetos que correspondam às suas habilidades.

- **Aceitação de Colaborações**: As instituições públicas podem aceitar ou recusar solicitações de colaboração de desenvolvedores interessados em seus projetos.

- **Mensagens e Comunicação**: A plataforma permite a comunicação entre instituições públicas e desenvolvedores por meio de mensagens internas. -->


## Configuração do Ambiente de Desenvolvimento

Para configurar o ambiente de desenvolvimento e executar o projeto localmente, siga estas etapas:

1. Clone este repositório:

```bash
git clone https://github.com/seu-usuario/Breadcrumbsopen-science-projects-ui.git
```

2. Navegue até o diretório do projeto:
```bash
cd open-science-projects-ui
```

3. Instalar dependencias
```bash
npm install
```

4. Iniciar servidor
```bash
npm run dev
```

# Open Science Project - API .NET 6

A Plataforma de Colaboração de Projetos - API .NET 6 é a parte da aplicação que lida com a lógica de backend e a interação com o banco de dados. 
Ela fornece uma interface para que o frontend da aplicação se comunique e gerencie dados relacionados a instituições públicas, profissionais e projetos.

## Pré-Requisitos

- **.NET 6.0:** Certifique-se de ter o ambiente de desenvolvimento .NET 6 instalado. Você pode baixá-lo em [dotnet.microsoft.com](https://dotnet.microsoft.com/download/dotnet/6.0).

- **SQL Server:** A aplicação requer um banco de dados SQL Server para armazenar informações de projetos, usuários e colaborações. Certifique-se de configurar uma conexão válida no arquivo de configuração.

## Configuração e Instalação

1. Clone este repositório em sua máquina local:

```bash 
git clone 
``` 

2. Navegue até o diretório raiz do projeto:

```bash 
cd open-science-projects-api
``` 

3. Configure o banco de dados SQL Server editando a string de conexão no arquivo `appsettings.json`.

4. Execute as migrações do banco de dados para criar as tabelas necessárias:
```bash 
dotnet ef database update
``` 

5. Inicie a API:
```bash 
dotnet run
``` 

A API estará disponível em `http://localhost:6001`.

## License

### MIT License
