using System.ComponentModel.DataAnnotations;

namespace Endereco.Models
{
    public class Endereco
    {
        /* PK */
        [Display(Name = "Codigo", Description = "Código.")]
        public int Id { get; set; }

        [Display(Name = "CEP", Description = "CEP.")]
        [MaxLength(10, ErrorMessage = "A senha deve ter entre 6 e 10 caracteres")]
        [Required(ErrorMessage = "O CEP é obrigatório.")]
        public string CEP { get; set; }

        [Display (Name = "Estado", Description = "Estado")]
        [Required(ErrorMessage = "O estado é obrigatório.")]
        public string Estado { get; set; }

        [Display(Name = "Cidade", Description = "Cidade")]
        [Required(ErrorMessage = "A cidade é obrigatória.")]
        public string Cidade { get; set; }

        [Display(Name = "Bairro", Description = "Bairro")]
        [Required(ErrorMessage = "O bairro é obrigatório.")]
        public string Bairro { get; set; }

        [Display(Name = "Endereco", Description = "Endereco")]
        [Required(ErrorMessage = "O endereço é obrigatório.")]
        public string Logradouro { get; set;}

        [Display(Name = "Complemento", Description = "Complemento")]
        [Required(ErrorMessage = "O complemento é obrigatório.")]
        public string Complemento { get; set; }

        [Display(Name = "Número", Description = "Número")]
        public string Numero { get; set; }
    }
}
