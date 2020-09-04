using ServicioTecnico3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServicioTecnico_v2.Controllers
{
    public class LevantadosController : Controller
    {
        private herracentroV2Entities1 db = new herracentroV2Entities1();
        // GET: Levantados
        public ActionResult Index()
        {
            if (!ValidateSession()) { return RedirectToAction("Usuario", "Login"); }
            return View();            
        }

        // GET: Levantados/GetList/?anio=2015&trim=3
        public PartialViewResult _GetList(int? anio = 0, int? trim = 0)
        {
            if (!ValidateSession()) { return null; }

            List<mostrar_levantado_Result> list = new List<mostrar_levantado_Result>();
            if (anio == 0 && trim == 0)
            {
                return PartialView(list);
            }
            var data = db.mostrar_levantado(anio, trim, "");

            mostrar_levantado_Result result;

            foreach (var item in data)
            {
                result = new mostrar_levantado_Result();
                result = item;
                list.Add(result);
            }
            return PartialView(list);
        }

        // GET: Levantados/Create
        public ActionResult Create()
        {
            if (!ValidateSession()) { return RedirectToAction("Usuario", "Login"); }
            var obj = new mostrar_levantado_Result();
            obj.fecha = DateTime.Now;
            obj.idUsuario = Convert.ToInt16(Session["UserId"].ToString());
            obj.usuario = Session["UserName"].ToString();
           
            return View(obj);
        }

        public PartialViewResult _GetListDetail(string idLev)
        {
            if (!ValidateSession()) { return null; }

            List<mostrar_lavantadoDet_Result> list = new List<mostrar_lavantadoDet_Result>();
            if (string.IsNullOrEmpty(idLev))
            {
                return PartialView(list);
            }
            var data = db.mostrar_lavantadoDet(idLev);

            mostrar_lavantadoDet_Result result;

            foreach (var item in data)
            {
                result = new mostrar_lavantadoDet_Result();
                result = item;
                list.Add(result);
            }
            return PartialView(list);
        }
        // POST: Levantados/Create
        [HttpPost]
        public ActionResult Create(mostrar_levantado_Result levEnc)
        {
            try
            {
                //Guardar Nuevo
                if (string.IsNullOrEmpty(levEnc.id) && validaInt(levEnc.idTienda) && validaInt(levEnc.idUsuario) 
                    && !string.IsNullOrWhiteSpace(levEnc.referencia) && !string.IsNullOrWhiteSpace(levEnc.descripcion))
                {
                    db.insertar_levantado(levEnc.fecha, levEnc.referencia, levEnc.idTienda, levEnc.idUsuario, levEnc.descripcion);
                    var max = db.mostrar_levantado_max_id().FirstOrDefault();
                    levEnc.id = max.ToString();
                    ViewBag.TypeMensaje = true;
                    ViewBag.MensajeLev = "Se ha guardado los cambios correctamente: " + levEnc.id;
                    return View(levEnc);
                }else if (!string.IsNullOrEmpty(levEnc.id) && validaInt(levEnc.idTienda) && validaInt(levEnc.idUsuario)
                 && !string.IsNullOrWhiteSpace(levEnc.referencia) && !string.IsNullOrWhiteSpace(levEnc.descripcion))
                {
                    db.editar_levantado(levEnc.id, levEnc.fecha, levEnc.referencia, levEnc.idTienda, levEnc.idUsuario, levEnc.descripcion);

                    ViewBag.TypeMensaje = true;
                    ViewBag.MensajeLev = "Se ha guardado los cambios correctamente";
                    return View(levEnc);
                }
                else
                {
                    ViewBag.TypeMensaje = false;
                    ViewBag.MensajeLev = "Error: Uno o varios valores de los campos requeridos no estan completos, corríja e intente de nuevo.";
                    return View(levEnc);
                }

                //Editar Levantado
                
            
            }
            catch(Exception ex)
            {
                ViewBag.TypeMensaje = false;
                ViewBag.MensajeLev = "Ocurrio un error, comuniquese con el administrador del sistema, " + ex.InnerException.Message;
                return View(levEnc);
            }
        }

        public bool validaInt(int? entero)
        {
            if (entero != null || entero != 0)
            {
                return true;
            }
            return false;
        }

        // GET: Levantados/GetList
        public PartialViewResult _ModalItemLevantado(string id)
        {
            var levDet = new mostrar_lavantadoDet_Result();
            levDet.idLevantado = id;
            return PartialView(levDet);
        }
        // GET: Levantados/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Levantados/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Levantados/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Levantados/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
                          

        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();

                
                    //context.activofijoes.Add(new Models.activofijo()
                    //{
                    //    FotoAF = array,
                    //});
                    //context.SaveChanges();
                }

            }

            return RedirectToAction("actionname", "controller");
        }

        //public ActionResult Rindex(int id)
        //{
            //var context = new Models.DBEntities();
            //byte[] imageData = context.activofijoes.FirstOrDefault(i => i.id == id)?.FotoAF;
            //if (imageData != null)
            //{
            //    return File(imageData, "image/png"); // Might need to adjust the content type based on your actual image type
            //}
            //return null;
        //}


        //Trae todos las tiendas existententes
        public JsonResult GetMarket() {
            var data = db.mostrar_tiendas_clientes();
            mostrar_tiendas_clientes_Result result;
            var listMarket = new List<mostrar_tiendas_clientes_Result>();            
            foreach (var item in data)
            {                
                result = new mostrar_tiendas_clientes_Result();
                result = item;
                listMarket.Add(result);
            }
            return Json(listMarket, JsonRequestBehavior.AllowGet);
        }






        //Trae todos los usuarios existententes
        public JsonResult GetUsers()
        {
            var data = db.mostrar_usuarios();           
            var listUser = new List<mostrar_usuarios_Result>();
            foreach (var item in data)
            {
                var result = new mostrar_usuarios_Result();
                result = item;
                listUser.Add(result);
            }
            return Json(listUser, JsonRequestBehavior.AllowGet);
        }

        public bool ValidateSession()
        {
            if (Session["Login"] == null)
            {
                return false;
                //return View("/Views/Account/Login.cshtml");
            }
            else
            {
                return true;
            }
        }
    }
}
