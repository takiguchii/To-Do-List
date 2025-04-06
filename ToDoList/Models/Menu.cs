namespace ToDoList.Models;

public class Menu
{
    public static void ImprimirMenu(ref List<Author> authors, ref List<Tasks> tasks)
    {
        while (true)
        {
            PrintSeparation();
            Console.WriteLine("O que Deseja Selecionar?");
            PrintSeparation();
            Console.WriteLine("* Cadastrar, Deletar, Listar , Atualizar ,Sair");
            PrintSeparation();
            Console.Write("Escolha uma opção: \n");
            PrintSeparation();
            string option = Console.ReadLine();
            option = option.ToLower();
            string selectFunction = SelectFunction(option);
            if (selectFunction == "sair")
            {
                break;
            }
            FilterFunction(selectFunction, option, authors, tasks);
        }
    }
    public static string SelectFunction(string option)
    {
        string selectFunction = null!;
        switch (option)
        {
            case "cadastrar":
                PrintSelectFunction(option);
                selectFunction = Console.ReadLine();
                return selectFunction;
            case "deletar":
                PrintSelectFunction(option);
                selectFunction = Console.ReadLine();
                return selectFunction;
            case "listar":
                PrintSelectFunction(option);
                selectFunction = Console.ReadLine();
                return selectFunction;
            case "sair":
                return selectFunction = "sair";
        }
        return selectFunction;
    }
    public static void PrintSelectFunction(string option) //Imprimi na tela
    {
        PrintSeparation();
        Console.Write($"Deseja Cadastrar o {option} Author or Tarefa?: ");
        PrintSeparation();
    }

    public static void PrintSelectFunctionListar() // Imprimi na tela 
    {
        PrintSeparation();
        Console.Write("Deseja Listar Todas as Tarefas? ou Tarefas Concluidas/Pendentes ?: ");
        PrintSeparation();
    }

    public static void PrintSeparation()
    {
        Console.WriteLine("===========================================================");
    }
    public static void SelectFunctionListar(List<Tasks> tasks) //Faz a Seleção dos tipos de impreções da tarefa 
    {
        string SelectListar = Console.ReadLine();
        SelectListar = SelectListar.ToLower();
        
        switch (SelectListar)
        {
            case "todas" :
                ListarTarefa(ref tasks);
                break;
            case "concluidas":
                ListarTarefaConcluida(ref tasks);
                break;
            case "pendentes":
                ListarTarefaPendente(ref tasks);
                break;
        }
    }
    public static void FilterFunction(string selectFunction, string option, List<Author> authors, List<Tasks> tasks) // Filtra as opçoes selecionadas pelo usuario 
    {
        switch (selectFunction)
        {
            case "author":
                if (option == "cadastrar")
                {
                    CadastrarAuthor(ref authors); 
                }
                else if (option == "deletar")
                {
                    //DeletarAuthor();
                }
                else if (option == "listar")
                {
                    ListarAuthor(ref authors);
                }
                else if (option == "atualizar")
                {
                    //AtualizarAuthor(ref authors);
                }
                break;
            case "tarefa":
                if (option == "cadastrar")
                {
                    CadastrarTarefa(ref tasks, ref authors);
                }
                else if (option == "deletar")
                {
                    //DeletarTarefa();
                }
                else if (option == "listar")
                {
                    PrintSelectFunctionListar();
                    SelectFunctionListar(tasks);
                }
                else if (option == "atualizar")
                {
                    //AtualizarTarefa();
                }
                break;
            
            default:
                break;
        }
    }
    public static void CadastrarTarefa(ref List<Tasks> tarefas, ref List<Author> authors)
    {
        Tasks tarefa = new Tasks();
        tarefa.CreateTask();
        
        //Verifica se Possui um author ja registrado, caso não tenha chama a função "Adiciocionar Author"
        if (authors.Count > 0)
        {
            tarefa.AddAuthor(PinAuthorToTask(ref authors));
            tarefas.Add(tarefa);
        }
        else
        {
            CadastrarAuthor(ref authors);
            tarefa.AddAuthor(PinAuthorToTask(ref authors));
            tarefas.Add(tarefa);
        }

    }
    public static void CadastrarAuthor(ref List<Author> authors)
    {
        Author author = new Author();
        author.CreateAuthor();
        authors.Add(author);
    }
    public static void ListarAuthor(ref List<Author> authors)
    {
        int i = 0;
        foreach (Author author in authors)
        {
            Console.WriteLine($"{ i++ } - {author.GetName()}");
        }
    }

    public static Author PinAuthorToTask(ref List<Author> authors)
    {
        Console.Write("Qual Author vc deseja Adiconar nessa tarefa?: ");
        ListarAuthor(ref authors);
        int SelectAuthor = Convert.ToInt32(Console.ReadLine());
        return authors[SelectAuthor];
    } 
    
    
    //---------------------------------------------------------------------------------------------------------------------
    
    //- Listar tarefa
        public static void ListarTarefa(ref List<Tasks> tasks)
        {
            foreach (Tasks task in tasks)
            {
                Console.WriteLine($"tarefa:\n");
                Console.WriteLine($"Nome: {task.GetTitle()}");
                Console.WriteLine($"Descricao: {task.GetDescription()}");
                Console.WriteLine($"Data de entrega: {task.GetDate()}");
                Console.WriteLine($"Esta tarefa esta com o status: {ConvertStatusToString(task.GetStatus())}");
                Console.WriteLine($"Esta tarefa esta na prioridade: {ConvertPriorityToString(task.GetPriority())}");
                Console.WriteLine($"Essa tarefa é do Author {(task.GetAuthor()).GetName()}");
                Console.WriteLine($"\n");
            }
        }
        // listar tarefa concluida
        public static void ListarTarefaConcluida(ref List<Tasks> tasks)
        {
            foreach (Tasks task in tasks)
            {
                if (((Status)task.GetStatus()) == Status.Done)
                {
                    Console.WriteLine($"tarefa:\n");
                    Console.WriteLine($"Nome: {task.GetTitle()}");
                    Console.WriteLine($"Descricao: {task.GetDescription()}");
                    Console.WriteLine($"Data de entrega: {task.GetDate()}");
                    Console.WriteLine($"Esta tarefa esta com o status: {ConvertStatusToString(task.GetStatus())}");
                    Console.WriteLine($"Esta tarefa esta na prioridade: {ConvertPriorityToString(task.GetPriority())}");
                    Console.WriteLine($"\n");
                }
            }
        }
        // listar tarefa pendente
        public static void ListarTarefaPendente(ref List<Tasks> tasks)
        {
            foreach (Tasks task in tasks)
            {
                if (((Status)task.GetStatus()) == Status.InProgress || ((Status)task.GetStatus()) == Status.Todo)
                {
                    Console.WriteLine($"tarefa:\n");
                    Console.WriteLine($"Nome: {task.GetTitle()}");
                    Console.WriteLine($"Descricao: {task.GetDescription()}");
                    Console.WriteLine($"Data de entrega: {task.GetDate()}");
                    Console.WriteLine($"Esta tarefa esta com o status: {ConvertStatusToString(task.GetStatus())}");
                    Console.WriteLine($"Esta tarefa esta na prioridade: {ConvertPriorityToString(task.GetPriority())}");
                    Console.WriteLine($"\n");
                }
            }
        }
        private static string ConvertStatusToString(int status)
        {
            switch ((Status)status)
            {
                case Status.Todo: return "A Fazer";
                case Status.InProgress: return "Em Processo";
                case Status.Done: return "Finalizado";
                default: return "Error";
            }
        }
        private static string ConvertPriorityToString(int priority)
        {
            switch ((Priority)priority)
            {
                case Priority.Low: return "Baixo";
                case Priority.Medium: return "Medio";
                case Priority.High: return "Alto";
                default: return "Error";
            }
        }
}