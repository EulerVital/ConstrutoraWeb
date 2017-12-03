using System;
using System.Collections.Generic;
using ENT;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class dFuncionario : DBase.DBase
    {
            #region Assinaturas
            /// <summary>
            /// *********Criação*************
            /// Autor: Rafael Marques 
            /// Motivo: Classe Funcionario de Conexao com a base de dados
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

            public List<eFuncionario> Funcionario_GET(eFuncionario obj)
            {
                  List<eFuncionario> retorno = new List<eFuncionario>();
                cmd = new SqlCommand();
                param = new SqlParameter[3];

                try
                {

                        dr = ExecReader("", cmd, param);

                        if (dr != null)
                    {
                            while (dr.Read())
                        {
                              retorno.Add(Funcionario(dr));
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

            private eFuncionario Funcionario (IDataReader dr)
            {
                eFuncionario obj = new eFuncionario();

                try
                {
                    obj.FuncionarioId = GetInt32("FuncionarioId", dr).ToString();
                    obj.NomeCompleto = GetString("NomeCompleto", dr);
                    obj.RG = GetString("Rg", dr);
                    obj.Cpf = GetString("Cpf", dr);
                    obj.DataNascimento =(DateTime)GetDateTimeNullable("DataNascimento", dr);
                    obj.TelefoneFixo = GetInt32("TelefoneFixo", dr);
                    obj.TelefoneCelular = GetInt32("TelefoneCelular", dr);
                    obj.Endereco = GetString("Endereco", dr);
                    obj.Bairro = GetString("Bairro", dr);
                    obj.Cep = GetString("Cep", dr);
                    obj.Condominio.CondominioID = GetInt32("Condominio", dr).ToString();
                    obj.Bloco.BlocoID = GetInt32("BlocoID", dr).ToString();
                    obj.Profissao.ProfissaoID = GetInt32("ProfissaoID", dr).ToString();
                    obj.Usuario.UsuarioID = GetInt32("UsuarioID", dr).ToString();
                    return obj;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public string Funcionario_SET(eFuncionario obj)
            {
                string retorno = string.Empty;
                try
                {
                      cmd = new SqlCommand();
                      param = new SqlParameter[0];

                    if (string.IsNullOrEmpty(obj.FuncionarioId))
                        obj.FuncionarioId = "0";
                    
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
