import RequestService from '../../Common/RequestService.js'
import HandleResponse from '../../Common/HandleResponse.js'

const User = {
    Save: () => {
        var Usuario = {
            IdUsuario: $("#txtid").val(),
            Nombres: $("#txtnombres").val(),
            Apellidos: $("#txtapellidos").val(),
            Correo: $("#txtcorreo").val(),
            Activo: $("#cboactivo").val() == 1 ? true : false,
        }
        var response = RequestService.Make(Usuario, '/Home/UserSave', HandleResponse.Form)
        console.log('response crear', response);
    },
    Update() {
        var Usuario = {
            IdUsuario: $("#txtid").val(),
            Nombres: $("#txtnombres").val(),
            Apellidos: $("#txtapellidos").val(),
            Correo: $("#txtcorreo").val(),
            Activo: $("#cboactivo").val() == 1 ? true : false,
        }
        var response = RequestService.Make(Usuario, '/Home/UserUpdate', HandleResponse.Form)
        console.log('response crear', response);
    }
}
$(function () {
    $('body').on('click', '#btnSave', function () {
        User.Save();
    })

    $('body').on('click', '#btnEditar', function () {
        User.Update();
    })
    
})


