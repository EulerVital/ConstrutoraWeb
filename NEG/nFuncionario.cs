using DAO;
using ENT;
using NEG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEG
{
    public class nFuncionario
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Rafael Marques
        /// Motivo: Classe Negocio de funcionario 
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

        public nFuncionario()
        {

        }
        public static List<eFuncionario> Funcionario_GET(eFuncionario obj)
        {
            try
            {
                dFuncionario db = new dFuncionario();
                return db.Funcionario_GET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Funcionario_SET(eFuncionario obj)
        {
            try
            {
                dFuncionario db = new dFuncionario();
                return db.Funcionario_SET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


