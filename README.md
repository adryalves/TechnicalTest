# Avaliação Técnica
A avaliação consiste em 2 tarefas. A primeira se refere a escrita de uma Query no Banco de Dados, já a segunda consiste em um Algoritmo em C# que irá receber uma array de inteiros e inserir os
valores em uma árvore.

## Tarefa 1
Dada a tabela "Pessoa" que possui a relação de todos os colaboradores de uma empresa e que cada pessoa tem um Id, um salário, e também uma coluna para o ID do departamento.E dada a tabela de
"Departamento" que contém a lista de departamentos da empresa e possui os seguintes atributos: Id e Nome. Escreva uma consulta usando linguagem SQL para encontrar os colaboradores que tem o salário mais alto em cada um dos departamentos
<br> 

### Resposta Tarefa 1:

A resposta dessa atividade se encontra na primeira pasta desse projeto, 1-Query, no qual tem-se as queries para criar o bancio de dados as duas tabelas, apenas para fim de teste e por fim a query 
respondendo a atividade pedida. A resposta está em um arquivo SQL, permitindo que seja aberto em algum Banco de Dados.

## Tarefa 2
Dado um array inteiro sem duplicidade, construa um algoritmo de uma árvore a partir das seguintes regras:
-	A raiz da árvore deve ser o maior valor do array
-	Os galhos da esquerda devem ser compostos somente por números à esquerda do valor raiz, na ordem decrescente
-	Os galhos da direita devem ser compostos somente por número à direita do valor raiz, na ordem decrescente

### Resposta Tarefa 2:
O código com a resposta dessa Tarefa está na segunda pasta, 2-TreeAlgorithm, contendo todos os arquivos necessários para a execução desse algoritmo. Basicamente o código é composto por 3 arquivos principais: 
- TreeNode: Criação do Objeto que representa a árvore
- BuildTree: Essa Classe possui o método responsável por construir a árvore de acordo os valores recebidos do array
- Program: É a classe principal do projeto, e a que de fato será executada, ela que faz a interação com o usuário pedindo o array, é quem chama o método da Classe acima para criar a árvore e quem gerencia a lógica de exibição para o usuário.

### Como rodar esse código:

Para executar o algoritmo da **Tarefa 2**, é necessário ter o **.NET 8 SDK** instalado na máquina.

Após garantir a instalação, siga os passos abaixo:

1. Abra um terminal (Prompt de Comando, PowerShell ou Terminal do VS Code).

2. Após navegar até a pasta geral do projeto, certifique-se de entrar na pasta **2-TreeAlgorithm**, que contém o código da árvore:

```bash
cd 2-TreeAlgorithm
```
3. Após isso, execute o projeto utilizando o comando:
```bash
dotnet run
```
4. Pronto! Agora o Programa já exibirá um menu permitindo que você interaja com o programa e tanto insira os dados do array, quanto receba os retornos mostrandos valores da árvore como pedido na tarefa.


