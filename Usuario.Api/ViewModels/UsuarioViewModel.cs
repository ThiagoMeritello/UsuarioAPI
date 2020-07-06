using System;
using System.ComponentModel.DataAnnotations;


namespace Usuario.Api.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public Guid? Id { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Escolaridade { get; set; }
    }
}
