using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class eFuncionario
    {
        public string FuncionarioId { get; set; }
        public string NomeCompleto { get; set; }
        public string RG { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public int TelefoneFixo { get; set; }
        public int TelefoneCelular { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public eCondominio Condominio { get; set; }
        public eBloco Bloco { get; set; }
        public eProfissao Profissao { get; set; }
        public eUsuario Usuario { get; set; }
    }
}
