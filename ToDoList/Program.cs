namespace ToDoList;
using ToDoList.Models;

class Program
{
    static void Main(string[] args)
    {
        List<Tasks> tasks = new List<Tasks>();
        List<Author> authors = new List<Author>();
        
        Menu.PrintMenu(ref authors, ref tasks);
    }
}

