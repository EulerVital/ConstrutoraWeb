using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class eReservarArea
    {
        public eReservarArea()
        {
            Morador = new eMorador();
            Area = new eArea();
        }

        public string ReservaAreaID { get; set; }
        public DateTime DataReserva { get; set; }
        public eMorador Morador{ get; set; }
        public eArea Area { get; set; }
    }
}
