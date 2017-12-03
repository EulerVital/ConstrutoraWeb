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
    public class dHorario : DBase.DBase
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Euler Vital
        /// Motivo: Classe Horario de Conexao com a base de dados
        /// Data Criação: 11/11/2017
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

        public List<eHorario> Horario_GET(eHorario obj)
        {
            List<eHorario> retorno = new List<eHorario>();
            cmd = new SqlCommand();
            param = new SqlParameter[3];

            try
            {
                MontarParametro(0, param, ParameterDirection.Input, "@HorarioID", obj.HorarioID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@AreaID", obj.Area.AreaID, SqlDbType.Int);
                MontarParametro(2, param, ParameterDirection.Input, "@Reservado", obj.Reservado, SqlDbType.Bit);

                dr = ExecReader("USP_HORARIO_GET", cmd, param);

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        retorno.Add(Horario(dr));
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

        private eHorario Horario(IDataReader dr)
        {
            eHorario obj = new eHorario();

            try
            {
                obj.HorarioID = GetInt32("HorarioID", dr).ToString();
                obj.HoraInicio = GetString("HoraInicio", dr);
                obj.HoraFim = GetString("HoraFim", dr);
                obj.Excluido = GetBoolean("Excluido", dr);
                obj.Horario = obj.HoraInicio + " ás " + obj.HoraFim;
                obj.Reservado = GetBooleanNullable("Reservado", dr);
                obj.Area.AreaID = GetInt32("AreaID", dr).ToString();
                obj.Area.NomeArea = GetString("NomeArea", dr);
                obj.Area.TipoArea = GetString("TipoArea", dr);
                obj.Area.ModoUso = GetString("ModoUso", dr);
                obj.Area.IsAreaPaga = GetBooleanNullable("IsAreaPaga", dr);
                obj.Area.ValorArea = GetDecimal("ValorArea", dr);
                obj.Area.Status = GetBoolean("Status", dr);

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Horario_SET(eHorario obj)
        {
            string retorno = string.Empty;
            try
            {
                cmd = new SqlCommand();
                param = new SqlParameter[6];

                if (string.IsNullOrEmpty(obj.HorarioID))
                    obj.HorarioID = "0";

                MontarParametro(0, param, ParameterDirection.Input, "@HorarioID", obj.HorarioID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@HoraInicio", obj.HoraInicio, SqlDbType.VarChar);
                MontarParametro(2, param, ParameterDirection.Input, "@HoraFim", obj.HoraFim, SqlDbType.VarChar);
                MontarParametro(3, param, ParameterDirection.Input, "@Excluido", obj.Excluido, SqlDbType.Bit);
                MontarParametro(4, param, ParameterDirection.Input, "@AreaID", obj.Area.AreaID, SqlDbType.Int);
                MontarParametro(5, param, ParameterDirection.Input, "@REservado", obj.Reservado, SqlDbType.Bit);


                retorno = Convert.ToString(ExecScalar("USP_HORARIO_SET", cmd, param));
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
