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
    private string Title { get; set; } = String.Empty;
    private string Description { get; set; } = String.Empty;
    private Status Status { get; set; }
    private Priority Priority { get; set; }
    private DateTime Date { get; set; }
    private Author Author { get; set; } = null!;

    /* Registrar um título para a tarefa */
    public void RegisterTitle() {
        string title = String.Empty;
        while (true) {
            Console.Write("Digite o título da tarefa: ");
            title = Console.ReadLine();
            if (title != String.Empty) {
                SetTitle(title);
                return;
            }
            Console.WriteLine("Digite um título válido!");
        }
    }
    /* Registrar uma descrição para a tarefa */
    public void RegisterDescription() {
        string description = String.Empty;
        while (true) {
            Console.Write("Digite a descrição da tarefa: ");
            description = Console.ReadLine();
            if (description != String.Empty) {
                SetDescription(description);
                return;
            }
            Console.WriteLine("Digite uma descrição válida!");
        }
    }
    /* Registrar o status para a tarefa */
    public void RegisterStatus() {
        int statusNumber = -1;
        while(statusNumber < 0 || statusNumber > 2) {
            Console.Write("Digite o status da tarefa (0- A fazer, 1- Em andamento, 2- Concluída): ");
            statusNumber = Convert.ToInt32(Console.ReadLine());
            if (statusNumber >= 0 && statusNumber <= 2) break;
            Console.WriteLine("Digite um status válido!");
        }
        SetStatus(statusNumber);
    }

    /* Registar a prioridade para a tarefa */
    public void RegisterPriority() {
        int priorityNumber = -1;
        while (priorityNumber < 0 || priorityNumber > 2) {
            Console.Write("Digite a prioridade da tarefa (0- Baixa, 1- Média, 2- Alta): ");
            priorityNumber = Convert.ToInt32(Console.ReadLine());
            if(priorityNumber >= 0 && priorityNumber <= 2) break;
            Console.WriteLine("Digite uma prioridade válida!");
        }
        SetPriority(priorityNumber);
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
            SetDate(day, month, year);
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
    public void AttachAuthorToTask(ref List<Author> authors) {
        if (authors.Count == 0) {
            Console.WriteLine("Vejo que não há nenhum autor registrado, adicione um para anexar a tarefa.");
            Menu.RegisterAuthor(ref authors);
        }
        while (true) {
            Console.WriteLine($"Qual autor você deseja anexar a tarefa?");
            Menu.ListAuthor(ref authors);
            Console.Write("> ");
            int selectAuthor = Convert.ToInt32(Console.ReadLine());
            if (selectAuthor >= 0 && selectAuthor <= authors.Count) {
                AddAuthor(authors[selectAuthor]);
                return;
            }
            Console.WriteLine($"Autor inválido! Por favor anexe um autor existente.");
        }
    } 

    /* Adiciona um responsável para a tarefa */
    public void AddAuthor(Author author) {
        if (author.GetAssignedTasks() >= 3) {
            Console.WriteLine("Não é possível adicionar uma nova tarefa para este autor!");
            return;
        }
        author.AddTask();
        SetAutor(author);
    }

    /* Cria uma tarefa */
    public void CreateTask(ref List<Author> authors) {
        RegisterTitle();
        RegisterDescription();
        RegisterStatus();
        RegisterPriority();
        RegisterLimitDate();
        AttachAuthorToTask(ref authors);
    }

    public void Info() {
        Console.WriteLine($"Nome: {GetTitle()}");
        Console.WriteLine($"Descricao: {GetDescription()}");
        Console.WriteLine($"Data de entrega: {GetDate()}");
        Console.WriteLine($"Esta tarefa esta com o status: {ConvertStatusToString()}");
        Console.WriteLine($"Esta tarefa esta na prioridade: {ConvertPriorityToString()}");
        Console.WriteLine($"Essa tarefa é do Author {Author.GetName()}");
    }
    public string ConvertStatusToString()
    {
        switch(Status) {
            case Status.Todo: return "A Fazer";
            case Status.InProgress: return "Em Processo";
            case Status.Done: return "Finalizado";
            default: return "Error";
        }
    }
    public string ConvertPriorityToString()
    {
        switch(Priority) {
            case Priority.Low: return "Baixo";
            case Priority.Medium: return "Medio";
            case Priority.High: return "Alto";
            default: return "Error";
        }
    }

    private string ConvertDateToString() {
        return Date.ToString("dd/MM/yyyy");
    }

    public void SetTitle(string title) {
        Title = title;
    }

    public void SetDescription(string description) {
        Description = description;
    }

    public void SetStatus(int status) {
        Status = (Status)status;
    }

    public void SetPriority(int priority) {
        Priority = (Priority)priority;
    }

    public void SetDate(int day, int month, int year) {
        Date = new DateTime(year, month, day);
    }

    public void SetAutor(Author author) {
        Author = author;
    }
    public string GetTitle() {
        return Title;
    }
    public string GetDescription() {
        return Description;
    }
    public int GetStatus() {
        return Convert.ToInt32(Status);
    }
    public int GetPriority() {
        return Convert.ToInt32(Priority);
    }
    public DateTime GetDate() {
        return Date;
    }
    public Author GetAuthor()
    {
        return Author;
    }
}