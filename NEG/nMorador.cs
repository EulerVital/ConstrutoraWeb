using DAO;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEG
{
    public class nMorador
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Euler Vital
        /// Motivo: Classe Negocio de Morador
        /// Data Criação: 22/10/2017
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

        public nMorador()
        {

        }
        public static List<eMorador> MORADOR_GET(eMorador obj)
        {
            try
            {
                dMorador db = new dMorador();
                return db.MORADOR_GET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string MORADOR_SET(eMorador obj)
        {
            try
            {
                dMorador db = new dMorador();
                return db.MORADOR_SET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<eMorador> SITE_LOGAR(eMorador obj)
        {
            try
            {
                dMorador db = new dMorador();
                return db.SiteLogor_GET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
