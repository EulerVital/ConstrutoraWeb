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
    public class dTelefone : DBase.DBase
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

        public List<eTelefone> TELEFONE_GET(eTelefone obj)
        {
            List<eTelefone> retorno = new List<eTelefone>();
            cmd = new SqlCommand();
            param = new SqlParameter[4];

            try
            {

                MontarParametro(0, param, ParameterDirection.Input, "@TelefoneID", obj.TelefoneID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@TipoTelefoneID", obj.TipoTelefone.TipoTelefoneID, SqlDbType.Int);
                MontarParametro(2, param, ParameterDirection.Input, "@Contato", obj.Contato, SqlDbType.Int);
                MontarParametro(3, param, ParameterDirection.Input, "@MoradorID", obj.Morador.MoradorID, SqlDbType.Int);

                dr = ExecReader("USP_TELEFONE_GET", cmd, param);

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        retorno.Add(Telefone(dr));
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

        private eTelefone Telefone(IDataReader dr)
        {
            eTelefone obj = new eTelefone();

            try
            {
                obj.TelefoneID = GetInt32("TelefoneID", dr).ToString();
                obj.Contato = GetString("Contato", dr);
                obj.Excluido = GetBooleanNullable("Excluido", dr);
                obj.TipoTelefone.TipoTelefoneID = GetInt32("TipoTelefoneID", dr).ToString();
                obj.TipoTelefone.Descricao = GetString("TipoTelefone", dr);
                obj.TipoTelefone.Excluido = GetBooleanNullable("TipoTelefoneExcluido", dr);
                obj.Morador.MoradorID = GetInt32("MoradorID", dr).ToString();
                obj.Morador.Nome = GetString("Nome", dr);
                obj.Morador.UltimoNome = GetString("UltimoNome", dr);


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string TELEFONE_SET(eTelefone obj)
        {
            string retorno = string.Empty;
            try
            {
                cmd = new SqlCommand();
                param = new SqlParameter[5];

                if (string.IsNullOrEmpty(obj.TelefoneID))
                    obj.TelefoneID = "0";

                MontarParametro(0, param, ParameterDirection.Input, "@TelefoneID", obj.TelefoneID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@Contato", obj.Contato, SqlDbType.VarChar);
                MontarParametro(2, param, ParameterDirection.Input, "@TipoTelefoneID", obj.TipoTelefone.TipoTelefoneID, SqlDbType.Int);
                MontarParametro(3, param, ParameterDirection.Input, "@Excluido", obj.Excluido, SqlDbType.Bit);
                MontarParametro(4, param, ParameterDirection.Input, "@MoradorID", obj.Morador.MoradorID, SqlDbType.Int);

                retorno = Convert.ToString(ExecScalar("USP_TELEFONE_SET", cmd, param));
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
