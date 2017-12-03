using System;
using System.Collections.Generic;
using ENT;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class dArea : DBase.DBase
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Euler Vital
        /// Motivo: Classe Area de Conexao com a base de dados
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

        public List<eArea> Area_GET(eArea obj)
        {
            List<eArea> retorno = new List<eArea>();
            cmd = new SqlCommand();
            param = new SqlParameter[3];

            try
            {
                MontarParametro(0, param, ParameterDirection.Input, "@AreaID", obj.AreaID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@IsAreaPaga", obj.IsAreaPaga, SqlDbType.Bit);
                MontarParametro(2, param, ParameterDirection.Input, "@CondominioID", obj.Condominio.CondominioID, SqlDbType.Int);

                dr = ExecReader("USP_AREA_GET", cmd, param);

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        retorno.Add(Area(dr));
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

        private eArea Area(IDataReader dr)
        {
            eArea obj = new eArea();

            try
            {
                obj.AreaID = GetInt32("AreaID", dr).ToString();
                obj.NomeArea = GetString("NomeArea", dr);
                obj.TipoArea = GetString("TipoArea", dr);
                obj.IsAreaPaga = GetBooleanNullable("IsAreaPaga", dr);
                obj.ModoUso = GetString("ModoUso", dr);
                obj.ValorArea = GetDecimal("ValorArea", dr);
                obj.Status = GetBoolean("Status", dr);
                obj.Condominio.CondominioID = GetInt32("CondominioID", dr).ToString();
                obj.Condominio.Nome = GetString("Nome", dr);
                obj.Condominio.QtdBlocos = GetInt32("QtdBlocos", dr);
                obj.Condominio.Endereco = GetString("Endereco", dr);
                obj.Condominio.CEP = GetString("CEP", dr);
                obj.Condominio.Bairro = GetString("Bairro", dr);
                obj.Condominio.Cidade.CidadeID = GetInt32("CidadeID", dr).ToString();
                obj.Condominio.Cidade.Nome = GetString("CidadeNome", dr);
                obj.Condominio.Cidade.Estado.EstadoID = GetInt32("EstadoID", dr).ToString();
                obj.Condominio.Cidade.Estado.Nome = GetString("EstadoNome", dr);
                obj.Condominio.Cidade.Estado.UF = GetString("UF", dr);
                obj.Condominio.Excluido = GetBoolean("Excluido", dr);
                obj.Condominio.DataFundacao = GetDateTimeNullable("DataFundacao", dr);


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Area_SET(eArea obj)
        {
            string retorno = string.Empty;
            try
            {
                cmd = new SqlCommand();
                param = new SqlParameter[8];

                if (string.IsNullOrEmpty(obj.AreaID))
                    obj.AreaID = "0";

                MontarParametro(0, param, ParameterDirection.Input, "@AreaID", obj.AreaID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@NomeArea", obj.NomeArea, SqlDbType.VarChar);
                MontarParametro(2, param, ParameterDirection.Input, "@TipoArea", obj.TipoArea, SqlDbType.VarChar);
                MontarParametro(3, param, ParameterDirection.Input, "@ModoUso", obj.ModoUso, SqlDbType.Char);
                MontarParametro(4, param, ParameterDirection.Input, "@IsAreaPaga", obj.IsAreaPaga, SqlDbType.Bit);
                MontarParametro(5, param, ParameterDirection.Input, "@ValorArea", obj.ValorArea, SqlDbType.Decimal);
                MontarParametro(6, param, ParameterDirection.Input, "@Status", obj.Status, SqlDbType.Bit);
                MontarParametro(7, param, ParameterDirection.Input, "@CondominioID", obj.Condominio.CondominioID, SqlDbType.Int);

                retorno = Convert.ToString(ExecScalar("USP_AREA_SET", cmd, param));
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


