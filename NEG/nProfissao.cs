using DAO;
using ENT;
using System;
using System.Collections.Generic;

namespace NEG
{
    public class nProfissao
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Euler Vital
        /// Motivo: Classe Negocio de Profissao
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

        public nProfissao()
        {

        }
        public static List<eProfissao> Profissao_GET(eProfissao obj)
        {
            try
            {
                dProfissao db = new dProfissao();
                return db.Profissao_GET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Profissao_SET(eProfissao obj)
        {
            try
            {
                dProfissao db = new dProfissao();
                return db.Profissao_SET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Profissao_DEL(string ProfissaoID)
        {
            try
            {
                dProfissao db = new dProfissao();
                return db.Profissao_DEL(ProfissaoID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
