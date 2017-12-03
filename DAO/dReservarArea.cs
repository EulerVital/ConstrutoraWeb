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
    public class dReservarArea : DBase.DBase
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Rafael Marques
        /// Motivo: Classe Reserva de Area de Conexao com a base de dados
        /// Data Criação: 30/10/2017
        /// ********Alteração************
        /// Autor: Euler Vital
        /// Motivo: Add procedure
        /// Data Alteração: 15/11/2017 
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

        public List<eReservarArea> ReservarArea_GET(eReservarArea obj)
        {
            List<eReservarArea> retorno = new List<eReservarArea>();
            cmd = new SqlCommand();
            param = new SqlParameter[3];

            try
            {

                MontarParametro(0, param, ParameterDirection.Input, "@ReservaAreaID", obj.ReservaAreaID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@MoradorID", obj.Morador.MoradorID, SqlDbType.Int);
                MontarParametro(2, param, ParameterDirection.Input, "@AreaID", obj.Area.AreaID, SqlDbType.Int);

                dr = ExecReader("USP_RESERVAR_AREA_GET", cmd, param);

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        retorno.Add(ReservarArea(dr));
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

        private eReservarArea ReservarArea(IDataReader dr)
        {
            eReservarArea obj = new eReservarArea();

            try
            {
                obj.ReservaAreaID = GetInt32("ReservaAreaID", dr).ToString();
                obj.DataReserva = (DateTime)GetDateTimeNullable("DataReserva", dr);
                obj.Morador.MoradorID = GetInt32("MoradorID", dr).ToString();
                obj.Morador.Nome = GetString("Nome", dr);
                obj.Morador.RG = GetString("RG", dr);
                obj.Morador.CPF = GetString("CPF", dr);
                obj.Morador.Email = GetString("Email", dr);
                obj.Morador.CaminhoImagem = GetString("CaminhoImagem", dr);
                obj.Morador.UltimoNome = GetString("UltimoNome", dr);
                obj.Morador.DataNascimento = (DateTime)GetDateTimeNullable("DataNascimento", dr);
                obj.Morador.LoginSite = GetString("LoginSite", dr);
                obj.Morador.IsResponsavel = GetBoolean("IsResponsavel", dr);
                obj.Morador.VagaEstacionamento.Estacionamento.EstacionamentoID = GetInt32("EstacionamentoID", dr).ToString();
                obj.Morador.VagaEstacionamento.Estacionamento.Nome = GetString("NomeEstacionamento", dr);
                obj.Morador.VagaEstacionamento.Estacionamento.QtdVagas = GetInt32("QtdVagas", dr);
                obj.Morador.VagaEstacionamento.Estacionamento.TipoEstacionamento = GetString("TipoEstacionamento", dr);
                obj.Morador.Apartamento.ApartamentoID = GetInt32("ApartamentoID", dr).ToString();
                obj.Morador.Apartamento.NumeroApartamento = GetInt32("NumeroMorador", dr);
                obj.Morador.Apartamento.AndarPredio = GetInt32("AndarPredio", dr);
                obj.Morador.Apartamento.ValorApartamento = GetDecimal("ValorApartamento", dr);
                obj.Morador.Apartamento.TipoEstadia.TipoEstadiaID = GetInt32("TipoEstadiaID", dr).ToString();
                obj.Morador.Apartamento.TipoEstadia.Nome = GetString("TipoEstadiaNome", dr).ToString();
                obj.Morador.Apartamento.TipoEstadia.ValorFixo = GetDecimalNullable("ValorFixo", dr);
                obj.Morador.Apartamento.TipoEstadia.Excluido = GetBooleanNullable("TipoEstadiaExcluido", dr);
                obj.Morador.Apartamento.Predio.PredioID = GetInt32("PredioID", dr).ToString();
                obj.Morador.Apartamento.Predio.Nome = GetString("NomPredio", dr);
                obj.Morador.Apartamento.Predio.QtdApartamentos = GetInt32("QtdApartamentos", dr);
                obj.Morador.Apartamento.Predio.Bloco.BlocoID = GetInt32("BlocoID", dr).ToString();
                obj.Morador.Apartamento.Predio.Bloco.Nome = GetString("NomeBloco", dr);
                obj.Morador.Apartamento.Predio.Excluido = GetBooleanNullable("ExcluidoBloco", dr);
                obj.Morador.Apartamento.Predio.Bloco.QtdPredios = GetInt32("QtdPredios", dr);
                obj.Morador.Apartamento.Predio.Bloco.TipoBloco = GetString("TipoBloco", dr);
                obj.Morador.Apartamento.Predio.Bloco.StatusAtivo = GetBooleanNullable("StatusAtivo", dr);
                obj.Morador.Apartamento.Predio.Bloco.Condominio.CondominioID = GetInt32("CondominioID", dr).ToString();
                obj.Morador.Apartamento.Predio.Bloco.Condominio.Nome = GetString("NomeCondominio", dr);
                obj.Morador.Apartamento.Predio.Bloco.Condominio.DataFundacao = GetDateTimeNullable("DataFundacao", dr);
                obj.Morador.Apartamento.Predio.Bloco.Condominio.QtdBlocos = GetInt32("QtdBlocos", dr);
                obj.Morador.Apartamento.Predio.Bloco.Condominio.Endereco = GetString("Endereco", dr);
                obj.Morador.Apartamento.Predio.Bloco.Condominio.CEP = GetString("CEP", dr);
                obj.Morador.Apartamento.Predio.Bloco.Condominio.Bairro = GetString("Bairro", dr);
                obj.Morador.Apartamento.Predio.Bloco.Condominio.Cidade.CidadeID = GetInt32("CidadeID", dr).ToString();
                obj.Morador.Apartamento.Predio.Bloco.Condominio.Cidade.Nome = GetString("CidadeNome", dr);
                obj.Morador.Apartamento.Predio.Bloco.Condominio.Excluido = GetBooleanNullable("CondominioExcluido", dr);
                obj.Morador.Apartamento.IsCadAutomatico = GetBoolean("IsCadAutomatico", dr);
                obj.Morador.Apartamento.AptAndar = "APT." + obj.Morador.Apartamento.NumeroApartamento + "-" + obj.Morador.Apartamento.AndarPredio;
                obj.Morador.VagaEstacionamento.VagaEstacionamentoID = GetInt32("VagaEstacionamentoID", dr).ToString();
                obj.Morador.VagaEstacionamento.NumeroVaga = GetString("NumeroVaga", dr);
                obj.Morador.VagaEstacionamento.TipoVaga = GetString("TipoVaga", dr);
                obj.Morador.VagaEstacionamento.ReservadaAlguel = GetBoolean("ResevadaAlguel", dr);
                obj.Area.AreaID = GetInt32("AreaID", dr).ToString();
                obj.Area.NomeArea = GetString("NomeArea", dr);
                obj.Area.TipoArea = GetString("TipoArea", dr);
                obj.Area.IsAreaPaga = GetBooleanNullable("IsAreaPaga", dr);
                obj.Area.ModoUso = GetString("ModoUso", dr);
                obj.Area.ValorArea = GetDecimal("ValorArea", dr);
                obj.Area.Status = GetBoolean("Status", dr);

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ReservarArea_SET(eReservarArea obj)
        {
            string retorno = string.Empty;
            try
            {
                cmd = new SqlCommand();
                param = new SqlParameter[4];

                if (string.IsNullOrEmpty(obj.ReservaAreaID))
                    obj.ReservaAreaID = "0";

                MontarParametro(0, param, ParameterDirection.Input, "@ReservaAreaID", obj.ReservaAreaID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@DataReserva", obj.DataReserva, SqlDbType.Date);
                MontarParametro(2, param, ParameterDirection.Input, "@MoradorID", obj.Morador.MoradorID, SqlDbType.Int);
                MontarParametro(3, param, ParameterDirection.Input, "@AreaID", obj.Area.AreaID, SqlDbType.Int);

                retorno = Convert.ToString(ExecScalar("USP_RESERVAR_AREA_SET", cmd, param));
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

        public bool VerificaDataHoraReserva(string areaId, string horarioId, DateTime data)
        {
            bool isDataHoraReservada = false;

            try
            {
                cmd = new SqlCommand();
                param = new SqlParameter[3];

                MontarParametro(0, param, ParameterDirection.Input, "@AreaID", areaId, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@HorarioID", horarioId, SqlDbType.Int);
                MontarParametro(2, param, ParameterDirection.Input, "@DataReserva", data, SqlDbType.Date);

                dr = ExecReader("USP_VERIFICA_DATA_HORA_RESERVA", cmd, param);

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        isDataHoraReservada = Convert.ToBoolean(dr["Reservado"]);
                    }
                }
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

            return isDataHoraReservada;
        }

        public bool ReservaArea_DEL(string ReservaAreaID)
        {
            bool deletou = false;
            try
            {
                cmd = new SqlCommand();
                param = new SqlParameter[1];

                MontarParametro(0, param, ParameterDirection.Input, "@ReservaAreaID", ReservaAreaID, SqlDbType.Int);

                dr = ExecReader("USP_RESERVAR_AREA_DEL", cmd);

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        deletou = Convert.ToBoolean(dr["Deletou"]);
                    }
                }
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

            return deletou;
        }
    }
}

