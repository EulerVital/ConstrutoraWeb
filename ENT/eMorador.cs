using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class eMorador
    {
        public eMorador()
        {
            ListaTelefone = new List<eTelefone>();
            Visitante = new eVisitante();
            Apartamento = new eApartamento();
            VagaEstacionamento = new eVagaEstacionamento();
        }

        public string MoradorID { get; set; }
        public string Nome { get; set; }
        public string UltimoNome { get; set; }
        public string LoginSite { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string CaminhoImagem { get; set; }
        public bool IsResponsavel { get; set; }
        public bool Excluido { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public List<eTelefone> ListaTelefone { get; set; }
        public eVisitante Visitante { get; set; }
        public eApartamento Apartamento { get; set; }
        public eVagaEstacionamento VagaEstacionamento { get; set; }
    }
}
