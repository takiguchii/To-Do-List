namespace ToDoList.Models

{
    public class Author
    {
        private string Nome { get; set; }
        private string Email { get; set; }
        private int AssignedTasks { get; set; }
        
        public Author()
        {
            AssignedTasks = 0;
        } 
        
        public void CreateAuthor()
        {
            SetName();
            SetEmail();
        }
        private void SetName()
        {
            Console.Write("Digite o nome do author: ");
            Nome = Console.ReadLine();
        }
        private void SetEmail()
        {
            Console.Write("Digite o email do author: ");
            Email = Console.ReadLine();
        }
        public string GetName()
        {
            return Nome;
        }
        public string GetEmail()
        {
            return Email;
        }
        public void AddTask()
        {
            AssignedTasks++;
        }
        public int GetAssignedTasks()
        {
            return this.AssignedTasks;
        }
        
        
        
    }
}