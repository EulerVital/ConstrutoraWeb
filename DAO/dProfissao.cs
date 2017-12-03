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
    public class dProfissao : DBase.DBase
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Euler Vital
        /// Motivo: Classe Profissão de Conexao com a base de dados
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

        public List<eProfissao> Profissao_GET(eProfissao obj)
        {
            List<eProfissao> retorno = new List<eProfissao>();
            cmd = new SqlCommand();
            param = new SqlParameter[4];

            try
            {

                MontarParametro(0, param, ParameterDirection.Input, "@ProfissaoID", obj.ProfissaoID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@Nome", obj.Nome, SqlDbType.VarChar);
                MontarParametro(2, param, ParameterDirection.Input, "@Area", obj.Area, SqlDbType.VarChar);
                MontarParametro(3, param, ParameterDirection.Input, "@Descricao", obj.Descricao, SqlDbType.VarChar);
                
                dr = ExecReader("USP_PROFISSAO_GET", cmd, param);

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        retorno.Add(Profissao(dr));
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

        private eProfissao Profissao(IDataReader dr)
        {
            eProfissao obj = new eProfissao();

            try
            {
                obj.ProfissaoID = GetInt32("ProfissaoID", dr).ToString();
                obj.Nome = GetString("Nome", dr);
                obj.Area = GetString("Area", dr);
                obj.Descricao = GetString("Descricao", dr);

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Profissao_SET(eProfissao obj)
        {
            string retorno = string.Empty;
            try
            {
                cmd = new SqlCommand();
                param = new SqlParameter[4];

                if (string.IsNullOrEmpty(obj.ProfissaoID))
                    obj.ProfissaoID = "0";

                MontarParametro(0, param, ParameterDirection.Input, "@ProfissaoID", obj.ProfissaoID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@Nome", obj.Nome, SqlDbType.VarChar);
                MontarParametro(2, param, ParameterDirection.Input, "@Area", obj.Area, SqlDbType.VarChar);
                MontarParametro(3, param, ParameterDirection.Input, "@Descricao", obj.Descricao, SqlDbType.VarChar);

                retorno = Convert.ToString(ExecScalar("USP_PROFISSAO_SET", cmd, param));
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

        public bool Profissao_DEL(string ProfissaoID)
        {
            bool deletou = false;
            try
            {
                cmd = new SqlCommand();
                param = new SqlParameter[1];

                if (!string.IsNullOrEmpty(ProfissaoID))
                {
                    MontarParametro(0, param, ParameterDirection.Input, "@ProfissaoID", ProfissaoID, SqlDbType.Int);

                    if((ExecNonQuery("USP_PROFISSAO_DEL", cmd, param) > 0))
                    {
                        deletou = true;
                    }
                }

                return deletou;
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
    }
}
