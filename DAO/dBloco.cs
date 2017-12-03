using ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class dBloco : DBase.DBase
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Euler Vital
        /// Motivo: Classe Bloco de Conexao com a base de dados
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

        public List<eBloco> Bloco_GET(eBloco obj)
        {
            List<eBloco> retorno = new List<eBloco>();
            cmd = new SqlCommand();
            param = new SqlParameter[7];

            try
            {

                MontarParametro(0, param, ParameterDirection.Input, "@BlocoID", obj.BlocoID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@Nome", obj.Nome, SqlDbType.VarChar);
                MontarParametro(2, param, ParameterDirection.Input, "@QtdPredios", obj.QtdPredios, SqlDbType.Int);
                MontarParametro(3, param, ParameterDirection.Input, "@TipoBloco", obj.TipoBloco, SqlDbType.Char);
                MontarParametro(4, param, ParameterDirection.Input, "@StatusAtivo", obj.StatusAtivo, SqlDbType.Bit);
                MontarParametro(5, param, ParameterDirection.Input, "@CondominioID", obj.Condominio.CondominioID, SqlDbType.Int);
                MontarParametro(6, param, ParameterDirection.Input, "@NomeCondominio", obj.Condominio.Nome, SqlDbType.VarChar);

                dr = ExecReader("USP_BLOCO_GET", cmd, param);

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        retorno.Add(Bloco(dr));
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

        private eBloco Bloco(IDataReader dr)
        {
            eBloco obj = new eBloco();

            try
            {
                obj.BlocoID = GetInt32("BlocoID", dr).ToString();
                obj.Nome = GetString("Nome", dr);
                obj.QtdPredios = GetInt32("QtdPredios", dr);
                obj.TipoBloco = GetString("TipoBloco", dr);
                obj.StatusAtivo = GetBooleanNullable("StatusAtivo", dr);
                obj.Condominio.CondominioID = GetInt32("CondominioID", dr).ToString();
                obj.Condominio.Nome = GetString("NomeCondominio", dr);
                obj.Condominio.QtdBlocos = GetInt32("QtdBlocos", dr);
                obj.Condominio.Endereco = GetString("Endereco", dr);
                obj.Condominio.CEP = GetString("CEP", dr);
                obj.Condominio.Bairro = GetString("Bairro", dr);
                obj.Condominio.Cidade.CidadeID = GetInt32("CidadeID", dr).ToString();
                obj.Condominio.Cidade.Nome = GetString("CidadeNome", dr);
                obj.Condominio.Excluido = GetBoolean("Excluido", dr);

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Bloco_SET(eBloco obj)
        {
            string retorno = string.Empty;
            try
            {
                cmd = new SqlCommand();
                param = new SqlParameter[6];

                if (string.IsNullOrEmpty(obj.BlocoID))
                    obj.BlocoID = "0";

                MontarParametro(0, param, ParameterDirection.Input, "@BlocoID", obj.BlocoID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@Nome", obj.Nome, SqlDbType.VarChar);
                MontarParametro(2, param, ParameterDirection.Input, "@QtdPredios", obj.QtdPredios, SqlDbType.Int);
                MontarParametro(3, param, ParameterDirection.Input, "@TipoBloco", obj.TipoBloco, SqlDbType.Char);
                MontarParametro(4, param, ParameterDirection.Input, "@StatusAtivo", obj.StatusAtivo, SqlDbType.Bit);
                MontarParametro(5, param, ParameterDirection.Input, "@CondominioID", obj.Condominio.CondominioID, SqlDbType.Int);

                retorno = Convert.ToString(ExecScalar("USP_BLOCO_SET", cmd, param));
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
