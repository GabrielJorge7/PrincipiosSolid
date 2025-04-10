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
