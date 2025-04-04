namespace ToDoList.Models

{
    public class Author
    {
        private string Nome { get; set; }
        private string Email { get; set; }
        private int AssignedTasks { get; set; }
        

        public Author(string nome, string email, string tarefa)
        {
            Nome = nome;
            Email = email;
            AssignedTasks = 0;

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