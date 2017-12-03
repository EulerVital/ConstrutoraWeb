using DAO;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEG
{
    public class nTelefone
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Euler Vital
        /// Motivo: Classe Negocio de Telefone
        /// Data Criação: 21/10/2017
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

        public nTelefone()
        {

        }
        public static List<eTelefone> Telefone_GET(eTelefone obj)
        {
            try
            {
                dTelefone db = new dTelefone();
                return db.TELEFONE_GET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Telefone_SET(eTelefone obj)
        {
            try
            {
                dTelefone db = new dTelefone();
                return db.TELEFONE_SET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
