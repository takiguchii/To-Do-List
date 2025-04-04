namespace ToDoList.Models;

public class Menu
{
    public static string ImprimirMenu()
    {
        string separation = "===========================================================";
        Console.WriteLine(separation);
        Console.WriteLine("O que Deseja Selecionar?");
        Console.WriteLine(separation);
        Console.WriteLine("* Cadastrar um novo Responsável/Tarefa");
        Console.WriteLine("* Deletar uma tarefa");
        Console.WriteLine("* Atualizar status de uma tarefa");
        Console.WriteLine("* Listar Tarefas/Usuarios");
        Console.WriteLine("* Sair");
        Console.WriteLine(separation);
        Console.Write("Escolha uma opção: \n");
        Console.WriteLine(separation);
        return Console.ReadLine().Trim().ToLower(); 
    }

    public static void SelectFunction(string menu)
    {
        

    }
    
}