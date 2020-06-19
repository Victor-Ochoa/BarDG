# BarDG

## Projetos criados:

* #### BarDG.Api
Projeto com a api em .Net Core 3.1

* #### BarDG.Domain
Projeto com o domínio do negócio.

* #### BarDG.Infra
Projeto com a injeção de dependência, nele todos os projetos são referenciados e são feitas as devidas injeções.

* #### BarDG.Repository
Projeto com repositorio e a implementação da classe básica de acesso.

* #### BarDG.Service
Projeto com os handles para o mediador e as lógicas do negócio das agregações que não estão no domínio.

* #### BarDG.Web
Projeto com a Pagina Web, usando Bazor Server

## Design Patterns

#### Mediador
- Pattern usado para isolar a logica do negocio e promover o fraco acoplamento.

#### Repositório
- Abstração do repositório facilitando o acesso as informações usando uma base genérica do acesso a dado.

## Decisões

- Utilizei a mesma solução para ambos os projetos para usar os mesmos objetos do domínio.
- Logica se encontra no domínio e estão testadas no projeto de teste de mesmo nome.
- Optei por utilizar o blazor pois não possuo um foco no frontend e foi mais rápido e tranquilo desenvolver o front.
- Utilizei o SQLite, mesmo com as dificuldades ao usar ele num projeto(principalmente com a Migrations) foi uma escolha correta.
- Para a autenticação utilizei uma abstração do Microsoft Identity chamada 'NetDevPack.Identity', usando JWT.
- Para a resiliência eu sei uma logica para buscar o token caso o retorno seja não autorizado.
- Utilizei um projeto separado para fazer as dependências sendo assim a api deve conhecer principalmente o domínio e ela conhece todos os projetos que interagem com a api.
- No repositório usei o EF core e o padrão de Repository utilizando um repositório genérico, adicionaria um Unit Of Work para melhorar o código.
- Os handler foram separados dos commands do padrão mediator separando as referencias.
- Para o deploy automatizado usei o github Actions vinculado ao azure subindo as 2 aplicações juntas.

## Live
- API: https://bardgapi.azurewebsites.net/index.html Para autenticar usar: email : 'web@client.com' senha:'01cd#998b2!311eab3dE0242ac13OOO4'
- WEB: https://bardgweb.azurewebsites.net/

