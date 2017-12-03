using ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class dTipoTelefone : DBase.DBase
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Euler Vital
        /// Motivo: Classe Tipo Telefone de Conexao com a base de dados
        /// Data Criação: 17/10/2017
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

        public List<eTipoTelefone> TIPO_TELEFONE_GET(eTipoTelefone obj)
        {
            List<eTipoTelefone> retorno = new List<eTipoTelefone>();
            cmd = new SqlCommand();
            param = new SqlParameter[1];

            try
            {

                MontarParametro(0, param, ParameterDirection.Input, "@TipoTelefoneID", obj.TipoTelefoneID, SqlDbType.Int);

                dr = ExecReader("USP_TIPO_TELEFONE_GET", cmd, param);

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        retorno.Add(Tipo_Telefone(dr));
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

        private eTipoTelefone Tipo_Telefone(IDataReader dr)
        {
            eTipoTelefone obj = new eTipoTelefone();

            try
            {
                obj.TipoTelefoneID = GetInt32("TipoTelefoneID", dr).ToString();
                obj.Descricao = GetString("Descricao", dr);
                obj.Excluido = GetBooleanNullable("Excluido", dr);
                
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string TIPO_TELEFONE_SET(eTipoTelefone obj)
        {
            string retorno = string.Empty;
            try
            {
                cmd = new SqlCommand();
                param = new SqlParameter[3];

                if (string.IsNullOrEmpty(obj.TipoTelefoneID))
                    obj.TipoTelefoneID = "0";

                MontarParametro(0, param, ParameterDirection.Input, "@TipoTelefoneID", obj.TipoTelefoneID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@Descricao", obj.Descricao, SqlDbType.VarChar);
                MontarParametro(2, param, ParameterDirection.Input, "@Excluido", obj.Excluido, SqlDbType.Bit);

                retorno = Convert.ToString(ExecScalar("USP_TIPO_TELEFONE_SET", cmd, param));
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
