using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEG
{
    public class nVisitante 
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Euler Vital
        /// Motivo: Classe Negocio de Visitante
        /// Data Criação: 30/10/2017
        /// ********Alteração************
        /// Autor: 
        /// Motivo:
        /// Data Criação:
        /// ********Alteração************
        /// Autor: 
        /// Motivo:
        /// Data Criação:
        /// ********Alteração************
        /// Autor: 
        /// Motivo:
        /// Data Criação:
        /// </summary>
        #endregion

        public nVisitante()
        {

        }
        public static List<eVisitante> Visitante_GET(eVisitante obj)
        {
            try
            {
                //dVisitante db = new dVisitante();
                return Visitante_GET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Visitante_SET(eVisitante obj)
        {
            try
            {
                return Visitante_SET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

