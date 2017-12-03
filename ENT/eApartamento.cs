    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class eApartamento
    {
        public eApartamento()
        {
            Predio = new ePredio();
            TipoEstadia = new eTipoEstadia();
        }

        public string ApartamentoID { get; set;}
        public int NumeroApartamento { get; set;}
        public eTipoEstadia TipoEstadia { get; set;}
        public int AndarPredio { get; set; }
        public decimal ValorApartamento { get; set; }
        public ePredio Predio { get; set; }
        public bool IsCadAutomatico { get; set; }
        public string AptAndar { get; set; }
    }
}
