namespace ENT
{
    public class eCidade
    {

        public eCidade()
        {
            Estado = new eEstado();
        }

        public string CidadeID { get; set; }
        public string Nome { get; set; }
        public eEstado Estado { get; set; }
    }
}