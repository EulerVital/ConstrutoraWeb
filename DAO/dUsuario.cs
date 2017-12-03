using System;
using System.Collections.Generic;
using ENT;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class dUsuario : DBase.DBase
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Rafael Marques
        /// Motivo: Classe Usuario de Conexao com a base de dados
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

        public List<eUsuario> Usuario_GET(eUsuario obj)
        {
            List<eUsuario> retorno = new List<eUsuario>();
            cmd = new SqlCommand();
            param = new SqlParameter[4];

            try
            {

                MontarParametro(0, param, ParameterDirection.Input, "@UsuarioID", obj.UsuarioID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@CondominioID", obj.Condominio.CondominioID, SqlDbType.Int);
                MontarParametro(2, param, ParameterDirection.Input, "@BlocoID", obj.Bloco.BlocoID, SqlDbType.Int);
                MontarParametro(3, param, ParameterDirection.Input, "@PredioID", obj.Predio.PredioID, SqlDbType.Int);

                dr = ExecReader("USP_USUARIO_GET", cmd, param);

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        retorno.Add(Usuario(dr));
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

        private eUsuario Usuario(IDataReader dr)
        {
            eUsuario obj = new eUsuario();

            try
            {
                obj.UsuarioID = GetInt32("UsuarioId", dr).ToString();
                obj.NomeUser = GetString("NomeUser", dr);
                obj.Senha = GetString("Senha", dr);
                obj.TipoUsuario = GetString("TipoUsuario", dr);
                obj.Excluido = GetBoolean("Excluido", dr);
                obj.Email = GetString("Email", dr);
                obj.Condominio.CondominioID = GetInt32("CondominioID", dr).ToString();
                obj.Condominio.Nome = GetString("NomeCondominio", dr);
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
                obj.Bloco.BlocoID = GetInt32("BlocoID", dr).ToString();
                obj.Bloco.Nome = GetString("NomeBloco", dr);
                obj.Bloco.QtdPredios = GetInt32("QtdPredios", dr);
                obj.Bloco.TipoBloco = GetString("TipoBloco", dr);
                obj.Bloco.StatusAtivo = GetBoolean("StatusAtivo", dr);
                obj.Predio.PredioID = GetInt32("PredioID", dr).ToString();
                obj.Predio.Nome = GetString("NomePredio", dr);
                obj.Predio.QtdApartamentos = GetInt32("QtdApartamentos", dr);

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Usuario_SET(eUsuario obj)
        {
            string retorno = string.Empty;
            try
            {
                cmd = new SqlCommand();
                param = new SqlParameter[9];

                if (string.IsNullOrEmpty(obj.UsuarioID))
                    obj.UsuarioID = "0";

                MontarParametro(0, param, ParameterDirection.Input, "@UsuarioID", obj.UsuarioID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@NomeUser", obj.NomeUser, SqlDbType.VarChar);
                MontarParametro(2, param, ParameterDirection.Input, "@Senha", obj.Senha, SqlDbType.VarChar);
                MontarParametro(3, param, ParameterDirection.Input, "@CondominioID", obj.Condominio.CondominioID, SqlDbType.Int);
                MontarParametro(4, param, ParameterDirection.Input, "@TipoUsuario", obj.TipoUsuario, SqlDbType.Char);
                MontarParametro(5, param, ParameterDirection.Input, "@Email", obj.Email, SqlDbType.VarChar);
                MontarParametro(6, param, ParameterDirection.Input, "@BlocoID", obj.Bloco.BlocoID, SqlDbType.Int);
                MontarParametro(7, param, ParameterDirection.Input, "@PredioID", obj.Predio.PredioID, SqlDbType.Int);
                MontarParametro(8, param, ParameterDirection.Input, "@Excluido", obj.Excluido, SqlDbType.Bit);

                retorno = Convert.ToString(ExecScalar("USP_USUARIO_SET", cmd, param));
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

        public string Usuario_Logar(string nomeUser, string senha)
        {
            cmd = new SqlCommand();
            param = new SqlParameter[2];
            string retorno = string.Empty;

            try
            {

                MontarParametro(0, param, ParameterDirection.Input, "@NomeUser", nomeUser, SqlDbType.VarChar);
                MontarParametro(1, param, ParameterDirection.Input, "@Senha", senha, SqlDbType.VarChar);

                dr = ExecReader("USP_LOGAR_GET", cmd, param);

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        retorno = dr["UsuarioID"].ToString();
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
    }
}


