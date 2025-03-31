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
            Console.WriteLine("* Listar Tarefas/Usuarios");
            Console.WriteLine("* Sair");
            Console.WriteLine("---------------------------------------");
            Console.Write("Escolha uma opção: \n");
            Console.WriteLine("---------------------------------------");
            return Console.ReadLine().Trim().ToLower(); 
        }
        
        static void Cadastrar()
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

            Console.WriteLine("\n✅ Usuário cadastrado com sucesso!");
        }

        static void Listar()
        {
            if (usuarios.Count == 0)
            {
                Console.WriteLine("Nenhum usuário cadastrado ainda!");
                return;
            }
            
            Console.WriteLine("Deseja listar uma tarefa ou um usuário?");
            string select = Console.ReadLine().ToLower();

            if (select == "usuario")
            {
                while (true)
                {
                    {

                    }
                    foreach (var usuario in usuarios)
                    {
                        Console.WriteLine("----------------------");
                        Console.WriteLine($"Nome: {usuario.Nome}");
                        Console.WriteLine($"Email: {usuario.Email}");
                        Console.WriteLine($"Tarefa: {usuario.Tarefa}");
                        Console.WriteLine("----------------------");
                    }
                    Console.Write("Usuarios Foram Verificados? (sim/não)");
 
                }
            }
            else if (select == "tarefa")
            {
                Console.WriteLine("Ainda não está pronto.");
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }

        static void Deletar()
        {
            Console.Write("Digite o nome do usuário que deseja deletar: ");
            string nome = Console.ReadLine();
            
            // O find percorre toda a lista de usuarios e busca pelo o noem do usuario/ 
            Usuario usuarioParaRemover = usuarios.Find(usuario => usuario.Nome == nome);
            if (usuarioParaRemover != null)// se for diferente de vazio / qualquer nome especifico funciona 
            {
                usuarios.Remove(usuarioParaRemover);
                Console.WriteLine("Usuário removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado!");
            }
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
                    Listar();
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
