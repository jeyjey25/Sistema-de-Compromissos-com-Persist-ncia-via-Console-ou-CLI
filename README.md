# Sistema-de-Compromissos-com-Persist-ncia-via-Console-ou-CLI

-Jean M. k.
-Vitor T.
-Joao H.

# Sistema de Compromissos

## Descrição

Este é um aplicativo em C# para gerenciar compromissos de usuários. Ele permite criar, listar e gerenciar compromissos, incluindo informações como data, hora, descrição, local e participantes. O aplicativo oferece duas opções de interface: um modo de console interativo e um modo de linha de comando (CLI). Os dados são persistidos em arquivos JSON para garantir que as informações sejam mantidas entre as execuções do aplicativo.

## Funcionalidades

*   **Gerenciamento de Usuários:**
    *   Criação de usuários.
*   **Gerenciamento de Compromissos:**
    *   Criação de compromissos com data, hora, descrição e local.
    *   Adição de participantes aos compromissos.
    *   Adição de anotações aos compromissos.
    *   Listagem de compromissos de um usuário.
*   **Persistência de Dados:**
    *   Salva os dados em arquivos JSON.
    *   Carrega os dados dos arquivos JSON ao iniciar o aplicativo.
*   **Interface:**
    *   Opção de interface de console interativa com menu.

## Tecnologias Utilizadas

*   C#
*   .NET (versão 6.0 ou superior)
*   System.Text.Json (para serialização/desserialização JSON)

## Estrutura do Projeto

CompromissosApp
/Modelos
/Usuario.cs
/Compromisso.cs
/Participante.cs
/Anotacao.cs
/Local.cs
/Persistencia/RepositorioCompromisso.cs
Program.cs


*   **Modelos:** Contém as classes que representam os dados do aplicativo (Usuario, Compromisso, Participante, Anotacao, Local).
*   **Persistencia:** Contém a classe `RepositorioCompromissos` responsável por carregar e salvar os dados em arquivos JSON.
*   **Program.cs:** Contém o ponto de entrada do aplicativo e a lógica da interface do usuário (console interativo ou CLI).
*   **README.md:** Este arquivo, com informações sobre o projeto.
*   **CompromissosApp.csproj:** Arquivo de projeto do C#.

## Como Executar o Aplicativo

1.  **Clone o repositório:**

    ```bash
    git clone [URL do seu repositório]
    cd CompromissosApp
    ```

2.  **Restaure as dependências:**

    ```bash
    dotnet restore
    ```

3.  **Execute o aplicativo:**

    *   **Modo Console Interativo:**

        ```bash
        dotnet run
        ```

        Siga as instruções no console para interagir com o aplicativo.

    *   **Modo CLI (Exemplo):**

        ```bash
        dotnet run listar
        dotnet run adicionar --data 2024-12-31 --hora 18:00 --local "Sala de Reuniões" --descricao "Reunião de fim de ano"
        ```

        (A implementação completa da CLI dependerá da sua implementação em `Program.cs`.)

## Estratégia de Serialização

Adotamos a estratégia de serialização hierárquica (modelo em árvore). Os compromissos são serializados com seus participantes, local e anotações embutidos no mesmo arquivo JSON. Isso simplifica a leitura e escrita dos dados, mas pode resultar em arquivos maiores.

## Próximos Passos (Roadmap)

*   Implementar a interface CLI completa com a biblioteca `System.CommandLine`.
*   Adicionar testes unitários para garantir a qualidade do código.
*   Implementar validações mais robustas para os dados de entrada.
*   Adicionar suporte para edição e exclusão de compromissos.
*   Melhorar a interface do usuário do console interativo.

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e enviar pull requests.
