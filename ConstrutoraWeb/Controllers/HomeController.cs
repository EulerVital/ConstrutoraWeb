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
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            HomeViewModel objHomeMorador = new HomeViewModel();

            if (Session["MoradorLogado"] != null)
            {
                objHomeMorador = (HomeViewModel)Session["MoradorLogado"];

                return View(objHomeMorador);
            }
            else
            {
                return RedirectToAction("Logar", "Login");
            }
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Editar(HomeViewModel objHomeMorador)
        {
            
            try
            {
                if(objHomeMorador != null)
                {
                    eMorador obj = (eMorador)Session["Morador"];
                    var objSessao = ((HomeViewModel)Session["MoradorLogado"]);

                    objSessao.Nome = objHomeMorador.Nome;
                    objSessao.UltimoNome = objHomeMorador.UltimoNome;
                    objSessao.Email = objHomeMorador.Email;
                    objSessao.Senha = objHomeMorador.Senha;

                    if (obj != null)
                    {
                        obj.Nome = objHomeMorador.Nome;
                        obj.UltimoNome = objHomeMorador.UltimoNome;
                        obj.Email = objHomeMorador.Email;
                        obj.Senha = objHomeMorador.Senha;
                    }

                    if (nMorador.MORADOR_SET(obj).Equals("0"))
                    {
                        Session["Editou"] = false;
                    }
                    else
                    {
                        objHomeMorador.ListaMoradores = nMorador.MORADOR_GET(new eMorador() { Apartamento = objSessao.Apartamento });

                        Session["MoradorLogado"] = objSessao;
                        Session["Morador"] = obj;
                        Session["Editou"] = true;
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
