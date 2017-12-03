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
    public class ReservaAreaController : Controller
    {
        // GET: ReservaArea
        public ActionResult Index()
        {
            List<eReservarArea> listaReservas = null;

            if (Session["ListaReservas"] == null)
            {
                var obj = (eMorador)Session["Morador"];
                List<ReservaAreaViewModel> lista = new List<ReservaAreaViewModel>();

                listaReservas = nReservarArea.ReservaArea_GET(new eReservarArea() { Morador = obj });

                foreach(var item in listaReservas)
                {
                    var objHorario = nHorario.HORARIO_GET(new eHorario() { Area = item.Area, Reservado = true }).FirstOrDefault();
                    lista.Add(new ReservaAreaViewModel() { ReservaArea = item, Horario = objHorario });
                }

                Session["ListaReservas"] = lista;
            }

            return View((List<ReservaAreaViewModel>)Session["ListaReservas"]);
        }

        // GET: ReservaArea/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReservaArea/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReservaArea/Create
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

        // GET: ReservaArea/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservaArea/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservaArea/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservaArea/Delete/5
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
