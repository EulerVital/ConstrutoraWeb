using System;
using System.Collections.Generic;
using ENT;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class dCondominio : DBase.DBase
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Euler Vital
        /// Motivo: Classe Condominio de Conexao com a base de dados
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

        #region Atributos
        IDataReader dr = null;
        SqlParameter[] param = null;
        #endregion
        public List<eCondominio> Condominio_GET(eCondominio obj)
        {
            List<eCondominio> retorno = new List<eCondominio>();
            cmd = new SqlCommand();
            param = new SqlParameter[8];

            try
            {

                MontarParametro(0, param, ParameterDirection.Input, "@CondominioID", obj.CondominioID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@Nome", obj.Nome, SqlDbType.VarChar);
                MontarParametro(2, param, ParameterDirection.Input, "@QtdBlocos", obj.QtdBlocos, SqlDbType.Int);
                MontarParametro(3, param, ParameterDirection.Input, "@Endereco", obj.Endereco, SqlDbType.VarChar);
                MontarParametro(4, param, ParameterDirection.Input, "@CEP", obj.CEP, SqlDbType.VarChar);
                MontarParametro(5, param, ParameterDirection.Input, "@Bairro", obj.Bairro, SqlDbType.VarChar);
                MontarParametro(6, param, ParameterDirection.Input, "@CidadeID", obj.Cidade.CidadeID, SqlDbType.VarChar);
                MontarParametro(7, param, ParameterDirection.Input, "@Excluido", obj.Excluido, SqlDbType.Bit);

                dr = ExecReader("USP_CONDOMINIO_GET", cmd, param);

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        retorno.Add(Condominio(dr));
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

        private eCondominio Condominio(IDataReader dr)
        {
            eCondominio obj = new eCondominio();

            try
            {
                obj.CondominioID = GetInt32("CondominioID", dr).ToString();
                obj.Nome = GetString("Nome", dr);
                obj.QtdBlocos = GetInt32("QtdBlocos", dr);
                obj.Endereco = GetString("Endereco", dr);
                obj.CEP = GetString("CEP", dr);
                obj.Bairro = GetString("Bairro", dr);
                obj.Cidade.CidadeID = GetInt32("CidadeID", dr).ToString();
                obj.Cidade.Nome = GetString("CidadeNome", dr);
                obj.Cidade.Estado.EstadoID = GetInt32("EstadoID", dr).ToString();
                obj.Cidade.Estado.Nome = GetString("EstadoNome", dr);
                obj.Cidade.Estado.UF = GetString("UF", dr);
                obj.Excluido = GetBoolean("Excluido", dr);
                obj.DataFundacao = GetDateTimeNullable("DataFundacao", dr);

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Condominio_SET(eCondominio obj)
        {
            string retorno = string.Empty;
            try
            {
                cmd = new SqlCommand();
                param = new SqlParameter[9];

                if (string.IsNullOrEmpty(obj.CondominioID))
                    obj.CondominioID = "0";

                MontarParametro(0, param, ParameterDirection.Input, "@CondominioID", obj.CondominioID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@Nome", obj.Nome, SqlDbType.VarChar);
                MontarParametro(2, param, ParameterDirection.Input, "@QtdBlocos", obj.QtdBlocos, SqlDbType.Int);
                MontarParametro(3, param, ParameterDirection.Input, "@Endereco", obj.Endereco, SqlDbType.VarChar);
                MontarParametro(4, param, ParameterDirection.Input, "@CEP", obj.CEP, SqlDbType.VarChar);
                MontarParametro(5, param, ParameterDirection.Input, "@Bairro", obj.Bairro, SqlDbType.VarChar);
                MontarParametro(6, param, ParameterDirection.Input, "@CidadeID", obj.Cidade.CidadeID, SqlDbType.VarChar);
                MontarParametro(7, param, ParameterDirection.Input, "@Excluido", obj.Excluido, SqlDbType.Bit);
                MontarParametro(8, param, ParameterDirection.Input, "@DataFundacao", obj.DataFundacao, SqlDbType.Date);


                retorno = Convert.ToString(ExecScalar("USP_CONDOMINIO_SET", cmd, param));
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
