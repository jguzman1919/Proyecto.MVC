using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
using CapaNegocio.Validations.Users;

namespace CapaNegocio
{
    public class CN_Usuarios
    {
        private CD_Usuarios cdUser = new CD_Usuarios();

        public List<Usuario> Listar()
        {

            return cdUser.Listar();
        }

        public int Registrar(Usuario user, out string mensaje)
        {
            mensaje = String.Empty;

            if (string.IsNullOrEmpty(user.Nombres) || string.IsNullOrWhiteSpace(user.Nombres))
            {
                mensaje = "El nombre del usuario no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(user.Apellidos) || string.IsNullOrWhiteSpace(user.Apellidos))
            {
                mensaje = "El Apellidos del usuario no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(user.Correo) || string.IsNullOrWhiteSpace(user.Correo))
            {
                mensaje = "El Email del usuario no puede ser vacio";
            }

            if (string.IsNullOrEmpty(mensaje))
            {
                string Clave = CN_Recursos.GenerarClave();

                string asunto = "creacion de cuenta";
                string mensaje_correo = "<h3>su cuenta fue creada correctamente</h3></br><p>su contraseña para acceder es:!Clave!</p>";
                mensaje_correo = mensaje_correo.Replace("!Clave!", Clave);
                user.Clave = CN_Recursos.ConvertirSha256(Clave);
                return cdUser.Registrar(user, out mensaje);
                //bool respuesta = CN_Recursos.EnviarCorreo(obj.Correo, asunto, mensaje_correo);

                //if (respuesta)
                //{

                //    obj.Clave = CN_Recursos.ConvertirSha256(Clave);
                //    return objCapaDato.Registrar(obj, out mensaje);
                //}
                //else
                //{
                //    mensaje = "no se puede enviar correo";
                //    return 0;

                //}
            }

            else
            {
                return 0;
            }
        }

        public bool Editar(Usuario obj, out string mensaje)
        {
            mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
            {
                mensaje = "El Nombre del usuario no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                mensaje = "El Apellido del usuario no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                mensaje = "El Correo del usuario no puede ser vacio";
            }

            if (!string.IsNullOrEmpty(obj.Nombres))
            {
                return cdUser.Editar(obj, out mensaje);
            }
            else
            {
                return false;
            }
        }
        public bool Eliminar(int id, out string mensaje)
        {
            return cdUser.Eliminar(id, out mensaje);
        }

        public string Create(Usuario user)
        {
           string mensaje = new UserValid().Make(user);
            if (string.IsNullOrEmpty(mensaje))
            {
                string Clave = CN_Recursos.GenerarClave();
                user.Clave = CN_Recursos.ConvertirSha256(Clave);
                int result = cdUser.Registrar(user, out mensaje);
                if (result > 0)
                    return mensaje;
            }           
            return mensaje;           
        }

        public string Update(Usuario user)
        {
            string mensaje = new UserValid().Make(user);
            if (string.IsNullOrEmpty(mensaje))
            {
                bool result = cdUser.Editar(user, out mensaje);
                if (!result)
                    return mensaje;
            }
            return mensaje;
        }
    }


}
