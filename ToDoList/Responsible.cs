namespace UsuarioNamespace
{
    class Usuario
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Tarefa { get; }

        public Usuario(string nome, string email, string tarefa)
        {
            Nome = nome;
            Email = email;
            Tarefa = tarefa;
        }
    }
}