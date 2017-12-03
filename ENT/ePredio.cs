using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class ePredio
    {
        public ePredio()
        {
            Bloco = new eBloco();
        }
        public string PredioID { get; set; }
        public string Nome { get; set; }
        public int QtdApartamentos { get; set; }
        public bool Excluido { get; set; }
        public eBloco Bloco { get; set; }
    }
}
