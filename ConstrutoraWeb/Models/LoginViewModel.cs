using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConstrutoraWeb.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Preencha o campo login com seu nome e ultimo nome ex: fulano.silva")]
        [Display(Name = "Login com o primerio e Ultimo nome ex: fulano.silva: ")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Preencha o campo senha")]
        [Display(Name = "A Senha é seu CPF: ")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}