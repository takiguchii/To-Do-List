namespace ToDoList.Models;

enum Option {
    Exit = 0
}
enum OptionListTasks {
    All = 1,
    Done,
    Pending
}

enum Action {
    Register = 1,
    Update,
    List,
    Delete,
}
enum Entity {
    Author = 1,
    Task,
}

enum OptionEditAuthor {
    Name = 1,
    Email,
    All
}

enum OptionEditTask {
    Title = 1,
    Description,
    Status,
    Priority,
    Date,
    Author,
    All
}

public class Menu
{
    public static void PrintSeparation() {
        Console.WriteLine("=======================================================================================");
    }
    public static void PrintMenu(ref List<Author> authors, ref List<Tasks> tasks)
    {
        while (true)
        {
            int action = SelectAction();
            if (action == (int)Option.Exit) break;
            int entity = SelectEntity(action);
            if (entity != (int)Option.Exit) {
                int[] execAction = [action, entity];
                ExecuteAction(ref authors, ref tasks, execAction);
            }
        }
    }
    public static int SelectAction() {
        Console.WriteLine("O que Deseja Selecionar? (1- Cadastrar, 2- Atualizar, 3- Listar, 4- Deletar, 0- Sair)");
        int option;
        while (true) {
            Console.Write($"> ");
            option = Convert.ToInt32(Console.ReadLine());
            if(option == (int)Option.Exit) return option;
            switch ((Action)option) {
                case Action.Register: return option;
                case Action.Update:   return option;
                case Action.List:     return option;
                case Action.Delete:   return option;
                default: Console.WriteLine("Opção inválida! Digite novamente."); break;
            }
        }
    }
    public static int SelectEntity(int action) {
        Console.WriteLine($"O que você deseja {(ConvertActionToString(action)).ToLower()}? (1- Autor, 2- Tarefa, 0- Voltar)");
        int entity;
        while (true) {
            Console.Write($"> ");
            entity = Convert.ToInt32(Console.ReadLine());
            if(entity == (int)Option.Exit) return entity;
            switch ((Entity)entity) {
                case Entity.Author: return entity;
                case Entity.Task: return entity;
                default: Console.WriteLine("Opção inválida! Digite novamente."); break;
            }
        }
    }

    public static void ExecuteAction(ref List<Author> authors, ref List<Tasks> tasks, int[] execAction) {
        switch ((Action)execAction[0]) {
            case Action.Register:
                if((Entity)execAction[1] == Entity.Author) RegisterAuthor(ref authors);
                else if((Entity)execAction[1] == Entity.Task) RegisterTask(ref tasks, ref authors);
                break;
            case Action.Update:
                if((Entity)execAction[1] == Entity.Author) UpdateAuthor(ref authors);
                else if((Entity)execAction[1] == Entity.Task) UpdateTask(ref tasks, ref authors);
                break;
            case Action.List:
                if((Entity)execAction[1] == Entity.Author) ListAuthor(ref authors);
                else if((Entity)execAction[1] == Entity.Task) ListTasks(ref tasks);
                break;
            case Action.Delete:
                if ((Entity)execAction[1] == Entity.Author) ExcludeAuthor(ref authors);
                else if ((Entity)execAction[1] == Entity.Task) ExcludeTask(ref tasks);
                break;
            default: Console.WriteLine("Isso não era para ter acontecido..."); break;
        }
    }
    public static void RegisterTask(ref List<Tasks> tasks, ref List<Author> authors) {
        Tasks task = new Tasks();
        task.CreateTask(ref authors);
        tasks.Add(task);
    }
    public static void RegisterAuthor(ref List<Author> authors) {
        Author author = new Author();
        author.CreateAuthor();
        authors.Add(author);
    }

    public static void UpdateAuthor(ref List<Author> authors) {
        Console.WriteLine($"Qual autor vocẽ deseja atualizar?");
        ListAuthor(ref authors);
        int option = 0;
        while (true) {
            Console.Write($"> ");
            option = Convert.ToInt32(Console.ReadLine());
            if (option >= 0 && option < authors.Count) {
                EditAuthor(authors[option]);
                return;
            }
            Console.WriteLine($"Autor inválido! Digite um autor existente.");
        }
    }

    public static void EditAuthor(Author author) {
        Console.WriteLine($"O que você deseja editar? (1- Nome, 2- Email, 3- Tudo)");
        int option = 0;
        while (true) {
            option = Convert.ToInt32(Console.ReadLine());
            switch ((OptionEditAuthor)option) {
                case OptionEditAuthor.Name: author.RegisterName(); return;
                case OptionEditAuthor.Email: author.RegisterEmail(); return;
                case OptionEditAuthor.All:
                    author.RegisterName();
                    author.RegisterEmail();
                    return;
                default: Console.WriteLine($"Opção inválida. Digite novamente."); break; 
            }
        }
    }

    public static void UpdateTask(ref List<Tasks> tasks, ref List<Author> authors) {
        Console.WriteLine($"Qual tarefa você deseja atualizar?");
        ListTasks(ref tasks);
        int option = 0;
        while (true) {
            Console.Write($"> ");
            option = Convert.ToInt32(Console.ReadLine());
            if (option >= 0 && option < tasks.Count) {
                EditTask(tasks[option], ref authors);
                return;
            }
            Console.WriteLine("Tarefa inválida! Digite uma tarefa existente.");
        }
    }
    
    public static void EditTask(Tasks task, ref List<Author> authors) {
        Console.WriteLine($"O que você deseja editar? (1- Título, 2- Descrição, 3- Status, 4- Prioridade, 5- Data, 6- Autor, 7- Tudo"); 
        int option = 0;
        while (true) {
            option = Convert.ToInt32(Console.ReadLine());
            switch ((OptionEditTask)option) {
                case OptionEditTask.Title: task.RegisterTitle(); return;
                case OptionEditTask.Description: task.RegisterDescription(); return;
                case OptionEditTask.Status: task.RegisterStatus(); return;
                case OptionEditTask.Priority: task.RegisterPriority(); return;
                case OptionEditTask.Date: task.RegisterLimitDate(); return;
                case OptionEditTask.Author: task.AttachAuthorToTask(ref authors); return;
                case OptionEditTask.All:
                    task.RegisterTitle();
                    task.RegisterDescription();
                    task.RegisterStatus();
                    task.RegisterPriority();
                    task.RegisterLimitDate();
                    task.AttachAuthorToTask(ref authors);
                    return;
                default: Console.WriteLine("Opção inválida! Digite novamente."); break;
            }
        }
    }

    public static void ExcludeAuthor(ref List<Author> authors) {
        Console.WriteLine("Qual autor você deseja excluir?");
        ListAuthor(ref authors);
        int option = 0;
        while (true) {
            Console.Write("> ");
            option = Convert.ToInt32(Console.ReadLine());
            if (option >= 0 && option < authors.Count) {
                authors.RemoveAt(option);
                return;
            }
            Console.WriteLine("Autor inválido! Digite um autor existente.");
        }
    }

    public static void ExcludeTask(ref List<Tasks> tasks) {
        Console.WriteLine("Qual tarefa você deseja excluir?");
        ListTasks(ref tasks);
        int option = 0;
        while (true) {
            Console.Write("> ");
            option = Convert.ToInt32(Console.ReadLine());
            if (option >= 0 && option < tasks.Count) {
                tasks.RemoveAt(option);
            }
            Console.WriteLine("Tarefa inválida! Digite uma tarefa existente.");
        }
    }

    public static void ListAuthor(ref List<Author> authors)
    {
        int i = 0;
        PrintSeparation();
        foreach (Author author in authors) {
            Console.Write($"Autor {i++}- ");
            author.Info();
        }
        PrintSeparation();
    }
    public static void ListTasks(ref List<Tasks> tasks) {
        Console.WriteLine($"Como você deseja listar as tarefas? (1- Todas, 2- Feitas, 3- Pendentes)");
        int option = 0;
        while (true) {
            Console.Write($"> ");
            option = Convert.ToInt32(Console.ReadLine());
            switch ((OptionListTasks)option) {
                case OptionListTasks.All: ListAllTasks(ref tasks); return;
                case OptionListTasks.Done: ListDoneTasks(ref tasks); return;
                case OptionListTasks.Pending: ListPendingTasks(ref tasks); return;
                default: Console.WriteLine("Opção inválida! Digite novamente."); break;
            }
        }
    }
    public static void ListAllTasks(ref List<Tasks> tasks) {
        int i = 0;
        PrintSeparation();
        foreach (Tasks task in tasks) {
            Console.WriteLine($"Tarefa {i++}");
            task.Info();
        }
        PrintSeparation();
    }
    public static void ListDoneTasks(ref List<Tasks> tasks)
    {
        int i = 0;
        PrintSeparation();
        foreach (Tasks task in tasks) {
            if (((Status)task.GetStatus()) == Status.Done) {
                Console.WriteLine($"Tarefa {i++}");
                task.Info();
            }
        }
        PrintSeparation();
    }
    public static void ListPendingTasks(ref List<Tasks> tasks) {
        int i = 0;
        PrintSeparation();
        foreach (Tasks task in tasks) {
            if (((Status)task.GetStatus()) == Status.InProgress || ((Status)task.GetStatus()) == Status.Todo) {
                Console.WriteLine($"Tarefa {i++}");
                task.Info();
            }
        }
        PrintSeparation();
    }

    public static string ConvertActionToString(int action) {
        switch ((Action)action) {
            case Action.Register: return "Cadastrar";
            case Action.Update:   return "Atualizar";
            case Action.List:   return "Listar";
            case Action.Delete:   return "Excluir";
            default: 
                Console.WriteLine("Isso não era para ter acontecido...");
                return "";
        }
    }
}