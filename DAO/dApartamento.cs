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
    public class dApartamento : DBase.DBase
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Euler Vital
        /// Motivo: Classe Apartamento de Conexao com a base de dados
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

        public List<eApartamento> Apartamento_GET(eApartamento obj, bool? IsApartamentoSemMorador = null)
        {
            List<eApartamento> retorno = new List<eApartamento>();
            cmd = new SqlCommand();
            param = new SqlParameter[4];

            try
            {

                MontarParametro(0, param, ParameterDirection.Input, "@ApartamentoID", obj.ApartamentoID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@PredioID", obj.Predio.PredioID, SqlDbType.Int);
                MontarParametro(2, param, ParameterDirection.Input, "@NomePredio", obj.Predio.Nome, SqlDbType.VarChar);
                MontarParametro(3, param, ParameterDirection.Input, "@IsApartamentoSemMorador", IsApartamentoSemMorador, SqlDbType.Bit);

                dr = ExecReader("USP_APARTAMENTO_GET", cmd, param);

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        retorno.Add(Apartamento(dr));
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

        private eApartamento Apartamento(IDataReader dr)
        {
            eApartamento obj = new eApartamento();

            try
            {
                obj.ApartamentoID = GetInt32("ApartamentoID", dr).ToString();
                obj.NumeroApartamento = GetInt32("NumeroApartamento", dr);
                obj.AndarPredio = GetInt32("AndarPredio", dr);
                obj.ValorApartamento = GetDecimal("ValorApartamento", dr);
                obj.TipoEstadia.TipoEstadiaID = GetInt32("TipoEstadiaID", dr).ToString();
                obj.TipoEstadia.Nome = GetString("TipoEstadiaNome", dr).ToString();
                obj.TipoEstadia.ValorFixo = GetDecimalNullable("ValorFixo", dr);
                obj.TipoEstadia.Excluido = GetBooleanNullable("TipoEstadiaExcluido", dr);
                obj.Predio.PredioID = GetInt32("PredioID", dr).ToString();
                obj.Predio.Nome = GetString("Nome", dr);
                obj.Predio.QtdApartamentos = GetInt32("QtdApartamentos", dr);
                obj.Predio.Bloco.BlocoID = GetInt32("BlocoID", dr).ToString();
                obj.Predio.Bloco.Nome = GetString("NomeBloco", dr);
                obj.Predio.Excluido = GetBooleanNullable("Excluido", dr);
                obj.Predio.Bloco.QtdPredios = GetInt32("QtdPredios", dr);
                obj.Predio.Bloco.TipoBloco = GetString("TipoBloco", dr);
                obj.Predio.Bloco.StatusAtivo = GetBooleanNullable("StatusAtivo", dr);
                obj.Predio.Bloco.Condominio.CondominioID = GetInt32("CondominioID", dr).ToString();
                obj.Predio.Bloco.Condominio.Nome = GetString("NomeCondominio", dr);
                obj.Predio.Bloco.Condominio.DataFundacao = GetDateTimeNullable("DataFundacao", dr);
                obj.Predio.Bloco.Condominio.QtdBlocos = GetInt32("QtdBlocos", dr);
                obj.Predio.Bloco.Condominio.Endereco = GetString("Endereco", dr);
                obj.Predio.Bloco.Condominio.CEP = GetString("CEP", dr);
                obj.Predio.Bloco.Condominio.Bairro = GetString("Bairro", dr);
                obj.Predio.Bloco.Condominio.Cidade.CidadeID = GetInt32("CidadeID", dr).ToString();
                obj.Predio.Bloco.Condominio.Cidade.Nome = GetString("CidadeNome", dr);
                obj.Predio.Bloco.Condominio.Excluido = GetBooleanNullable("CondominioExcluido", dr);
                obj.IsCadAutomatico = GetBoolean("IsCadAutomatico", dr);
                obj.AptAndar = "APT." + obj.NumeroApartamento + "-" + obj.AndarPredio;

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Apartamento_SET(eApartamento obj)
        {
            string retorno = string.Empty;
            try
            {
                cmd = new SqlCommand();
                param = new SqlParameter[7];

                if (string.IsNullOrEmpty(obj.ApartamentoID))
                    obj.ApartamentoID = "0";

                MontarParametro(0, param, ParameterDirection.Input, "@ApartamentoID", obj.ApartamentoID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@NumeroApartamento", obj.NumeroApartamento, SqlDbType.Int);
                MontarParametro(2, param, ParameterDirection.Input, "@TipoEstadiaID", obj.TipoEstadia.TipoEstadiaID, SqlDbType.Int);
                MontarParametro(3, param, ParameterDirection.Input, "@AndarPredio", obj.AndarPredio, SqlDbType.Int);
                MontarParametro(4, param, ParameterDirection.Input, "@ValorApartamento", obj.ValorApartamento, SqlDbType.Decimal);
                MontarParametro(5, param, ParameterDirection.Input, "@PredioID", obj.Predio.PredioID, SqlDbType.Int);
                MontarParametro(6, param, ParameterDirection.Input, "@IsCadAutomatico", obj.IsCadAutomatico, SqlDbType.Bit);

                retorno = Convert.ToString(ExecScalar("USP_APARTAMENTO_SET", cmd, param));
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
