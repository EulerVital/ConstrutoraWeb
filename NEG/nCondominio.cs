using DAO;
using ENT;
using System;
using System.Collections.Generic;

namespace NEG
{
    public class nCondominio
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Euler Vital
        /// Motivo: Classe Negocio de Condominio
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

        public static List<eCondominio> Condominio_GET(eCondominio obj)
        {
            try
            {
                dCondominio db = new dCondominio();
                return db.Condominio_GET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Condominio_SET(eCondominio obj)
        {
            try
            {
                dCondominio db = new dCondominio();
                return db.Condominio_SET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
