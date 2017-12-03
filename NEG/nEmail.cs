using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace NEG
{
    public class nEmail
    {
        private bool envioOK;                 // Define o estado atual de envio do email
        public string EmailDestinatario { get; set; } // email que receberá a mensagem
        public string Assunto { get; set; }                 // assunto da mensagem 
        public string Mensagem { get; set; }            // mensagem do email

        //Aqui deve ser os dados da sua conta de email
        public string EmailAdm { get; set; }         // Conta de email válida
        public string Servidor { get; set; }           // Servidor da conta de email
        public string Senha { get; set; }              // Define a senha da conta de email valida

        MailMessage email = new MailMessage();

        /// <summary>
        /// Construtora da Classe. 
        /// </summary>
        public nEmail()
        {
            InicializeValores();
        }

        /// <summary>
        /// Inicializa os valores das variáveis
        /// </summary>
        public void InicializeValores()
        {
            envioOK = false;
            EmailDestinatario = "eulervitalps@gmail.com";
            Assunto = "Assunto do Email";
            Mensagem = "Mensagem de teste do sistema para envio de email";

            EmailAdm = "rebctinfo@gmail.com";
            Servidor = "gmail.com";
            Senha = "rebctinfo1234";

        }

        /// <summary>
        /// Método para envio do email
        /// </summary>
        /// <returns>retorna true caso o envio seja feito e false caso contrário</returns>
        public bool EnviarEmail()
        {
            try
            {
                // Configura o corpo da mensagem a ser enviada
                email.From = new MailAddress(EmailAdm); // cria obj com email iformado
                email.To.Add(EmailDestinatario);
                email.Subject = Assunto;
                email.Body = Mensagem;
                email.IsBodyHtml = true;
                email.BodyEncoding = Encoding.UTF8;

                //Cria o objeto do cliente servidor 
                SmtpClient smtp = new SmtpClient();

                //verifica qual servidor enviará a mensagem. 
                if (Servidor == "gmail.com")
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                }

                if (Servidor == "yahoo.com.br")
                {
                    smtp.Host = "smtp.mail.yahoo.br";
                    smtp.Port = 587;
                }

                if (Servidor == "hotmail.com")
                {
                    smtp.Host = "smtp.live.com";
                    smtp.Port = 25;
                    smtp.EnableSsl = true;
                }

                // Cria um objeto do servidor com a senha e login informado na classe ConfiguracaoLogin.
                // O objeto usa seu email e sua senha e faz o envio do email através destes dados.
                smtp.Credentials = new System.Net.NetworkCredential(EmailAdm, Senha);
                smtp.Send(email);

                //Define o estado de envio do email como ok.
                envioOK = true;
            }
            catch (Exception ex)
            {
                envioOK = false;
            }

            return envioOK;
        }

        public bool EnviarEmail(string mensagem, string assunto, string destinatario, string servidor, string emailAdmin, string senha)
        {
            if (!string.IsNullOrEmpty(mensagem))
            {
                Mensagem = mensagem;
            }

            if (!string.IsNullOrEmpty(assunto))
            {
                Assunto = assunto;
            }

            if (!string.IsNullOrEmpty(destinatario))
            {
                EmailDestinatario = destinatario;
            }

            if (!string.IsNullOrEmpty(servidor))
            {
                Servidor = servidor;
            }

            if (!string.IsNullOrEmpty(emailAdmin))
            {
                EmailAdm = emailAdmin;
            }

            if (!string.IsNullOrEmpty(senha))
            {
                Senha = senha;
            }

            return EnviarEmail();
        }
    }
}
