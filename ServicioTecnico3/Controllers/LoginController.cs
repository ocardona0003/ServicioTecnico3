using ServicioTecnico3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServicioTecnico_v2.Controllers
{
    public class LoginController : Controller
    {

        private herracentroV2Entities1 db = new herracentroV2Entities1();

        // GET: usuarios
        public ActionResult Usuario()
        {
            Session.Abandon();
            var usr = new usuarios();
            return View(usr);
        }


        [HttpPost]
        public ActionResult Usuario(usuarios usr)
        {
            try
            {           
            usuarios usuario = new usuarios();
            usuario = (from p in db.usuarios where p.login == usr.login && p.password == usr.password select p).FirstOrDefault();

            if (usuario == null)
            {
                ViewBag.Mensaje = "Usuario o contraseña incorrectos, intente de nuevo o comuníquese con el administrador del sistema.";
                return View(usr);
            }
            else
            {
                Session["UserID"] = usuario.id_usuario.ToString();
                Session["UserName"] = usuario.nombre + " " + usuario.apellido;
                Session["UserEmail"] = usuario.email;
                Session["Login"] = usuario.login;
                Session["Rol"] = usuario.id_privilegio;
                    Session.Timeout = 60;
                return RedirectToAction("Index", "Home");                    
            }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ocurrio un error de conexión, comuníquese con el administrador del sistema e informe del siguiente mensaje: "  + ex.InnerException.Message;
                return View();

            }
        }

      

    }
}