namespace ToDoList.Models;

public class Author {
    private string Name { get; set; } = string.Empty;
    private string Email { get; set; } = string.Empty;
    private int AssignedTasks { get; set; } = 0;

    public void RegisterName() {
        string name = String.Empty;
        while (true) {
            Console.Write("Digite o nome do autor: ");
            name = Console.ReadLine();
            if (name != String.Empty) {
                SetName(name);
                return;
            }
            Console.WriteLine("Digite um nome válido!");
        }
    }

    public void RegisterEmail() {
        string email = String.Empty;
        while (true) {
            Console.Write("Digite o e-mail do autor: ");
            email = Console.ReadLine();
            if (email != String.Empty) {
                SetEmail(email);
                return;
            }
            Console.WriteLine("Digite um e-mail válido!");
        }
    }
    public void CreateAuthor() {
        RegisterName();
        RegisterEmail();
    }
    public void AddTask() {
        AssignedTasks++;
    }
    public void Info() {
        Console.WriteLine($"Nome: {GetName()} - Email: {GetEmail()} - Tarefas Atribuidas: {GetAssignedTasks()}");
    }
    public void SetName(string name) {
        Name = name;
    }
    public void SetEmail(string email) {
        Email = email;
    }
    public string GetName() {
        return this.Name;
    }
    public string GetEmail() {
        return this.Email;
    }
    public int GetAssignedTasks() {
        return this.AssignedTasks;
    }
}