using DAO;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEG
{
    public class nVagaEstacionamento
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Euler Vital
        /// Motivo: Classe Negocio de VagaEstacionamento
        /// Data Criação: 05/11/2017
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

        public static List<eVagaEstacionamento> VAGA_ESTACIONAMENTO_GET(eVagaEstacionamento obj)
        {
            try
            {
                dVagaEstacionamento db = new dVagaEstacionamento();
                return db.VAGA_ESTACIONAMENTO_GET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string VAGA_ESTACIONAMENTO_SET(eVagaEstacionamento obj)
        {
            try
            {
                dVagaEstacionamento db = new dVagaEstacionamento();
                return db.VAGA_ESTACIONAMENTO_SET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<eVagaEstacionamento> VerificarCondominioBloco(string CondominioID, string BlocoID)
        {
            try
            {
                dVagaEstacionamento db = new dVagaEstacionamento();
                return db.VerificarCondominioBloco(CondominioID, BlocoID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
