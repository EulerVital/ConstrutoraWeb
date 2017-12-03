using DAO;
using ENT;
using System;
using System.Collections.Generic;

namespace NEG
{
    public class nReservarArea
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Rafael Marques
        /// Motivo: Classe Negocio de Reserva de Area
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

        public nReservarArea()
        {

        }
        public static List<eReservarArea> ReservaArea_GET(eReservarArea obj)
        {
            try
            {
                dReservarArea db = new dReservarArea();
                return db.ReservarArea_GET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ReservarArea_SET(eReservarArea obj)
        {
            try
            {
                dReservarArea db = new dReservarArea();
                return db.ReservarArea_SET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool VerificarDataHoraReserva(string areaId, string horarioId, DateTime data)
        {
            try
            {
                dReservarArea db = new dReservarArea();
                return db.VerificaDataHoraReserva(areaId, horarioId, data);

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public static bool ReservarArea_DEL()
        {
            try
            {
                dReservarArea db = new dReservarArea();
                return db.ReservaArea_DEL(null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ReservarArea_DEL(string ReservaAreaID)
        {
            try
            {
                dReservarArea db = new dReservarArea();
                return db.ReservaArea_DEL(ReservaAreaID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


