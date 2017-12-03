using ConstrutoraWeb.Models;
using ENT;
using NEG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConstrutoraWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Logar()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Logar(LoginViewModel objLoginView)
        {
            try
            {
                eMorador objMorador = new eMorador();

                objMorador.LoginSite = objLoginView.Login;
                objMorador.Senha = objLoginView.Senha;

                var obj = nMorador.SITE_LOGAR(objMorador).FirstOrDefault();
                HomeViewModel objHome = new HomeViewModel();

                if(obj != null)
                {
                    objHome.MoradorID = obj.MoradorID;
                    objHome.Nome = obj.Nome;
                    objHome.UltimoNome = obj.UltimoNome;
                    objHome.LoginSite = obj.LoginSite;
                    objHome.RG = obj.RG;
                    objHome.CPF = obj.CPF;
                    objHome.Email = obj.Email;

                    if (string.IsNullOrEmpty(obj.CaminhoImagem))
                    {
                        objHome.CaminhoImagem = @"Imagens\user_accounts_15362.png";
                    }
                    else
                    {
                        objHome.CaminhoImagem = obj.CaminhoImagem;
                    }

                    objHome.IsResponsavel = obj.IsResponsavel;
                    objHome.Excluido = obj.Excluido;
                    objHome.DataNasci = obj.DataNascimento.ToString("dd/MM/yyyy");
                    objHome.Apartamento = obj.Apartamento;
                    objHome.Visitante = obj.Visitante;
                    objHome.VagaEstacionamento = obj.VagaEstacionamento;

                    objHome.ListaMoradores = nMorador.MORADOR_GET(new eMorador() { Apartamento = obj.Apartamento });

                    Session["MoradorLogado"] = objHome;
                    Session["Morador"] = obj;
                    Session["ListaReservas"] = null;

                    return RedirectToAction("Index", "Home");
                }else
                {
                    return RedirectToAction("Logar");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
