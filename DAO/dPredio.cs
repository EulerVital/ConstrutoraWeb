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
    public class dPredio : DBase.DBase
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Euler Vital
        /// Motivo: Classe Predio de Conexao com a base de dados
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

        public List<ePredio> Predio_GET(ePredio obj)
        {
            List<ePredio> retorno = new List<ePredio>();
            cmd = new SqlCommand();
            param = new SqlParameter[8];

            try
            {

                MontarParametro(0, param, ParameterDirection.Input, "@PredioID", obj.PredioID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@Nome", obj.Nome, SqlDbType.VarChar);
                MontarParametro(2, param, ParameterDirection.Input, "@QtdApartamentos", obj.QtdApartamentos, SqlDbType.Int);
                MontarParametro(3, param, ParameterDirection.Input, "@BlocoID", obj.Bloco.BlocoID, SqlDbType.Int);
                MontarParametro(4, param, ParameterDirection.Input, "@NomeBloco", obj.Bloco.Nome, SqlDbType.VarChar);
                MontarParametro(5, param, ParameterDirection.Input, "@CondominioID", obj.Bloco.Condominio.CondominioID, SqlDbType.Int);
                MontarParametro(6, param, ParameterDirection.Input, "@Excluido", obj.Excluido, SqlDbType.Bit);
                MontarParametro(7, param, ParameterDirection.Input, "@NomeCondominio", obj.Bloco.Condominio.Nome, SqlDbType.VarChar);

                dr = ExecReader("USP_PREDIO_GET", cmd, param);

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        retorno.Add(Predio(dr));
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

        private ePredio Predio(IDataReader dr)
        {
            ePredio obj = new ePredio();

            try
            {
                obj.PredioID = GetInt32("PredioID", dr).ToString();
                obj.Nome = GetString("Nome", dr);
                obj.QtdApartamentos = GetInt32("QtdApartamentos", dr);
                obj.Excluido = GetBoolean("Excluido", dr);
                obj.Bloco.BlocoID = GetInt32("BlocoID", dr).ToString();
                obj.Bloco.Nome = GetString("NomeBloco", dr);
                obj.Bloco.QtdPredios = GetInt32("QtdPredios", dr);
                obj.Bloco.TipoBloco = GetString("TipoBloco", dr);
                obj.Bloco.StatusAtivo = GetBoolean("StatusAtivo", dr);
                obj.Bloco.Condominio.CondominioID = GetInt32("CondominioID", dr).ToString();
                obj.Bloco.Condominio.Nome = GetString("NomeCondominio", dr);
                obj.Bloco.Condominio.QtdBlocos = GetInt32("QtdBlocos", dr);
                obj.Bloco.Condominio.Endereco = GetString("Endereco", dr);
                obj.Bloco.Condominio.CEP = GetString("CEP", dr);
                obj.Bloco.Condominio.Bairro = GetString("Bairro", dr);
                obj.Bloco.Condominio.Cidade.CidadeID = GetInt32("CidadeID", dr).ToString();
                obj.Bloco.Condominio.Cidade.Nome = GetString("CidadeNome", dr);
                obj.Bloco.Condominio.Excluido = GetBoolean("Excluido", dr);

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Predio_SET(ePredio obj)
        {
            string retorno = string.Empty;
            try
            {
                cmd = new SqlCommand();
                param = new SqlParameter[5];

                if (string.IsNullOrEmpty(obj.PredioID))
                    obj.PredioID = "0";

                MontarParametro(0, param, ParameterDirection.Input, "@PredioID", obj.PredioID, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@Nome", obj.Nome, SqlDbType.VarChar);
                MontarParametro(2, param, ParameterDirection.Input, "@QtdApartamentos", obj.QtdApartamentos, SqlDbType.Int);
                MontarParametro(3, param, ParameterDirection.Input, "@Excluido", obj.Excluido, SqlDbType.Bit);
                MontarParametro(4, param, ParameterDirection.Input, "@BlocoID", obj.Bloco.BlocoID, SqlDbType.Int);

                retorno = Convert.ToString(ExecScalar("USP_PREDIO_SET", cmd, param));
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
