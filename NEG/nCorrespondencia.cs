using DAO;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEG
{
    public class nCorrespondencia
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Rafael Marques
        /// Motivo: Classe Negocio de Apartamento
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

        public static List<eCorrespondencia> Correspondencia_GET(eCorrespondencia obj)
        {
            try
            {
                dCorrespondencia db = new dCorrespondencia();
                return db.Correspondencia_GET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Correspondencia_SET(eCorrespondencia obj)
        {
            try
            {
                dCorrespondencia db = new dCorrespondencia();
                return db.Correspondencia_SET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


