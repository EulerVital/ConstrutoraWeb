using ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConstrutoraWeb.Models
{
    public class HomeViewModel
    {
        [Display(Name = "Codigo: ")]
        public string MoradorID { get; set; }
        [Display(Name = "Nome: ")]
        public string Nome { get; set; }
        [Display(Name = "Sobrenome: ")]
        public string UltimoNome { get; set; }
        public string LoginSite { get; set; }

        [Required(ErrorMessage = "Senha Obrigatória")]
        [StringLength(20, ErrorMessage = "A senha deve ter entre 5 a 20 caracateres." , MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha: ")]
        public string Senha { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        [Display(Name = "Email: ")]
        public string Email { get; set; }
        public string CaminhoImagem { get; set; }
        public bool IsResponsavel { get; set; }
        public bool Excluido { get; set; }

        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        [Display(Name = "Data de Nascimento: ")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Data de Nascimento: ")]
        public string DataNasci { get; set; }

        public eApartamento Apartamento { get; set; }
        public eVagaEstacionamento VagaEstacionamento  {get; set;}
        public eVisitante Visitante { get; set; }
        public List<eMorador> ListaMoradores {get; set;}
    }
}