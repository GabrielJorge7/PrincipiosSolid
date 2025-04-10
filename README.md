Refatoração de Código com SOLID 
Este projeto foi refatorado aplicando dois dos princípios SOLID: Princípio da Responsabilidade Única (SRP) e Princípio da Inversão de Dependências (DIP). O objetivo da refatoração é melhorar a estrutura do código, tornando-o mais modular, flexível e fácil de manter.

Objetivo 🎯
O sistema gerencia uma lista de tarefas, permitindo criar novas tarefas, listar, marcar como concluídas e filtrar por prioridade. O código foi inicialmente simples, mas com algumas responsabilidades misturadas e dependências diretas. Aplicamos os princípios SOLID para melhorar o design do sistema.

Princípios SOLID Aplicados 🛠️
1. Princípio da Responsabilidade Única (SRP) 📜
O Princípio da Responsabilidade Única (SRP) afirma que uma classe deve ter uma única razão para mudar. Ou seja, deve ter uma única responsabilidade.

Antes da refatoração, a classe TaskManager estava realizando duas responsabilidades:

Gerenciamento das tarefas (adição, obtenção).

Filtragem das tarefas por prioridade.

Refatoramos o código para que a classe TaskManager fosse responsável apenas por gerenciar as tarefas, enquanto criamos uma nova classe TaskFilter para a responsabilidade de filtragem. Agora, cada classe tem uma única responsabilidade, o que melhora a modularidade e a manutenção do código! 🔧

2. Princípio da Inversão de Dependências (DIP) 🔄
O Princípio da Inversão de Dependências (DIP) afirma que módulos de alto nível (como o código que lida com a lógica de negócios) não devem depender de módulos de baixo nível (como implementações concretas de filtros ou impressões). Ambos devem depender de abstrações (interfaces ou classes abstratas).

Antes da refatoração, o código no Program.cs instanciava diretamente classes concretas como TaskManager e TaskFilter. Refatoramos para que essas classes dependessem de interfaces. Isso permite maior flexibilidade e desacoplamento entre as classes, facilitando futuras modificações e melhorias. 💡

Agora, o código depende de interfaces como ITaskManager e ITaskFilter, o que permite substituir implementações sem impactar o funcionamento principal do sistema.

Refatoração do Código 🔄
Estrutura de Diretórios 📂
plaintext
Copiar
Editar
- ICompletable.cs
- IPrintable.cs
- ITaskFilter.cs
- ITaskManager.cs
- Program.cs
- Task.cs
- TaskFilter.cs
- TaskManager.cs
- ConsoleTaskPrinter.cs
Classes e Interfaces 📚
Task: Representa uma tarefa, com título, prioridade e status de conclusão. Implementa as interfaces ICompletable (para marcar como concluída) e IPrintable (para imprimir a tarefa).

TaskManager: Gerencia a lista de tarefas, permitindo adicionar novas tarefas e obter todas as tarefas. Implementa a interface ITaskManager.

TaskFilter: Responsável por filtrar tarefas com base na prioridade. Implementa a interface ITaskFilter.

Program: Controlador principal da aplicação, onde o usuário interage com o sistema. Depende das interfaces ITaskManager e ITaskFilter.

ConsoleTaskPrinter: Implementa a interface ITaskPrinter para imprimir as tarefas no console.

Interfaces 🧩
ICompletable: Define os métodos MarkAsDone() e IsDone() para marcar e verificar o status da tarefa.

IPrintable: Define o método Print() para imprimir a tarefa.

ITaskManager: Define os métodos AddTask() e GetAllTasks() para gerenciar a lista de tarefas.

ITaskFilter: Define o método FilterByPriority() para filtrar tarefas por prioridade.

ITaskPrinter: Define o método PrintTasks() para imprimir a lista de tarefas.

Como Funciona 💡
Criar Nova Tarefa: O usuário pode inserir um título e uma prioridade para criar uma nova tarefa, que será adicionada ao gerenciador de tarefas.

Listar Tarefas: O sistema exibe todas as tarefas, mostrando se estão concluídas ou não.

Marcar Como Concluída: O usuário pode marcar uma tarefa como concluída.

Filtrar por Prioridade: O usuário pode filtrar as tarefas por prioridade (Alta, Média, Baixa).

Código de Exemplo 🖥️
Program.cs (Refatorado)
csharp
Copiar
Editar
using System;

class Program
{
    static void Main(string[] args)
    {
        ITaskPrinter printer = new ConsoleTaskPrinter();
        ITaskFilter taskFilter = new TaskFilter();  
        ITaskManager manager = new TaskManager();   

        while (true)
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Criar nova tarefa");
            Console.WriteLine("2. Listar tarefas");
            Console.WriteLine("3. Marcar tarefa como concluída");
            Console.WriteLine("4. Filtrar por prioridade");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha: ");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Título: ");
                    var titulo = Console.ReadLine();
                    Console.Write("Prioridade (Alta, Média, Baixa): ");
                    var prioridade = Console.ReadLine();
                    manager.AddTask(new Task(titulo, prioridade));
                    break;
                case "2":
                    printer.PrintTasks(manager.GetAllTasks());
                    break;
                case "3":
                    printer.PrintTasks(manager.GetAllTasks());
                    Console.Write("Número da tarefa para marcar como concluída: ");
                    if (int.TryParse(Console.ReadLine(), out int index) &&
                        index >= 0 && index < manager.GetAllTasks().Count)
                    {
                        manager.GetAllTasks()[index].MarkAsDone();
                    }
                    else
                    {
                        Console.WriteLine("Índice inválido!");
                    }
                    break;
                case "4":
                    Console.Write("Prioridade para filtrar: ");
                    var filtro = Console.ReadLine();
                    printer.PrintTasks(taskFilter.FilterByPriority(manager.GetAllTasks(), filtro));
                    break;
                case "0":
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
}
Como Rodar 🚀
Clone o repositório ou baixe os arquivos.

Compile o projeto em sua IDE favorita (Visual Studio, Visual Studio Code, etc.).

Execute o programa e interaja com o menu para gerenciar as tarefas.

Conclusão 🎉
A refatoração seguiu os princípios SOLID para tornar o código mais modular, flexível e fácil de manter. Ao aplicar o Princípio da Responsabilidade Única (SRP) e o Princípio da Inversão de Dependências (DIP), conseguimos melhorar a estrutura do código e permitir que ele seja mais facilmente estendido e modificado no futuro.
