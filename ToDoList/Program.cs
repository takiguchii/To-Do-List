namespace ToDoList;

class Program {
    static string Menu(){
        Console.Write("O que Deseja Selecionar? \n" );
        Console.Write("* Cadastrar um novo Responsave? \n");
        Console.Write("* cadastrar uma nova tarefa \n");
        Console.Write("* Deleter uma tarefa? \n");
        Console.Write("* Atualizar status de uma tarefa? \n");
        Console.Write("* Sair ");
        string menu = Console.ReadLine();
        return menu;
    }
    static string cadastrar(string menu )
    {
        Console.Write("Digite o nome do Responsavel: ");
        return menu;
    }
    static string listar(string menu)
    {
        Console.Write("Listar uma Tarefa (Pendente, Concluida) ? : ");
        return menu;
    }
    static string deletar(string menu)
    {
        Console.Write("Digite o nome do Responsavel: ");
        return menu;

    }
    static string atualizar(string menu)
    {
        Console.Write("Digite o nome do Responsavel: ");
        return menu;
    }

    static void SelectFunction(string menu)
    {
        if (menu == "cadastrar")
        {
            cadastrar(menu);

        }
        else if (menu == "listar")
        {
            listar(menu);
        }
        else if (menu == "deletar")
        {
            deletar(menu);
        }
        else if (menu == "atualizar")
        {
            atualizar(menu);
        }
        else
        {
            Console.Write("Escolha não esta disponivel");
        }
    }

    static void Main(){
        string menu = Menu();
        SelectFunction(menu);
    }
}