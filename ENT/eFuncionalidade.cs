using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
   public class eFuncionalidade
    {
        public string FuncionalidadeID { get; set; }
        public string Descricao { get; set; }
        public string AreaFuncionalidade { get; set; }
        public bool Excluido { get; set; }
        public eUsuario Usuario { get; set; }

    }
}
