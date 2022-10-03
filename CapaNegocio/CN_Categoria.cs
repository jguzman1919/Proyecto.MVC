using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
namespace CapaNegocio
{
    public class CN_Categoria
    {

        private CD_Categoria objCapaDato = new CD_Categoria();

        public List<Categoria> Listar()
        {

            return objCapaDato.Listar();
        }
        public int Registrar(Categoria obj, out string mensaje)
        {
            mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                mensaje = "La descripcion de la categoria  no puede ser vacio";
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
        public bool Editar(Categoria obj, out string mensaje)
        {
            mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                mensaje = "La descripcion de la categoria  no puede ser vacio";
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
        public bool Eliminar(int id, out string mensaje)
        {
            return objCapaDato.Eliminar(id, out mensaje);
        }
}   }
