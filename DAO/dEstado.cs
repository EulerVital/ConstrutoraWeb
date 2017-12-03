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
    public class dEstado : DBase.DBase
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Euler Vital
        /// Motivo: Classe Estado de Conexao com a base de dados
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

        public List<eEstado> Estado_GET(eEstado obj)
        {
            List<eEstado> retorno = new List<eEstado>();
            cmd = new SqlCommand();
            param = new SqlParameter[3];

            try
            {

                MontarParametro(0, param, ParameterDirection.Input, "@EstadoID", obj.EstadoID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@Nome", obj.Nome, SqlDbType.VarChar);
                MontarParametro(2, param, ParameterDirection.Input, "@UF", obj.UF, SqlDbType.VarChar);

                dr = ExecReader("USP_ESTADO_GET", cmd, param);

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        retorno.Add(Estado(dr));
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

        private eEstado Estado(IDataReader dr)
        {
            eEstado obj = new eEstado();

            try
            {
                obj.EstadoID = GetInt32("Id", dr).ToString();
                obj.Nome = GetString("Nome", dr);
                obj.UF = GetString("UF", dr);

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
