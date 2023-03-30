using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MOD_17E_PROJETO.Models
{
    public class Tecnico
    {
        [Key]
        public int IdTecnico { get; set; }

        [Required(ErrorMessage = "Tem de indicar o nome do utilizador")]
        [StringLength(80)]
        [MinLength(3, ErrorMessage = "Nome muito pequeno. Tem de ter pelo menos 3 letras")]
        [UIHint("Insira o nome do cliente,deve ter pelo menos 3 letras")]
        [Display(Name = "Nome Técnico")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Indique um email")]
        [StringLength(80)]
        [MinLength(3, ErrorMessage = "Email muito pequeno. Tem de ter pelo menos 3 letras")]
        [UIHint("Insira o email do técnico,deve ter pelo menos 3 letras")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Indique uma password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Indique o perfil do utilizador")]
        public int Perfil { get; set; }

        [Display(Name = "Estado da Conta")]
        public bool Estado { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> Perfis { get; set; }

        //public virtual List<Servicos> listaServicos { get; set; }
    }
}