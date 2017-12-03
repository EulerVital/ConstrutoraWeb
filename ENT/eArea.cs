    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class eArea
    {
        public eArea()
        {
            Condominio = new eCondominio();
        }
        public string AreaID { get; set; }
        public string NomeArea { get; set; }
        public string TipoArea { get; set; }
        public bool? IsAreaPaga { get; set; }
        public decimal ValorArea { get; set; }
        public string ModoUso { get; set; }
        public bool Status { get; set; }
        public string DescricaoStatus { get; set; }
        public eCondominio Condominio { get; set; }
    }
}
