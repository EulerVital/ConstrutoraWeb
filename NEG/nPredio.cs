using DAO;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEG
{
    public class nPredio
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Euler Vital
        /// Motivo: Classe Negocio de Predio
        /// Data Criação: 12/08/2017
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
        
        public nPredio()
        {

        }
        public static List<ePredio> Predio_GET(ePredio obj)
        {
            try
            {
                dPredio db = new dPredio();
                return db.Predio_GET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Predio_SET(ePredio obj)
        {
            try
            {
                dPredio db = new dPredio();
                return db.Predio_SET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
