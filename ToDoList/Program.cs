using System;
using UsuarioNamespace;
using System.Collections.Generic;

namespace ToDoList
{
    class Program
    { 
        static List<Usuario> usuarios = new List<Usuario>(); 
        static string Menu()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("O que Deseja Selecionar?");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("* Cadastrar um novo Responsável/Tarefa");
            Console.WriteLine("* Deletar uma tarefa");
            Console.WriteLine("* Atualizar status de uma tarefa");
            Console.WriteLine("* listar Tarefas/Usuarios");
            Console.WriteLine("* Sair");
            Console.WriteLine("---------------------------------------");
            Console.Write("Escolha uma opção: \n");
            Console.WriteLine("---------------------------------------");
            return Console.ReadLine().Trim().ToLower(); 
        }
        
        static void Cadastrar() //função concluida 
        {
            Console.WriteLine("Bem-vindo ao sistema de cadastro de usuário!");
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o email: ");
            string email = Console.ReadLine();

            Console.Write("Digite a tarefa: ");
            string tarefa = Console.ReadLine();

            Usuario novoUsuario = new Usuario(nome, email, tarefa);
            usuarios.Add(novoUsuario);

            Console.WriteLine("\nInformações do Usuário:");
            Console.WriteLine($"Nome: {novoUsuario.Nome}");
            Console.WriteLine($"Email: {novoUsuario.Email}");
            Console.WriteLine($"Tarefa: {novoUsuario.Tarefa}");
            Console.WriteLine("\n✅ Usuário cadastrado com sucesso!");

        }

        static string Listar(string menu) // função concluida 
        {
            Console.Write("Deseja Listar uma  tarefa ou um usuario? ");
            string Select = Console.ReadLine();
            if (Select == "usuario")
            {
                foreach (var usuario in usuarios)
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine($"Nome: {usuario.Nome}");
                    Console.WriteLine($"Email: {usuario.Email}");
                    Console.WriteLine($"Tarefa: {usuario.Tarefa}");
                    Console.WriteLine("----------------------");
                    Console.WriteLine("Deseja Conntinuar?, sim ou não ? ");
                    string Select2 = Console.ReadLine();
                    if (Select2 == "sim")
                    {
                        Console.WriteLine("Ok, continuando...");
                    }
                    else
                    {
                        break;
                    }

                }
            }
            else if (Select == "tarefa")
            {
                Console.WriteLine("Ainda não ta pronto ");
            }

            return menu;
        }

        static void Deletar()
        {
            Console.Write("Digite a tarefa que deseja deletar: ");
            Console.ReadLine(); 
        }

        static void Atualizar()
        {
            Console.Write("Digite o nome do Responsável: ");
            Console.ReadLine(); 
        }

        static void SelectFunction(string menu)
        {
            switch (menu)
            {
                case "cadastrar":
                    Cadastrar();
                    break;
                case "listar":
                    Listar(menu);
                    break;
                case "deletar":
                    Deletar();
                    break;
                case "atualizar":
                    Atualizar();
                    break;
                case "sair":
                    Console.WriteLine("Saindo do sistema...");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
        static void Main()
        {
            string menu;
            do
            {
                menu = Menu();
                SelectFunction(menu);
            } while (menu != "sair");
        }
    }
}

