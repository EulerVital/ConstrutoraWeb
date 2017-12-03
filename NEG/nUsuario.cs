using DAO;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEG
{
    public class nUsuario
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Rafael Marques
        /// Motivo: Classe Negocio de Apartamento
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

        public nUsuario()
        {

        }
        public static List<eUsuario> Usuario_GET(eUsuario obj)
        {
            try
            {
                dUsuario db = new dUsuario();
                return db.Usuario_GET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Usuario_SET(eUsuario obj)
        {
            try
            {
                dUsuario db = new dUsuario();
                return db.Usuario_SET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool EnviarEmail(eUsuario obj)
        {
            bool enviado = false;

            StringBuilder sb = new StringBuilder();
            string styleDados = "style='font-family:Arial; font-size:12px;'";

            try
            {
                sb.Append("<p style='font-family:Arial; font-size:16px;'>Olá caro usuário, segue seus dados<p>");
                sb.Append("<br/><p style='font-family:Arial; font-size:16px;'>Tipo de usuario: (A / Administrador), (S / Sindico), (F / Funcionario)</p>");
                sb.AppendFormat("<br/><span {0}>Nome User: {1}</span><br/><span {0}>Tipo de Usuário: {2}</span>", styleDados, obj.NomeUser, obj.TipoUsuario);
                sb.AppendFormat("<br/><span {0}>Senha: {1}</span><br/>", styleDados, obj.Senha);
                sb.AppendFormat("<br/><p {0}> Para logar no sistema coloque como login o Nome User e a Senha gerada</p>", styleDados);

                if (obj.TipoUsuario.Equals("S"))
                {
                    if (obj.Condominio != null)
                    {
                        sb.AppendFormat("<br/><p {0}>Seu usuário terá acesso a todas as funcionalidades do sistema, mais está restrito apenas para o condomínio: " + obj.Condominio.Nome + "</p>", styleDados);
                    }else if(obj.Bloco != null)
                    {
                        var objBloco = nBloco.Bloco_GET(obj.Bloco).FirstOrDefault(c=>c.StatusAtivo == true);

                        if (objBloco != null)
                        {
                            sb.AppendFormat("<br/><p {0}>Seu usuário terá acesso a todas as funcionalidades do sistema, mais está restrito apenas para o bloco do condomínio: " + obj.Condominio.Nome + " / " + obj.Bloco.Nome + "</p>", styleDados);
                        }
                    }
                }else if (obj.TipoUsuario.Equals("F"))
                {
                    if (obj.Condominio != null)
                    {
                        sb.AppendFormat("<br/><p {0}>Seu usuário terá acesso a todas as funcionalidades do sistema, mais está restrito apenas para o condomínio: " + obj.Condominio.Nome + "</p>", styleDados);
                    }
                    else if (obj.Bloco != null)
                    {
                        var objBloco = nBloco.Bloco_GET(obj.Bloco).FirstOrDefault(c => c.StatusAtivo == true);

                        if (objBloco != null)
                        {
                            sb.AppendFormat("<br/><p {0}>Seu usuário terá acesso a todas as funcionalidades do sistema, mais está restrito apenas para o bloco do condomínio: " + objBloco.Condominio.Nome + " / " + objBloco.Nome + "</p>", styleDados);
                        }

                    }else if(obj.Predio != null)
                    {
                        var objPredio = nPredio.Predio_GET(obj.Predio).FirstOrDefault(c => c.Excluido == false);

                        if (objPredio != null)
                        {
                            sb.AppendFormat("<br/><p {0}>Seu usuário terá acesso a todas as funcionalidades do sistema, mais está restrito apenas para o prédio do bloco do condomínio: " + objPredio.Bloco.Condominio.Nome + " / " + objPredio.Bloco.Nome + " / " +  objPredio.Nome + "</p>", styleDados);
                        }
                    }
                }

                nEmail enviar = new nEmail();

                if(enviar.EnviarEmail(sb.ToString(), "Dados de Usuário - Sistema", obj.Email, null, null, null))
                {
                    enviado = true;
                }

                return enviado;
            }
            catch
            {
                return false;
            }
        }

        public static eUsuario Usuario_Logar(string nomeUser, string senha)
        {
            try
            {
                dUsuario db = new dUsuario();
                string UsuarioID = db.Usuario_Logar(nomeUser, senha);

                if (string.IsNullOrEmpty(UsuarioID))
                {
                    return null;
                }else
                {
                    return Usuario_GET(new eUsuario() { UsuarioID = UsuarioID }).FirstOrDefault();
                }


            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}


