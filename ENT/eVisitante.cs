using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
   public class eVisitante
    {
        public string VisitanteID { get; set; }
        public string NomeCompleto { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Entrada { get; set; }
        public string Saida { get; set; }
        public int QtdDias { get; set; }
        public int Mes { get; set; }
        public string Semana { get; set; }
        public string TempoPermanencia { get; set; }
        public int Ano { get; set; }
        public eEstacionamento Estacionamento { get; set; }
        public eTelefone Telefone { get; set; }
    }
}
