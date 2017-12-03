using DAO;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEG
{
    public class nTipoEstadia
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Euler Vital
        /// Motivo: Classe Negocio de TipoEstadia
        /// Data Criação: 17/09/2017
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

        public static List<eTipoEstadia> TipoEstadia_GET(eTipoEstadia obj)
        {
            try
            {
                dTipoEstadia db = new dTipoEstadia();
                return db.TipoEstadia_GET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string TipoEstadia_SET(eTipoEstadia obj)
        {
            try
            {
                dTipoEstadia db = new dTipoEstadia();
                return db.TipoEstadia_SET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
