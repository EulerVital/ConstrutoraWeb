using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class eBloco
    {
        public eBloco()
        {
            Condominio = new eCondominio();
        }

        public string BlocoID { get; set; }
        public string Nome { get; set; }
        public int QtdPredios { get; set; }
        public bool StatusAtivo { get; set; }
        public string TipoBloco { get; set; }
        public eCondominio Condominio { get; set; }
    }
}
