using DAO;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEG
{
    public class nHorario
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Euler Vital
        /// Motivo: Classe Negocio de Horario
        /// Data Criação: 11/11/2017
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

        public nHorario()
        {

        }
        public static List<eHorario> HORARIO_GET(eHorario obj)
        {
            try
            {
                dHorario db = new dHorario();
                return db.Horario_GET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string HORARIO_SET(eHorario obj)
        {
            try
            {
                dHorario db = new dHorario();
                return db.Horario_SET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
