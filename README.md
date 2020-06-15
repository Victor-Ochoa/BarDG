
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

#### Repositorio
- Abstração do repositório facilitando o acesso as informações usando uma base genérica do acesso a dado.
