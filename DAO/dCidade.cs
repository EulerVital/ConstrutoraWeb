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
    public class dCidade : DBase.DBase
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Euler Vital
        /// Motivo: Classe Cidade de Conexao com a base de dados
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

        public List<eCidade> Cidade_GET(eCidade obj)
        {
            List<eCidade> retorno = new List<eCidade>();
            cmd = new SqlCommand();
            param = new SqlParameter[4];

            try
            {

                MontarParametro(0, param, ParameterDirection.Input, "@CidadeID", obj.CidadeID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@Nome", obj.Nome, SqlDbType.VarChar);
                MontarParametro(2, param, ParameterDirection.Input, "@EstadoID", obj.Estado.EstadoID, SqlDbType.Int);
                MontarParametro(3, param, ParameterDirection.Input, "@UF", obj.Estado.UF, SqlDbType.VarChar);

                dr = ExecReader("USP_CIDADE_GET", cmd, param);

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        retorno.Add(Cidade(dr));
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

        private eCidade Cidade(IDataReader dr)
        {
            eCidade obj = new eCidade();

            try
            {
                obj.CidadeID = GetInt32("Id", dr).ToString();
                obj.Nome = GetString("Nome", dr);
                obj.Estado.EstadoID = GetInt32("EstadoID", dr).ToString();
                obj.Estado.Nome = GetString("EstadoNome", dr);
                obj.Estado.UF = GetString("UF", dr);

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
