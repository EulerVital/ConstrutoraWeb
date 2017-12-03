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
    public class dMorador : DBase.DBase
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Euler Vital
        /// Motivo: Classe Morador de Conexao com a base de dados
        /// Data Criação: 21/10/2017
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

        public List<eMorador> MORADOR_GET(eMorador obj)
        {
            List<eMorador> retorno = new List<eMorador>();
            cmd = new SqlCommand();
            param = new SqlParameter[5];

            try
            {

                MontarParametro(0, param, ParameterDirection.Input, "@MoradorID", obj.MoradorID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@Nome", obj.Nome, SqlDbType.VarChar);
                MontarParametro(2, param, ParameterDirection.Input, "@ApartamentoID", obj.Apartamento.ApartamentoID, SqlDbType.Int);
                MontarParametro(3, param, ParameterDirection.Input, "@VagaEstacionamentoID", obj.VagaEstacionamento.VagaEstacionamentoID, SqlDbType.Int);
                MontarParametro(4, param, ParameterDirection.Input, "@CondominioID", obj.Apartamento.Predio.Bloco.Condominio.CondominioID, SqlDbType.Int);

                dr = ExecReader("USP_MORADOR_GET", cmd, param);

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        retorno.Add(Morador(dr));
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

        private eMorador Morador(IDataReader dr)
        {
            eMorador obj = new eMorador();

            try
            {
                obj.MoradorID = GetInt32("MoradorID", dr).ToString();
                obj.Nome = GetString("Nome", dr);
                obj.RG = GetString("RG", dr);
                obj.CPF = GetString("CPF", dr);
                obj.Email = GetString("Email", dr);
                obj.CaminhoImagem = GetString("CaminhoImagem", dr);
                obj.UltimoNome = GetString("UltimoNome", dr);
                obj.DataNascimento = (DateTime)GetDateTimeNullable("DataNascimento", dr);
                obj.LoginSite = GetString("LoginSite", dr);
                obj.IsResponsavel = GetBoolean("IsResponsavel", dr);
                obj.Senha = GetString("Senha", dr);
                obj.VagaEstacionamento.Estacionamento.EstacionamentoID = GetInt32("EstacionamentoID", dr).ToString();
                obj.VagaEstacionamento.Estacionamento.Nome = GetString("NomeEstacionamento", dr);
                obj.VagaEstacionamento.Estacionamento.QtdVagas = GetInt32("QtdVagas", dr);
                obj.VagaEstacionamento.Estacionamento.TipoEstacionamento = GetString("TipoEstacionamento", dr);
                obj.Apartamento.ApartamentoID = GetInt32("ApartamentoID", dr).ToString();
                obj.Apartamento.NumeroApartamento = GetInt32("NumeroMorador", dr);
                obj.Apartamento.AndarPredio = GetInt32("AndarPredio", dr);
                obj.Apartamento.ValorApartamento = GetDecimal("ValorApartamento", dr);
                obj.Apartamento.TipoEstadia.TipoEstadiaID = GetInt32("TipoEstadiaID", dr).ToString();
                obj.Apartamento.TipoEstadia.Nome = GetString("TipoEstadiaNome", dr).ToString();
                obj.Apartamento.TipoEstadia.ValorFixo = GetDecimalNullable("ValorFixo", dr);
                obj.Apartamento.TipoEstadia.Excluido = GetBooleanNullable("TipoEstadiaExcluido", dr);
                obj.Apartamento.Predio.PredioID = GetInt32("PredioID", dr).ToString();
                obj.Apartamento.Predio.Nome = GetString("NomePredio", dr);
                obj.Apartamento.Predio.QtdApartamentos = GetInt32("QtdApartamentos", dr);
                obj.Apartamento.Predio.Bloco.BlocoID = GetInt32("BlocoID", dr).ToString();
                obj.Apartamento.Predio.Bloco.Nome = GetString("NomeBloco", dr);
                obj.Apartamento.Predio.Excluido = GetBooleanNullable("ExcluidoBloco", dr);
                obj.Apartamento.Predio.Bloco.QtdPredios = GetInt32("QtdPredios", dr);
                obj.Apartamento.Predio.Bloco.TipoBloco = GetString("TipoBloco", dr);
                obj.Apartamento.Predio.Bloco.StatusAtivo = GetBooleanNullable("StatusAtivo", dr);
                obj.Apartamento.Predio.Bloco.Condominio.CondominioID = GetInt32("CondominioID", dr).ToString();
                obj.Apartamento.Predio.Bloco.Condominio.Nome = GetString("NomeCondominio", dr);
                obj.Apartamento.Predio.Bloco.Condominio.DataFundacao = GetDateTimeNullable("DataFundacao", dr);
                obj.Apartamento.Predio.Bloco.Condominio.QtdBlocos = GetInt32("QtdBlocos", dr);
                obj.Apartamento.Predio.Bloco.Condominio.Endereco = GetString("Endereco", dr);
                obj.Apartamento.Predio.Bloco.Condominio.CEP = GetString("CEP", dr);
                obj.Apartamento.Predio.Bloco.Condominio.Bairro = GetString("Bairro", dr);
                obj.Apartamento.Predio.Bloco.Condominio.Cidade.CidadeID = GetInt32("CidadeID", dr).ToString();
                obj.Apartamento.Predio.Bloco.Condominio.Cidade.Nome = GetString("CidadeNome", dr);
                obj.Apartamento.Predio.Bloco.Condominio.Excluido = GetBooleanNullable("CondominioExcluido", dr);
                obj.Apartamento.IsCadAutomatico = GetBoolean("IsCadAutomatico", dr);
                obj.Apartamento.AptAndar = "APT." + obj.Apartamento.NumeroApartamento + "-" + obj.Apartamento.AndarPredio;
                obj.VagaEstacionamento.VagaEstacionamentoID = GetInt32("VagaEstacionamentoID", dr).ToString();
                obj.VagaEstacionamento.NumeroVaga = GetString("NumeroVaga", dr);
                obj.VagaEstacionamento.TipoVaga = GetString("TipoVaga", dr);
                obj.VagaEstacionamento.ReservadaAlguel = GetBoolean("ResevadaAlguel", dr);

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string MORADOR_SET(eMorador obj)
        {
            string retorno = string.Empty;
            try
            {
                cmd = new SqlCommand();
                param = new SqlParameter[13];

                if (string.IsNullOrEmpty(obj.MoradorID))
                    obj.MoradorID = "0";

                if(obj.Apartamento.ApartamentoID != null)
                if (obj.Apartamento.ApartamentoID.Equals("0"))
                    obj.Apartamento.ApartamentoID = null;

                if (obj.VagaEstacionamento.VagaEstacionamentoID != null)
                    if (obj.VagaEstacionamento.VagaEstacionamentoID.Equals("0"))
                        obj.VagaEstacionamento.VagaEstacionamentoID = null;


                MontarParametro(0, param, ParameterDirection.Input, "@MoradorID", obj.MoradorID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@Nome", obj.Nome, SqlDbType.VarChar);
                MontarParametro(2, param, ParameterDirection.Input, "@RG", obj.RG, SqlDbType.VarChar);
                MontarParametro(3, param, ParameterDirection.Input, "@CPF", obj.CPF, SqlDbType.VarChar);
                MontarParametro(4, param, ParameterDirection.Input, "@Email", obj.Email, SqlDbType.VarChar);
                MontarParametro(5, param, ParameterDirection.Input, "@CaminhoImagem", obj.CaminhoImagem, SqlDbType.VarChar);
                MontarParametro(6, param, ParameterDirection.Input, "@ApartamentoID", obj.Apartamento.ApartamentoID, SqlDbType.Int);
                MontarParametro(7, param, ParameterDirection.Input, "@UltimoNome", obj.UltimoNome, SqlDbType.VarChar);
                MontarParametro(8, param, ParameterDirection.Input, "@DataNascimento", obj.DataNascimento, SqlDbType.Date);
                MontarParametro(9, param, ParameterDirection.Input, "@VagaEstacionamentoID", obj.VagaEstacionamento.VagaEstacionamentoID, SqlDbType.Int);
                MontarParametro(10, param, ParameterDirection.Input, "@IsResponsavel", obj.IsResponsavel, SqlDbType.Bit);
                MontarParametro(11, param, ParameterDirection.Input, "@Excluido", obj.Excluido, SqlDbType.Bit);
                MontarParametro(12, param, ParameterDirection.Input, "@Senha", obj.Senha, SqlDbType.VarChar);

                retorno = Convert.ToString(ExecScalar("USP_MORADOR_SET", cmd, param));
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

        public List<eMorador> SiteLogor_GET(eMorador obj)
        {
            List<eMorador> retorno = new List<eMorador>();
            cmd = new SqlCommand();
            param = new SqlParameter[2];

            try
            {

                MontarParametro(0, param, ParameterDirection.Input, "@Login", obj.LoginSite, SqlDbType.VarChar);
                MontarParametro(1, param, ParameterDirection.Input, "@Senha", obj.Senha, SqlDbType.VarChar);

                dr = ExecReader("USP_SITE_LOGAR_GET", cmd, param);

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        retorno.Add(Morador(dr));
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
