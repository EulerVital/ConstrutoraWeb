using System;

namespace ENT
{
    public class eCondominio
    {
        public eCondominio()
        {
            Cidade = new eCidade();
        }

        public string CondominioID { get; set; }
        public string Nome { get; set; }
        public int QtdBlocos { get; set; }
        public string Endereco { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public bool Excluido { get; set; }
        public DateTime? DataFundacao { get; set; } 
        public eCidade Cidade { get; set; }
    }
}