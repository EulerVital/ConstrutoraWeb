using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class ePessoaReserva
    {
        public ePessoaReserva()
        {
            ReservaArea = new eReservarArea();
        }

        public string PessoaReservaID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public bool IsMenorIdade { get; set; }
        public string ResponsavelID { get; set; }
        public string TipoPagamento { get; set; }
        public eReservarArea ReservaArea { get; set; }
        
    }
}
