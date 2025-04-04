namespace ToDoList;
using ToDoList.Models;

class Program
{
    static void Main(string[] args)
    {
        string opcao;
        do
        {
            opcao = Menu.ImprimirMenu(); 
            Menu.SelectFunction(opcao);  
                
        } while (opcao != "sair");
    }
}