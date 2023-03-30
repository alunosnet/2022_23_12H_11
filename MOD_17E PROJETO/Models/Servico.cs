using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MOD_17E_PROJETO.Models
{
    public class Servico
    {
        [Key]
        public int IdServico { get; set; }

        //campo descrição
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Tem de descrever o serviço.")]
        [StringLength(250)]
        [MinLength(5, ErrorMessage = "Descrição muito pequena. Tem de ter pelo menos 5 letras")]
        [UIHint("Insira a descrição do serviço, deve ter pelo menos 5 letras")]
        public string descricao { get; set; }

        //Campo data criação
        [Display(Name = "Data Criação")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Tem de indicar a data de entrada")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime data_criado { get; set; }

        //Campo Data Começo
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime data_começou { get; set; }

        //Campo data Conclusão
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime data_Acabou { get; set; }

        //Campo valor
        [Display(Name = "Pago")]
        [DataType(DataType.Currency)]
        public decimal valor_pago { get; set; }

        //Campo estado
        [Display(Name = "Estado do serviço")]
        public int Estado { get; set; }
        // 1 - POR MARCAR / 2 - INICIADO / 3 - FINALIZADO 

        /// <summary>
        /// CHAVES ESTRANGEIRAS
        /// </summary>
        [ForeignKey("cliente")]
        [Display(Name = "Cliente")]
        [Required(ErrorMessage = " Tem de indicar o CLIENTE")]
        public int ClienteID { get; set; }
        public Cliente cliente { get; set; }


        [ForeignKey("tecnico")]
        [Display(Name = "Técnico")]
        public int? IdTecnico { get; set; }
        public Tecnico tecnico { get; set; }

        public Servico() { data_criado = DateTime.Now; }

    }
}