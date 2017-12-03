using ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConstrutoraWeb.Models
{
    public class ReservaAreaViewModel
    {
        public ReservaAreaViewModel()
        {

        }

        public eReservarArea ReservaArea { get; set; }        
        public eHorario Horario { get; set; }
    }
}