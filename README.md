### Mamba - Read Me

**Link do repositório no GitHub:** https://github.com/pedrorangelf/mamba
- **Login da Aplicação:** user@example.com
- **Senha da Aplicação:** Teste_123
- **Host do banco de dados SQL Server:** 74.50.111.162
- **Login do banco de dado SQL Server: (Somente para consultas)** fiap_select
- **Senha do banco de dado SQL Server: (Somente para consultas)** 3*3h4Pqy

## Tecnologias
- .Net Core 3.1
- Web Api .Net Core 3.1
- Angular 9
- SQL Server
- Ionic Framework 4

## Pré-requisitos
Siga os passos abaixo e garanta que tudo estará instalado para a execução do projeto.

1. Baixe e instale o VS Code no link https://code.visualstudio.com/ ou o Visual Studio Community 2019 pelo link https://visualstudio.microsoft.com/pt-br/vs/
2. Baixe e instale o .Net Core 3.1 pelo link https://dotnet.microsoft.com/download/dotnet-core/3.1
3. Baixe e instale o NodeJS pelo link https://nodejs.org/ (selecione a opção "LTS").
4. Instale o Angular CLI executando o seguinte comando no terminal:
**npm i -g @angular/cli**
5. Instale o Ionic CLI executando o seguinte comando no terminal:
**npm install -g @ionic/cli**  -- https://ionicframework.com/docs/intro/cli


## Passo a passo
Caso utilize o Visual Studio Community, abra a solution na IDE e defina o projeto Mamba.API como o projeto inicializador e depure o projeto.

Caso utilize o VS Code ou qualquer editor de texto que não seja o Visual Studio Community, siga os passos abaixo para executar o projeto:
Após tudo instalado e configurado, abra o prompt de comando e navegue até a pasta do projeto e execute os comandos abaixo respeitando a sequência.

**No terminal acesse a pasta "server" e execute os comandos abaixo:**
- dotnet restore
- dotnet build
- acessar o projeto Mamba.API (cd Mamba.API)
- dotnet run

**No terminal acesse a pasta "front" e execute os comandos abaixo:**

- npm install
- ng serve --o

**No terminal acesse a pasta "mobile" e execute os comandos abaixo:**
- npm install
- ionic serve

**A URL da API no arquivo src/environment/environment.ts está apontando para o serviço PUBLICADO**

**AO EXECUTAR O APP NO BROWSER LEMBRE-SE DE ATIVAR AS FERRAMENTAS DO DESENVOLVEDOR(F12) E SELECIONAR QUALQUER DISPOSITIVO PARA VISUALIZAR MELHOR.**
