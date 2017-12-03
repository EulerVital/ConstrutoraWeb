using DAO;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEG
{
    public class nEstacionamento
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Rafael Marques
        /// Motivo: Classe Negocio de Estacionamento
        /// Data Criação: 18/10/2017
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

        public nEstacionamento()
        {

        }
        public static List<eEstacionamento> Estacionamento_GET(eEstacionamento obj)
        {
            try
            {
                dEstacionamento db = new dEstacionamento();
                return db.Estacionamento_GET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Estacionamento_SET(eEstacionamento obj)
        {
            try
            {
                dEstacionamento db = new dEstacionamento();
                return db.Estacionamento_SET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

