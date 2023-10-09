using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ENTIDAD;
using LOGICA;

namespace PRESENTACION.Controllers
{
    public class CiudadesController : Controller
    {
        CiudadL ciudadL = new CiudadL();

        // GET: Ciudades
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListadoCiudades()
        {
            return View(ciudadL.ListadoCiudad());
        }

        public List<CiudadE> DropCiudad(string obtener, int i_pais)
        {
            return ciudadL.DropCiudad(obtener, i_pais);
        }

        public ActionResult CrearCiudad()
        {
            List<PaisE> listPaisE = new List<PaisE>();
            PaisL paisL = new PaisL();
            listPaisE = paisL.ListadoPaises();
            ViewBag.ListadoPaises = listPaisE;



            return View();
        }

        public ActionResult AgregarCiudad(string txtCiudad, int cboPais)
        {
            CiudadE ciudadE = new CiudadE();
            ciudadE.Nombre = txtCiudad;
            ciudadE.paisE.Id_Pais = cboPais;

            string mensaje = "";

            if (ciudadL.CrearCiudad(ciudadE) == true)
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                    "alert('CIUDAD CREADA...');window.location.href='/Ciudades/ListadoCiudades';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                    "alert('ERROR!! CIUDAD NO CREADA...');window.location.href='/Ciudades/CrearCiudad';</script>";
            }

            return Content(mensaje);
        }

        public ActionResult EditarCiudad(int IdCiudad)
        {
            List<PaisE> listPaisE = new List<PaisE>();
            PaisL paisL = new PaisL();
            listPaisE = paisL.ListadoPaises();
            ViewBag.ListadoPaises = listPaisE;

            return View(ciudadL.BuscarCiudadId(IdCiudad));
        }

        public ActionResult ActualizarCiudad(int txtIdCiudad, string txtNombre, int cboPais)
        {
            CiudadE ciudadE = new CiudadE();
            ciudadE.Id_Ciudad = txtIdCiudad;
            ciudadE.Nombre = txtNombre;
            ciudadE.paisE.Id_Pais = cboPais;

            string mensaje = "";

            if (ciudadL.ActualizarCiudad(ciudadE) == true)
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                    "alert('CIUDAD SE ACTUALIZO CORRECTAMENTE...');window.location.href='/Ciudades/ListadoCiudades';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                    "alert('Error!! CIUDAD NO ACTUALIZADO...');window.location.href='/Ciudades/EditarCiudad';</script>";
            }

            return Content(mensaje);
        }

        public ActionResult EliminarCiudad(int idCiudad)
        {
            string mensaje = "";

            if (ciudadL.EliminarCiudad(idCiudad) == true)
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                    "alert('CIUDAD ELIMINADA CORRECTAMENTE...');window.location.href='/Ciudades/ListadoCiudades';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                    "alert('ERROR..!! CIUDAD  NO ELIMINADA...');window.location.href='/Ciudades/ListadoCiudades';</script>";
            }

            return Content(mensaje);
        }
    }
}