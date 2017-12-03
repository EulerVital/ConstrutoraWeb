using DAO;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEG
{
    public class nApartamento
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Euler Vital
        /// Motivo: Classe Negocio de Apartamento
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

        public nApartamento()
        {

        }
        public static List<eApartamento> Apartamento_GET(eApartamento obj, bool? IsApartamentoSemMorador = null)
        {
            try
            {
                dApartamento db = new dApartamento();
                return db.Apartamento_GET(obj, IsApartamentoSemMorador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Apartamento_SET(eApartamento obj)
        {
            try
            {
                dApartamento db = new dApartamento();
                return db.Apartamento_SET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
