using System;

namespace Usuario.Business.Models
{
    public class Usuarios : Entity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public TipoEscolaridade Escolaridade { get; set; }
    }
}