using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ENTIDAD;
using LOGICA;

namespace PRESENTACION.Controllers
{
    public class PaisesController : Controller
    {
        PaisL paisL = new PaisL();

        // GET: Paises
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult ListadoPaises()
        {
            return View(paisL.ListadoPaises());
        }

        public ActionResult DropdownPaises(string obtener)
        {
            return View(paisL.DropdownPaises(obtener));
        }

        public ActionResult CrearPais()
        {
            return View();
        }

        public ActionResult AgregarPais(string txtNombre)
        {
            PaisE paisE = new PaisE();  
            paisE.Nombre = txtNombre;

            string mensaje = "";

            if(paisL.CrearPais(paisE) == true)
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                    "alert('PAIS CREADO...');window.location.href='/Paises/ListadoPaises';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                    "alert('Error!! PAIS NO CREADO...');window.location.href='/Paises/CrearPais';</script>";
            }

            return Content(mensaje);
        }

        public ActionResult EditarPais(int IdPais)
        {
            return View(paisL.BuscarPaisId(IdPais));
        }

        public ActionResult ActualizarPais(int txtIdPais, string txtNombre)
        {
            PaisE paisE = new PaisE();
            paisE.Id_Pais = txtIdPais;
            paisE.Nombre = txtNombre;

            string mensaje = "";

            if (paisL.ActualizarPais(paisE) == true)
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                    "alert('PAIS SE ACTUALIZO CORRECTAMENTE...');window.location.href='/Paises/ListadoPaises';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                    "alert('Error!! PAIS NO ACTUALIZADO...');window.location.href='/Paises/EditarPais';</script>";
            }

            return Content(mensaje);
        }

        public ActionResult EliminarPais(int idPais)
        {
            string mensaje = "";

            if (paisL.EliminarPais(idPais) == true)
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                    "alert('PAIS ELIMINADO CORRECTAMENTE...');window.location.href='/Paises/ListadoPaises';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                    "alert('ERROR..!! PAIS  NO ELIMINADO...');window.location.href='/Paises/ListadoPaises';</script>";
            }

            return Content(mensaje);
        }
    }
}