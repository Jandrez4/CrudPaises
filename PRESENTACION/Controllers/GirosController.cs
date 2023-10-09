using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ENTIDAD;
using LOGICA;

namespace PRESENTACION.Controllers
{
    public class GirosController : Controller
    {
        GiroL giroL = new GiroL();

        // GET: Giros
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListadoGiros()
        {
            return View(giroL.ListadoGiros());
        }

        public ActionResult CrearGiro()
        {
            List<CiudadE> listCiudadE = new List<CiudadE>();
            CiudadL ciudadL = new CiudadL();
            listCiudadE = ciudadL.ListadoCiudad();
            ViewBag.ListadoCiudades = listCiudadE;

            return View();
        }

        public ActionResult AgregarGiro(string txtGiro, int cboGiro)
        {
            GiroE giroE = new GiroE();
            giroE.Giro_Recibido = txtGiro;
            giroE.ciudadE.Id_Ciudad = cboGiro;

            string mensaje = "";

            if (giroL.CrearGiro(giroE) == true)
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                    "alert('GIRO CREADO...');window.location.href='/Giros/ListadoGiros';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                    "alert('Error!! GIRO NO CREADO...');window.location.href='/Giros/CrearGiros';</script>";
            }

            return Content(mensaje);
        }

        public ActionResult EditarGiro(int IdGiro)
        {
            List<CiudadE> listCiudadE = new List<CiudadE>();
            CiudadL ciudadL = new CiudadL();
            listCiudadE = ciudadL.ListadoCiudad();
            ViewBag.ListadoCiudades = listCiudadE;



            return View(giroL.BuscarGiroId(IdGiro));
        }

        public ActionResult ActualizarGiro(int txtIdGiro, string txtGiro, int cboCiudad)
        {
            GiroE giroE = new GiroE();
            giroE.Id_Giro = txtIdGiro;
            giroE.Giro_Recibido = txtGiro;
            giroE.ciudadE.Id_Ciudad = cboCiudad;

            string mensaje = "";

            if (giroL.ActualizarGiro(giroE) == true)
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                    "alert('GIRO SE ACTUALIZO CORRECTAMENTE...');window.location.href='/Giros/ListadoGiros';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                    "alert('ERROR!! GIRO NO ACTUALIZADO...');window.location.href='/Giros/EditarGiro';</script>";
            }

            return Content(mensaje);
        }

        public ActionResult EliminarGiro(int idGiro)
        {
            string mensaje = "";

            if (giroL.EliminarGiro(idGiro) == true)
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                    "alert('GIRO ELIMINADO CORRECTAMENTE...');window.location.href='/Giros/ListadoGiros';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                    "alert('ERROR..!! GIRO  NO ELIMINADO...');window.location.href='/Giros/ListadoGiros';</script>";
            }

            return Content(mensaje);
        }
    }
}