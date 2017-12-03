using DAO;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEG
{
    public class nFuncionalidade
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Rafael Marques
        /// Motivo: Classe Negocio de Funcionalidade
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

        public nFuncionalidade()
        {

        }
        public static List<eFuncionalidade> Funcionalidade_GET(eFuncionalidade obj)
        {
            try
            {
                dFuncionalidade db = new dFuncionalidade();
                return db.Funcionalidade_GET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Funcionalidade_SET(eFuncionalidade obj)
        {
            try
            {
                dFuncionalidade db = new dFuncionalidade();
                return db.Funcionalidade_SET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


