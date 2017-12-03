using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class eHorario
    {
        public eHorario()
        {
            Area = new eArea();
        }

        public string HorarioID { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
        public string Horario { get; set; }
        public bool Excluido { get; set; }
        public bool? Reservado { get; set; }
        public eArea Area { get; set; }
    }
}
