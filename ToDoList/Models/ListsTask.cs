using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    class ListsTask
    {
        //- Listar tarefa
        public void ListarTarefa(ref List<Tasks> tasks)
        {
            foreach (Tasks task in tasks)
            {
                Console.WriteLine($"tarefa:\n");
                Console.WriteLine($"Nome: {task.GetTitle()}");
                Console.WriteLine($"Descricao: {task.GetDescription()}");
                Console.WriteLine($"Data de entrega: {task.GetDate()}");
                Console.WriteLine($"Esta tarefa esta com o status: {ConvertStatusToString(task.GetStatus())}");
                Console.WriteLine($"Esta tarefa esta na prioridade: {ConvertPriorityToString(task.GetPriority())}");
                Console.WriteLine($"Essa tarefa é do Author {(task.GetAuthor()).GetName()}");
                Console.WriteLine($"\n");
            }
        }
        // listar tarefa concluida
        public void ListarTarefaConcluida(ref List<Tasks> tasks)
        {
            foreach (Tasks task in tasks)
            {
                if (((Status)task.GetStatus()) == Status.Done)
                {
                    Console.WriteLine($"tarefa:\n");
                    Console.WriteLine($"Nome: {task.GetTitle()}");
                    Console.WriteLine($"Descricao: {task.GetDescription()}");
                    Console.WriteLine($"Data de entrega: {task.GetDate()}");
                    Console.WriteLine($"Esta tarefa esta com o status: {ConvertStatusToString(task.GetStatus())}");
                    Console.WriteLine($"Esta tarefa esta na prioridade: {ConvertPriorityToString(task.GetPriority())}");
                    Console.WriteLine($"\n");
                }
            }
        }
        // listar tarefa pendente
        public void ListarTarefaPendente(ref List<Tasks> tasks)
        {
            foreach (Tasks task in tasks)
            {
                if (((Status)task.GetStatus()) == Status.InProgress || ((Status)task.GetStatus()) == Status.Todo)
                {
                    Console.WriteLine($"tarefa:\n");
                    Console.WriteLine($"Nome: {task.GetTitle()}");
                    Console.WriteLine($"Descricao: {task.GetDescription()}");
                    Console.WriteLine($"Data de entrega: {task.GetDate()}");
                    Console.WriteLine($"Esta tarefa esta com o status: {ConvertStatusToString(task.GetStatus())}");
                    Console.WriteLine($"Esta tarefa esta na prioridade: {ConvertPriorityToString(task.GetPriority())}");
                    Console.WriteLine($"\n");
                }
            }
        }
        private string ConvertStatusToString(int status)
        {
            switch ((Status)status)
            {
                case Status.Todo: return "A Fazer";
                case Status.InProgress: return "Em Processo";
                case Status.Done: return "Finalizado";
                default: return "Error";
            }
        }
        private string ConvertPriorityToString(int priority)
        {
            switch ((Priority)priority)
            {
                case Priority.Low: return "Baixo";
                case Priority.Medium: return "Medio";
                case Priority.High: return "Alto";
                default: return "Error";
            }
        }
    }
}
