using ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConstrutoraWeb.Models
{
    public class ReservaAreaViewModel
    {
        public ReservaAreaViewModel()
        {
            ReservaArea = new eReservarArea();
            DataReserva = DateTime.Now.Date.AddDays(1).ToString("dd/MM/yyyy");
            Horario = new eHorario();
        }

        [Key()]
        public string ReservaAreaID { get; set; }
        [Display(Name = "Data da Reserva")]
        [Required(ErrorMessage = "Escolha a data de reserva")]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public string DataReserva { get; set; }
        public string AreaID { get;set; }
        public string MoradorID { get; set; }
        public string HorarioID { get; set; }
        public eHorario Horario { get; set; }
        public IEnumerable<SelectListItem> ListaAreas { get; set; }
        public IEnumerable<SelectListItem> ListaHorario { get; set; }
        public eReservarArea ReservaArea { get; set; }
        public List<ePessoaReserva> ListaPessoas { get; set; }
    }
}