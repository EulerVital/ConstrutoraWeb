using DAO;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEG
{
    public class nArea
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Rafael Marques
        /// Motivo: Classe Negocio de Area
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

        public nArea()
        {

        }
        public static List<eArea> Area_GET(eArea obj)
        {
            try
            {
                dArea db = new dArea();
                return db.Area_GET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Area_SET(eArea obj)
        {
            try
            {
                dArea db = new dArea();
                return db.Area_SET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


