using System;
using System.Collections.Generic;
using ENT;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{

    public class dFuncionalidade : DBase.DBase
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Rafael Marques
        /// Motivo: Classe Funcionalidade de Conexao com a base de dados
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
        IDataReader dr = null;
        SqlParameter[] param = null;
        #endregion

        public List<eFuncionalidade>Funcionalidade_GET(eFuncionalidade obj)
        {
            List<eFuncionalidade> retorno = new List<eFuncionalidade>();
            cmd = new SqlCommand();
            param = new SqlParameter[3];

            try
            {
                
                dr = ExecReader("", cmd, param);

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        retorno.Add(Funcionalidade(dr));
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

        private eFuncionalidade Funcionalidade(IDataReader dr)
        {
            eFuncionalidade obj = new eFuncionalidade();

            try
            {
                obj.FuncionalidadeID = GetInt32("FuncinalidadeID", dr).ToString();
                obj.Descricao = GetString("Descricao", dr);
                obj.AreaFuncionalidade = GetString("AreaFuncionalidade", dr);
                obj.Excluido = GetBoolean("Excluido", dr);
                obj.Usuario.UsuarioID = GetInt32("UsuarioID", dr).ToString();
                   
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Funcionalidade_SET(eFuncionalidade obj)
        {
            string retorno = string.Empty;
            try
            {
                cmd = new SqlCommand();
                //param = new SqlParameter[7];

                if (string.IsNullOrEmpty(obj.FuncionalidadeID))
                    obj.FuncionalidadeID = "0";

                /* MontarParametro(0, param, ParameterDirection.Input, "@ApartamentoID", obj.ApartamentoID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@NumeroApartamento", obj.NumeroApartamento, SqlDbType.Int);
                MontarParametro(2, param, ParameterDirection.Input, "@TipoEstadiaID", obj.TipoEstadia.TipoEstadiaID, SqlDbType.Int);
                MontarParametro(3, param, ParameterDirection.Input, "@AndarPredio", obj.AndarPredio, SqlDbType.Int);
                MontarParametro(4, param, ParameterDirection.Input, "@ValorApartamento", obj.ValorApartamento, SqlDbType.Decimal);
                MontarParametro(5, param, ParameterDirection.Input, "@PredioID", obj.Predio.PredioID, SqlDbType.Int);
                MontarParametro(6, param, ParameterDirection.Input, "@IsCadAutomatico", obj.IsCadAutomatico, SqlDbType.Bit); */

                retorno = Convert.ToString(ExecScalar("", cmd, param));
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

