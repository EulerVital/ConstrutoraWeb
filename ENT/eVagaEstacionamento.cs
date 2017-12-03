using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class eVagaEstacionamento
    {
        public eVagaEstacionamento()
        {
            Estacionamento = new eEstacionamento();
        }

        public string VagaEstacionamentoID { get; set; }
        public string NumeroVaga { get; set; }
        public string TipoVaga { get; set; }
        public bool ReservadaAlguel { get; set; }
        public bool Excluido { get; set; }
        public eEstacionamento Estacionamento { get; set; }
    }
}
