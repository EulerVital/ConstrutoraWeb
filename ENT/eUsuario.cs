using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class eUsuario
    {
        public eUsuario()
        {
            Condominio = new eCondominio();
            Bloco = new eBloco();
            Predio = new ePredio();
        }

        public string UsuarioID { get; set; }
        public string NomeUser { get; set; }
        public string Senha { get; set; }
        public string TipoUsuario { get; set; }
        public bool Excluido { get; set; }
        public String Email { get; set; }
        public eCondominio Condominio { get; set; }
        public eBloco Bloco { get; set; }
        public ePredio Predio { get; set; }
    }
}
