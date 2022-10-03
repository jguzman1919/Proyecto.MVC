using CapaEntidad;
using System;

namespace CapaNegocio.Validations.Users
{
    public class UserValid
    {
        public string Make(Usuario user)
        {
            String mensaje = String.Empty;

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

            return mensaje;
        }
    }
}
