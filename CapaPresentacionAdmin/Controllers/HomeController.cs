using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionAdmin.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Usuarios()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarUsuarios()
        {
            List<Usuario> oLista = new List<Usuario>();

            oLista = new CN_Usuarios().Listar();

            return Json(new{ data = oLista},JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GuardarUsuario(Usuario objeto)
        {

            object resultado;
            string mensaje = string.Empty;

            if  (objeto.IdUsuario == 0)
            {

                resultado = new CN_Usuarios().Registrar(objeto, out mensaje);
            }

            else
            {
                resultado = new CN_Usuarios().Editar(objeto, out mensaje);

            }
                return Json(new {resultado = resultado,mensaje = mensaje}, JsonRequestBehavior.AllowGet);
        }

        //DEMO: implemetando codigo limpio
        [HttpPost]
        public JsonResult UserSave(Usuario Request)
        {
            string messageError = new CN_Usuarios().Create(Request);
            return ResponseJson(messageError, Request.IdUsuario);
        }

        [HttpPost]
        public JsonResult UserUpdate(Usuario Request)
        {
            string resultado = new CN_Usuarios().Update(Request);
            return ResponseJson(resultado, Request.IdUsuario);
        }


        [HttpPost]
        public JsonResult EliminarUsuario(int id)
        {

            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Usuarios().Eliminar(id, out mensaje);
            return Json(new {resultado = respuesta,mensaje = mensaje},JsonRequestBehavior.AllowGet);
        }
    }
}