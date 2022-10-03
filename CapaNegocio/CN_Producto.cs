using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Producto
    {
        private CD_Producto objCapaDato = new CD_Producto();

        public List<Producto> Listar()
        {

            return objCapaDato.Listar();
        }
        public int Registrar(Producto obj, out string mensaje)
        {
            mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                mensaje = "El nombre del puerto no puede ser vacio";
            }

            else if(string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                mensaje = "La descripcion del Producto no puede ser vacio";
            }

            else if(obj.oMarca.IdMarca ==0)
            {
                mensaje = "Debe seleccionar una marca";
            }

            else if (obj.oCategoria.IdCategoria == 0)
            {
                mensaje = "Debe seleccionar una Categoria";
            }

            else if (obj.Precio == 0)
            {
                mensaje = "Debe de ingresar el precio del producto";
            }

            else if (obj.Stock == 0)
            {
                mensaje = "Debe de ingresar el Stock del producto";
            }

            if (string.IsNullOrEmpty(mensaje))
            {
                return objCapaDato.Registrar(obj, out mensaje);
            }

            else
            {
                return 0;
            }
        }
        public bool Editar(Producto obj, out string mensaje)
        {
            mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                mensaje = "El nombre del puerto no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                mensaje = "La descripcion del Producto no puede ser vacio";
            }

            else if (obj.oMarca.IdMarca == 0)
            {
                mensaje = "Debe seleccionar una marca";
            }

            else if (obj.oCategoria.IdCategoria == 0)
            {
                mensaje = "Debe seleccionar una Categoria";
            }


            else if (obj.Precio == 0)
            {
                mensaje = "Debe de ingresar el precio del producto";
            }

            else if (obj.Stock == 0)
            {
                mensaje = "Debe de ingresar el Stock del producto";
            }

            if (string.IsNullOrEmpty(mensaje))


            {
                return objCapaDato.Editar(obj, out mensaje);
            }
            else
            {
                return false;
            }
        }
        public bool GuardarDatosImagen(Producto obj, out string mensaje)
        {
            return objCapaDato.GuardarDatosImagen(obj, out mensaje);
        }

        public bool Eliminar(int id, out string mensaje)
        {
            return objCapaDato.Eliminar(id, out mensaje);
        }
    }
}
    

