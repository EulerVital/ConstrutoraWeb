using System;
using System.Collections.Generic;
using ENT;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class dCorrespondencia : DBase.DBase
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Rafael Marques
        /// Motivo: Classe Correspondencia de Conexao com a base de dados
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

        #region Atributos
        //IDataReader dr = null;
        //SqlParameter[] param = null;
        #endregion

        public List<eCorrespondencia> Correspondencia_GET(eCorrespondencia obj)
        {
            List<eCorrespondencia> retorno = new List<eCorrespondencia>();
             cmd = new SqlCommand();
             //param = new SqlParameter[3];

            try
            {
                
               // dr = ExecReader("", cmd, param);

               // if (dr != null)
                {
                    //while (dr.Read())
                    {
                        //retorno.Add(Correspondencia(dr));
                    }
                }

                return retorno;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { CloseConnection(); }
        }

        private eCorrespondencia Correspondencia(IDataReader dr)
        {
            eCorrespondencia obj = new eCorrespondencia();

            try
            {
                obj.CorrespondenciaID = GetInt32("CorrespondenciaID", dr).ToString();
                obj.TipoNome = GetString("TipoNome", dr);
                obj.DataHora = (DateTime)GetDateTimeNullable("DataHora", dr);   
                obj.Titulo = GetString("Titulo", dr);
                obj.AvisoDescricao = GetString("AvisoDescricao", dr);
                obj.Morador.MoradorID = GetInt32("MoradorID", dr).ToString();
                obj.TipoCorrespondecia.TipoCorrespondenciaID = GetInt32("CorrespondenciaID", dr).ToString();

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Correspondencia_SET(eCorrespondencia obj)
        {
            string retorno = string.Empty;
            try
            {
                cmd = new SqlCommand();
                //param = new SqlParameter[7];

                if (string.IsNullOrEmpty(obj.CorrespondenciaID))
                    obj.CorrespondenciaID = "0";
                
               // retorno = Convert.ToString(ExecScalar("", cmd, param));
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { CloseConnection(); }

            return retorno;
        }
    }
}


