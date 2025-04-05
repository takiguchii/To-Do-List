namespace ToDoList.Models;

public class Menu
{
    public static void ImprimirMenu(ref List<Author> authors, ref List<Tasks> tasks)
    {
        while (true)
        {
            string separation = "===========================================================";
            Console.WriteLine(separation);
            Console.WriteLine("O que Deseja Selecionar?");
            Console.WriteLine(separation);
            Console.WriteLine("* Cadastrar, Deletar, Lista, Atualizar ,Sair");
            Console.WriteLine(separation);
            Console.Write("Escolha uma opção: \n");
            Console.WriteLine(separation);
            string option = Console.ReadLine();
            option = option.ToLower();
            string selectFunction = SelectFunction(option);
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
                return null;
        }
        return selectFunction;
    }
    public static void PrintSelectFunction(string option)
    {
        Console.Write($"Deseja Cadastrar o {option} Author or Tarefa?");
    }
    public static void FilterFunction(string selectFunction, string option, List<Author> authors, List<Tasks> tasks)
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
                    //ListarTarefa();
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
        tarefa.AddAuthor(PinAuthorToTask(ref authors));
        tarefas.Add(tarefa);
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
}