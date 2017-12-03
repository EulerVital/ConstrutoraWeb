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
    public class dTipoEstadia : DBase.DBase
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Euler Vital
        /// Motivo: Classe Tipo Estadia de Conexao com a base de dados
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

        #region Atributos
        IDataReader dr = null;
        SqlParameter[] param = null;
        #endregion

        public List<eTipoEstadia> TipoEstadia_GET(eTipoEstadia obj)
        {
            List<eTipoEstadia> retorno = new List<eTipoEstadia>();
            cmd = new SqlCommand();
            param = new SqlParameter[2];

            try
            {

                MontarParametro(0, param, ParameterDirection.Input, "@TipoEstadiaID", obj.TipoEstadiaID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@Nome", obj.Nome, SqlDbType.VarChar);

                dr = ExecReader("USP_TIPOESTADIA_GET", cmd, param);

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        retorno.Add(TipoEstadia(dr));
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

        private eTipoEstadia TipoEstadia(IDataReader dr)
        {
            eTipoEstadia obj = new eTipoEstadia();

            try
            {
                obj.TipoEstadiaID = GetInt32("TipoEstadiaID", dr).ToString();
                obj.Nome = GetString("Nome", dr);
                obj.ValorFixo = GetDecimalNullable("ValorFixo", dr);
                obj.Excluido = GetBooleanNullable("Excluido", dr);

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string TipoEstadia_SET(eTipoEstadia obj)
        {
            string retorno = string.Empty;
            try
            {
                cmd = new SqlCommand();
                param = new SqlParameter[4];

                if (string.IsNullOrEmpty(obj.TipoEstadiaID))
                    obj.TipoEstadiaID = "0";

                MontarParametro(0, param, ParameterDirection.Input, "@TipoEstadiaID", obj.TipoEstadiaID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@Nome", obj.Nome, SqlDbType.VarChar);
                MontarParametro(2, param, ParameterDirection.Input, "@ValorFixo", obj.ValorFixo, SqlDbType.Int);
                MontarParametro(3, param, ParameterDirection.Input, "@Excluido", obj.Excluido, SqlDbType.Bit);

                retorno = Convert.ToString(ExecScalar("USP_TIPOESTADIA_SET", cmd, param));
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
