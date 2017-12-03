using System;
using System.Collections.Generic;
using ENT;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class dVisitante : DBase.DBase
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Euler Vital
        /// Motivo: Classe Visitante de Conexao com a base de dados
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

        public List<eVisitante> Visitante_GET(eVisitante obj)
        {
            List<eVisitante> retorno = new List<eVisitante>();
            cmd = new SqlCommand();
            param = new SqlParameter[3];

            try
            {

               /* MontarParametro(0, param, ParameterDirection.Input, "@ApartamentoID", obj.ApartamentoID, SqlDbType.Int);
                MontarParametro(2, param, ParameterDirection.Input, "@PredioID", obj.Predio.PredioID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@NomePredio", obj.Predio.Nome, SqlDbType.VarChar);*/

                dr = ExecReader("", cmd, param);

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        retorno.Add(Visitante(dr));
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

        private eVisitante Visitante (IDataReader dr)
        {
            eVisitante obj = new eVisitante();

            try
            {
                obj.VisitanteID = GetInt32("VisitanteID", dr).ToString();
                obj.NomeCompleto = GetString("NomeCompleto", dr);
                obj.Rg = GetString("Rg", dr);
                obj.Cpf = GetString("Cpf", dr);
                obj.Email = GetString("Email", dr);
                obj.Entrada = GetString("Entrada", dr);
                obj.Saida = GetString("Saida", dr);
                obj.QtdDias = GetInt32("QtdDias", dr);
                obj.Mes = GetInt32("Mes", dr);
                obj.Semana = GetString("Semana", dr);
                obj.TempoPermanencia = GetString("TempoPermanencia", dr);
                obj.Ano = GetInt32("Ano", dr);
                obj.Estacionamento.EstacionamentoID = GetInt32("EstacionamentoID", dr).ToString();
                obj.Telefone.TelefoneID = GetInt32("TelefoneID", dr).ToString();

                                           
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Visitante_SET(eVisitante obj)
        {
            string retorno = string.Empty;
            try
            {
                cmd = new SqlCommand();
                param = new SqlParameter[7];

                if (string.IsNullOrEmpty(obj.VisitanteID))
                    obj.VisitanteID = "0";

               /* MontarParametro(0, param, ParameterDirection.Input, "@ApartamentoID", obj.ApartamentoID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@NumeroApartamento", obj.NumeroApartamento, SqlDbType.Int);
                MontarParametro(2, param, ParameterDirection.Input, "@TipoEstadiaID", obj.TipoEstadia.TipoEstadiaID, SqlDbType.Int);
                MontarParametro(3, param, ParameterDirection.Input, "@AndarPredio", obj.AndarPredio, SqlDbType.Int);
                MontarParametro(4, param, ParameterDirection.Input, "@ValorApartamento", obj.ValorApartamento, SqlDbType.Decimal);
                MontarParametro(5, param, ParameterDirection.Input, "@PredioID", obj.Predio.PredioID, SqlDbType.Int);
                MontarParametro(6, param, ParameterDirection.Input, "@IsCadAutomatico", obj.IsCadAutomatico, SqlDbType.Bit);*/

                retorno = Convert.ToString(ExecScalar("", cmd, param));
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


