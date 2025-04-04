namespace ToDoList.Models;

enum Status {
    Todo,
    InProgress,
    Done,
}

enum Priority {
    Low,
    Medium,
    High,
}

public class Tasks {
    private string Title { get; set; }
    private string Description { get; set; }
    private Status Status { get; set; }
    private Priority Priority { get; set; }
    private DateTime Date { get; set; }
    private Author Author { get; set; }

    /* Registrar um título para a tarefa */
    public void RegisterTitle() {
        Console.Write("Digite o título da tarefa: ");
        Title = Console.ReadLine();
    }

    /* Registrar uma descrição para a tarefa */
    public void RegisterDescription() {
        Console.Write("Digite a descrição da tarefa: ");
        Description = Console.ReadLine();
    }

    /* Registrar o status para a tarefa */
    public void RegisterStatus() {
        int statusNumber = -1;
        while(statusNumber < 0 || statusNumber > 2) {
            Console.Write("Digite o status da tarefa (0- A fazer, 1- Em andamento, 2- Concluída): ");
            statusNumber = Convert.ToInt32(Console.ReadLine());
        }
        Status = (Status)Enum.ToObject(typeof(Status), statusNumber);
    }

    /* Registar a prioridade para a tarefa */
    public void RegisterPriority() {
        int priorityNumber = -1;
        while (priorityNumber < 0 || priorityNumber > 2) {
            Console.Write("Digite a prioridade da tarefa (0- Baixa, 1- Média, 2- Alta): ");
            priorityNumber = Convert.ToInt32(Console.ReadLine());
        }
        Priority = (Priority)Enum.ToObject(typeof(Priority), priorityNumber);
    }

    /* Registrar a data limite para a tarefa */
    public void RegisterLimitDate() {
        do {
            int day = 0;
            int month = 0;
            int year = 2025;
            Console.WriteLine("Digite a data limite para realizar a tarefa: ");
            while (day <= 0 || day > 31) {
                Console.Write("Dia: ");
                day = Convert.ToInt32(Console.ReadLine());
            }

            while (month < DateTime.Now.Month || month > 12) {
                if (day < DateTime.Now.Day) {
                    while (month <= DateTime.Now.Month) {
                        Console.Write("Mês: ");
                        month = Convert.ToInt32(Console.ReadLine());
                    }
                    break;
                }
                month++;
            }
            Date = new DateTime(year, month, day);
        } while (LimitToDate());
    }

    /* Método para limitar uma tarefa de prioridade alta para somente uma semana */
    private bool LimitToDate() {
        if (Priority == Priority.High) {
            DateTime nowDate = DateTime.Now;
            if (((Date - nowDate).TotalDays / 7) > 1) {
                Console.WriteLine("A data inserida é maior do que uma semana para a prioridade alta!");
                return true;
            }
        }
        return false;
    }

    /* Adiciona um responsável para a tarefa */
    public void AddAuthor(ref Author author) {
        if (author.GetAssignedTasks() >= 3) {
            Console.WriteLine("Não é possível adicionar uma nova tarefa para este autor!");
            return;
        }
        author.AddTask();
    }

    /* Cria uma tarefa */
    public void CreateTask(Author author) {
        RegisterTitle();
        RegisterDescription();
        RegisterStatus();
        RegisterPriority();
        RegisterLimitDate();
        AddAuthor(ref author);
    }

    public string GetTitle() {
        return Title;
    }
    public string GetDescription() {
        return Description;
    }
    public string GetStatus() {
        return Status.ToString();
    }
    public string GetPriority() {
        return Priority.ToString();
    }
    public string GetDate() {
        return Date.ToString("yyyy-MM-dd");
    }
}


