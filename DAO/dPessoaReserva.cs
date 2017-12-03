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
    public class dPessoaReserva : DBase.DBase
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Euler Vital
        /// Motivo: Classe PessoaReserva de Conexao com a base de dados
        /// Data Criação: 13/11/2017
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

        public List<ePessoaReserva> PessoaReserva_GET(ePessoaReserva obj)
        {
            List<ePessoaReserva> retorno = new List<ePessoaReserva>();
            cmd = new SqlCommand();
            param = new SqlParameter[4];

            try
            {
                #region Validando

                if (obj.PessoaReservaID != null)
                {

                    if (obj.PessoaReservaID.Equals("0"))
                    {
                        obj.PessoaReservaID = null;
                    }
                }


                if (obj.ReservaArea.ReservaAreaID != null)
                {
                    if (obj.ReservaArea.ReservaAreaID.Equals("0"))
                    {
                        obj.ReservaArea.ReservaAreaID = null;
                    }
                }

                if (obj.ReservaArea.Morador.MoradorID != null)
                {
                    if (obj.ReservaArea.Morador.MoradorID.Equals("0"))
                    {
                        obj.ReservaArea.Morador = null;
                    }
                }

                if (obj.ReservaArea.Area.AreaID != null)
                { 
                    if (obj.ReservaArea.Area.AreaID.Equals("0"))
                    {
                        obj.ReservaArea.Area.AreaID = null;
                    }
                }

                #endregion

                MontarParametro(0, param, ParameterDirection.Input, "@PessoaReservaID", obj.PessoaReservaID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@ReservaAreaID", obj.ReservaArea.ReservaAreaID, SqlDbType.Int);
                MontarParametro(2, param, ParameterDirection.Input, "@MoradorID", obj.ReservaArea.Morador.MoradorID, SqlDbType.Int);
                MontarParametro(3, param, ParameterDirection.Input, "@AreaID", obj.ReservaArea.Area.AreaID, SqlDbType.Int);

                dr = ExecReader("USP_PESSOAS_RESERVA_GET", cmd, param);

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        retorno.Add(PessoaReserva(dr));
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

        private ePessoaReserva PessoaReserva(IDataReader dr)
        {
            ePessoaReserva obj = new ePessoaReserva();

            try
            {
                obj.PessoaReservaID = GetInt32("PessoaReservaID", dr).ToString();
                obj.Nome = GetString("Nome", dr);
                obj.RG = GetString("RG", dr);
                obj.CPF = GetString("CPF", dr);
                obj.IsMenorIdade = GetBoolean("IsMenorIdade", dr);
                obj.TipoPagamento = GetString("TipoPagamento", dr);
                obj.ResponsavelID = GetInt32("ResponsavelID", dr).ToString();
                obj.ReservaArea.ReservaAreaID = GetInt32("ReservaAreaID", dr).ToString();
                obj.ReservaArea.DataReserva = (DateTime)GetDateTimeNullable("DAtaReserva", dr);
                obj.ReservaArea.Area.AreaID = GetInt32("AreaID", dr).ToString();
                obj.ReservaArea.Area.NomeArea = GetString("NomeArea", dr);
                obj.ReservaArea.Area.TipoArea = GetString("TipoArea", dr);
                obj.ReservaArea.Area.IsAreaPaga = GetBooleanNullable("IsAreaPaga", dr);
                obj.ReservaArea.Area.ModoUso = GetString("ModoUso", dr);
                obj.ReservaArea.Area.ValorArea = GetDecimal("ValorArea", dr);
                obj.ReservaArea.Area.Status = GetBoolean("Status", dr);
                obj.ReservaArea.Morador.MoradorID = GetInt32("MoradorID", dr).ToString();
                obj.ReservaArea.Morador.Nome = GetString("Nome", dr);
                obj.ReservaArea.Morador.RG = GetString("RG", dr);
                obj.ReservaArea.Morador.CPF = GetString("CPF", dr);
                obj.ReservaArea.Morador.Email = GetString("Email", dr);
                obj.ReservaArea.Morador.CaminhoImagem = GetString("CaminhoImagem", dr);
                obj.ReservaArea.Morador.UltimoNome = GetString("UltimoNome", dr);
                obj.ReservaArea.Morador.DataNascimento = (DateTime)GetDateTimeNullable("DataNascimento", dr);
                obj.ReservaArea.Morador.LoginSite = GetString("LoginSite", dr);
                obj.ReservaArea.Morador.IsResponsavel = GetBoolean("IsResponsavel", dr);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string PessoaReserva_SET(ePessoaReserva obj)
        {
            string retorno = string.Empty;
            try
            {
                cmd = new SqlCommand();
                param = new SqlParameter[8];

                if (string.IsNullOrEmpty(obj.PessoaReservaID))
                    obj.PessoaReservaID = "0";

                MontarParametro(0, param, ParameterDirection.Input, "@PessoaReservaID", obj.PessoaReservaID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@Nome", obj.Nome, SqlDbType.VarChar);
                MontarParametro(2, param, ParameterDirection.Input, "@CPF", obj.CPF, SqlDbType.VarChar);
                MontarParametro(3, param, ParameterDirection.Input, "@RG", obj.RG, SqlDbType.VarChar);
                MontarParametro(4, param, ParameterDirection.Input, "@IsMenorIdade", obj.IsMenorIdade, SqlDbType.Bit);
                MontarParametro(5, param, ParameterDirection.Input, "@ResponsavelID", obj.ResponsavelID, SqlDbType.Int);
                MontarParametro(6, param, ParameterDirection.Input, "@TipoPagamento", obj.TipoPagamento, SqlDbType.VarChar);
                MontarParametro(7, param, ParameterDirection.Input, "@ReservaAreaID", obj.ReservaArea.ReservaAreaID, SqlDbType.Int);

                retorno = Convert.ToString(ExecScalar("USP_PESSOAS_RESERVA_SET", cmd, param));
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

        public bool PessoaReserva_DEL(string PessoaReservaID)
        {
            bool deletou = false;

            cmd = new SqlCommand();
            param = new SqlParameter[1];

            try
            {

                MontarParametro(0, param, ParameterDirection.Input, "@PessoaReservaID", PessoaReservaID, SqlDbType.Int);

                dr = ExecReader("USP_PESSOAS_RESERVA_DEL", cmd, param);

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        if (dr["Deletou"].ToString().Equals("1"))
                        {
                            deletou = true;
                        }
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
