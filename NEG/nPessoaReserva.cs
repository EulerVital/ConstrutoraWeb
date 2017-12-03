using DAO;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEG
{
    public class nPessoaReserva
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Euler Vital
        /// Motivo: Classe Negocio de Pessoa Reserva
        /// Data Criação: 15/11/2017
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

        public static List<ePessoaReserva> PessoaReserva_GET(ePessoaReserva obj)
        {
            try
            {
                dPessoaReserva db = new dPessoaReserva();
                return db.PessoaReserva_GET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string PessoaReserva_SET(ePessoaReserva obj)
        {
            try
            {
                dPessoaReserva db = new dPessoaReserva();
                return db.PessoaReserva_SET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool PessoaReserva_DEL(string PessoaReservaID)
        {
            try
            {
                dPessoaReserva db = new dPessoaReserva();
                return db.PessoaReserva_DEL(PessoaReservaID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
