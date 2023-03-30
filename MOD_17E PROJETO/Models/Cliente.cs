using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MOD_17E_PROJETO.Models
{
    public class Cliente
    {
        //Chave Primaria
        [Key]
        public int ClienteID { get; set; }

        //Campo nome
        [Required(ErrorMessage = "Tem de indicar o nome do cliente")]
        [StringLength(80)]
        [MinLength(3, ErrorMessage = "Nome muito pequeno. Tem de ter pelo menos 3 letras")]
        [UIHint("Insira o nome do cliente,deve ter pelo menos 3 letras")]
        public string Nome { get; set; }

        //Campo MORADA
        [Required(ErrorMessage = "Tem de indicar a morada do cliente")]
        [StringLength(80)]
        [MinLength(3, ErrorMessage = "Morada muito pequeno. Tem de ter pelo menos 3 letras")]
        [UIHint("Insira o nome da Morada,deve ter pelo menos 3 letras")]
        public string Morada { get; set; }

        //Campo CP
        [Required(ErrorMessage = "Tem de indicar o Código Postal do cliente")]
        [StringLength(8)]
        [MinLength(8, ErrorMessage = "Código Postal tem de ter 8 letras")]
        [UIHint("Insira o Código Postal")]
        [Display(Name = "Código Postal")]
        public string CP { get; set; }

        //Campo EMAIL
        [Required(ErrorMessage = "Tem de indicar um email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //Campo TELEFONE
        [Required(ErrorMessage = "Tem de indicar um telefone cliente")]
        [StringLength(15)]
        [MinLength(9, ErrorMessage = "O telefone tem de ter pelo menos 9 letras")]
        public string Telefone { get; set; }

        //Campo Data
        [Required(ErrorMessage = "Tem de indicar a data de nascimento do cliente")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        //Lista de Serviços
        //public virtual List<Servico> listaServicos { get; set; }

    }
}