using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;
using Newtonsoft.Json;

namespace CapaPresentacionAdmin.Controllers
{
    public class MantenedorController : Controller
    {
        // GET: Mantenedor
        public ActionResult Categorias()
        {
            return View();
        }


        public ActionResult Marca()
        {
            return View();
        }


        public ActionResult Producto()
        {
            return View();
        }
        //++++++++++++++Categoria+++++++++++++

        #region Categoria
        [HttpGet]
        public JsonResult ListarCategorias()
        {
            List<Categoria> oLista = new List<Categoria>();
            oLista = new CN_Categoria().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GuardarCategoria(Categoria objeto)
        {

            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdCategoria == 0)
            {

                resultado = new CN_Categoria().Registrar(objeto, out mensaje);
            }

            else
            {
                resultado = new CN_Categoria().Editar(objeto, out mensaje);

            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EliminarCategoria(int id)
        {

            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Categoria().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        //++++++++++++++Marca+++++++++++++
        #region Marca
        [HttpGet]
        public JsonResult ListarMarca()
        {
            List<Marca> oLista = new List<Marca>();
            oLista = new CN_Marca().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GuardarMarca(Marca objeto)
        {

            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdMarca == 0)
            {

                resultado = new CN_Marca().Registrar(objeto, out mensaje);
            }

            else
            {
                resultado = new CN_Marca().Editar(objeto, out mensaje);

            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EliminarMarca(int id)
        {

            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Marca().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        #endregion



        //++++++++++++++Producto+++++++++++++
        #region
        [HttpGet]

            public JsonResult ListarProducto()
            {
                List<Producto> oLista = new List<Producto>();
                oLista = new CN_Producto().Listar();
                return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
            }
            [HttpPost]

            public JsonResult GuardarProducto(string objeto, HttpPostedFileBase archivoImagen)
            {

               
                string mensaje = string.Empty;
                bool operacion_exitosa = true;
                bool guardar_imagen_exito = true;

                Producto oproducto = new Producto();
                oproducto = JsonConvert.DeserializeObject<Producto>(objeto);

                decimal precio;

                if (decimal.TryParse(oproducto.PrecioTexto, NumberStyles.AllowDecimalPoint, new CultureInfo("es-RD"), out precio))
                {
                    oproducto.Precio = precio;

                }

                else
                {
                    return Json(new { operacionExitosa = false, mensaje = "El formato del precio debe ser ##.##" }, JsonRequestBehavior.AllowGet);
                }

                if (oproducto.IdProducto == 0)
                {

                    int idProductoGenerado = new CN_Producto().Registrar(oproducto, out mensaje);

                if (idProductoGenerado != 0)
                {
                    oproducto.IdProducto = idProductoGenerado;
                }

                else 
                        {
                    operacion_exitosa = false;
                        }
                }

                else
                {
                operacion_exitosa = new CN_Producto().Editar(oproducto, out mensaje);

                }

                if (operacion_exitosa)
                 {

                if(archivoImagen != null)
                {
                    String ruta_guardar = ConfigurationManager.AppSettings["servidordefotos"];
                    string extension = Path.GetExtension(archivoImagen.FileName);
                    string nombre_imagen = string.Concat(oproducto.IdProducto.ToString(), extension);

                    try
                    {
                        archivoImagen.SaveAs(Path.Combine(ruta_guardar,nombre_imagen));
                    }

                    catch (Exception ex)

                    {
                        string msg = ex.Message;
                        guardar_imagen_exito = false;

                    }

                    if (guardar_imagen_exito)
                    {
                        oproducto.RutaImagen = ruta_guardar;
                        oproducto.NombreImagen = nombre_imagen;
                        bool respuesta= new CN_Producto().GuardarDatosImagen(oproducto, out mensaje);
                    }

                    else
                    {
                        mensaje = "Se guardo el producto pero hubo problema con la imagen";
                    }
                }
            }
            return Json(new { operacionExitosa = operacion_exitosa,idGenerado=oproducto.IdProducto,mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ImagenProducto(int id)
        {
            bool convension;
            Producto oproducto = new CN_Producto().Listar().Where(p => p.IdProducto == id).FirstOrDefault();

            string textoBase64 = CN_Recursos.ConvertirBase64(Path.Combine(oproducto.RutaImagen,oproducto.NombreImagen), out convension);
            
            return Json(new {  
                convension = convension,
                textoBase64 = textoBase64,
            extension = Path.GetExtension(oproducto.NombreImagen)
            },
            JsonRequestBehavior.AllowGet
            );
        }
        [HttpPost]
        public JsonResult EliminarProducto(int id)
        {

            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Producto().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
    



