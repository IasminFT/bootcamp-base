using System;

namespace Tarefas.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        public string? Email { get; set; }        

        public string? Senha { get; set; }  

        public bool Nome { get; set; }

        public bool Ativo { get; set; }
    }

}
