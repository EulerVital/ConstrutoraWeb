using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class eCorrespondencia
    {
        public string CorrespondenciaID { get; set; }
        public string TipoNome { get; set; }
        public DateTime DataHora { get; set; }
        public string Titulo { get; set; }
        public string AvisoDescricao { get; set; }
        public eMorador Morador { get; set; }
        public eTipoCorrespondencia TipoCorrespondecia { get; set; }



    }
}
