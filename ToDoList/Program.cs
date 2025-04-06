namespace ToDoList;
using ToDoList.Models;

class Program
{
    static void Main(string[] args)
    {
        List<Tasks> tarefas = new List<Tasks>();
        List<Author> authors = new List<Author>();
        
        Menu.ImprimirMenu(ref authors, ref tarefas);
        
    }
}

