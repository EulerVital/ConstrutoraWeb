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
    public class dVagaEstacionamento : DBase.DBase
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Euler Vital
        /// Motivo: Classe VagaEstacionamento de Conexao com a base de dados
        /// Data Criação: 05/11/2017
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

        public List<eVagaEstacionamento> VAGA_ESTACIONAMENTO_GET(eVagaEstacionamento obj)
        {
            List<eVagaEstacionamento> retorno = new List<eVagaEstacionamento>();
            cmd = new SqlCommand();
            param = new SqlParameter[2];

            try
            {

                MontarParametro(0, param, ParameterDirection.Input, "@VagaEstacionamentoID", obj.VagaEstacionamentoID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@EstacionamentoID", obj.Estacionamento.EstacionamentoID, SqlDbType.Int);

                dr = ExecReader("USP_VAGA_ESTACIONAMENTO_GET", cmd, param);

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        retorno.Add(VagaEstacionamento(dr));
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

        public List<eVagaEstacionamento> VerificarCondominioBloco(string CondominioID, string BlocoID)
        {
            List<eVagaEstacionamento> retorno = new List<eVagaEstacionamento>();
            cmd = new SqlCommand();
            param = new SqlParameter[2];

            try
            {

                MontarParametro(0, param, ParameterDirection.Input, "@CondominioID", CondominioID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@BlocoID", BlocoID, SqlDbType.Int);

                dr = ExecReader("IS_ESTACIONAMENTO_COND_BLOC", cmd, param);

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        eVagaEstacionamento obj = new eVagaEstacionamento();

                        obj.Estacionamento.Bloco.BlocoID = dr["BlocoID"].ToString();
                        obj.Estacionamento.Condominio.CondominioID = dr["CondominioID"].ToString();
                        obj.Estacionamento.Bloco.Nome = dr["NomeBloco"].ToString();
                        obj.Estacionamento.Condominio.Nome = dr["NomeCondominio"].ToString();

                        retorno.Add(obj);
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
            finally
            {
                CloseConnection();
            }
        }

        private eVagaEstacionamento VagaEstacionamento(IDataReader dr)
        {
            eVagaEstacionamento obj = new eVagaEstacionamento();

            try
            {
                obj.VagaEstacionamentoID = GetInt32("VagaEstacionamentoID", dr).ToString();
                obj.NumeroVaga = GetString("NumeroVaga", dr);
                obj.TipoVaga = GetString("TipoVaga", dr);
                obj.ReservadaAlguel = GetBoolean("ReservadaAlguel", dr);
                obj.Estacionamento.EstacionamentoID = GetInt32("EstacionamentoID", dr).ToString();
                obj.Excluido = GetBoolean("Excluido", dr);
                obj.Estacionamento.Nome = GetString("Nome", dr);
                obj.Estacionamento.QtdVagas = GetInt32("QtdVagas", dr);
                obj.Estacionamento.TipoEstacionamento = GetString("TipoEstacionamento", dr);
                obj.Estacionamento.Bloco.QtdPredios = GetInt32("QtdPredios", dr);
                obj.Estacionamento.Bloco.TipoBloco = GetString("TipoBloco", dr);
                obj.Estacionamento.Bloco.StatusAtivo = GetBooleanNullable("StatusAtivo", dr);
                obj.Estacionamento.Condominio.CondominioID = GetInt32("CondominioID", dr).ToString();
                obj.Estacionamento.Condominio.Nome = GetString("NomeCondominio", dr);
                obj.Estacionamento.Condominio.DataFundacao = GetDateTimeNullable("DataFundacao", dr);
                obj.Estacionamento.Condominio.QtdBlocos = GetInt32("QtdBlocos", dr);
                obj.Estacionamento.Condominio.Endereco = GetString("Endereco", dr);
                obj.Estacionamento.Condominio.CEP = GetString("CEP", dr);
                obj.Estacionamento.Condominio.Bairro = GetString("Bairro", dr);
                obj.Estacionamento.Condominio.Cidade.CidadeID = GetInt32("CidadeID", dr).ToString();
                obj.Estacionamento.Condominio.Cidade.Nome = GetString("CidadeNome", dr);
                obj.Estacionamento.Condominio.Excluido = GetBooleanNullable("CondominioExcluido", dr);

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string VAGA_ESTACIONAMENTO_SET(eVagaEstacionamento obj)
        {
            string retorno = string.Empty;
            try
            {
                cmd = new SqlCommand();
                param = new SqlParameter[6];

                if (string.IsNullOrEmpty(obj.VagaEstacionamentoID))
                    obj.VagaEstacionamentoID = "0";

                MontarParametro(0, param, ParameterDirection.Input, "@VagaEstacionamentoID", obj.VagaEstacionamentoID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@NumeroVaga", obj.NumeroVaga, SqlDbType.VarChar);
                MontarParametro(2, param, ParameterDirection.Input, "@TipoVaga", obj.TipoVaga, SqlDbType.Bit);
                MontarParametro(3, param, ParameterDirection.Input, "@ReservadaAlguel", obj.ReservadaAlguel, SqlDbType.Bit);
                MontarParametro(4, param, ParameterDirection.Input, "@EstacionamentoID", obj.Estacionamento.EstacionamentoID, SqlDbType.Int);
                MontarParametro(5, param, ParameterDirection.Input, "@Excluido", obj.Excluido, SqlDbType.Bit);

                retorno = Convert.ToString(ExecScalar("USP_VAGA_ESTACIONAMENTO_SET", cmd, param));
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
