using ServicioTecnico3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServicioTecnico_v2.Controllers
{
    public class BoletaVisitaController : Controller
    {
        private herracentroV2Entities1 db = new herracentroV2Entities1();
        // GET: BoletaVisita
        public ActionResult Index()
        {
            if (!ValidateSession()) { return RedirectToAction("Usuario", "Login"); }
            return View();
        }

        // GET: BoletaVisita/GetList/?fechaIni=2020/01/01&fechaFin=2020/08/31
        [HttpGet]
        public PartialViewResult _GetList(DateTime fechaIni, DateTime fechaFin, int usuario)
        {
            if (!ValidateSession()) { return null; }

            List<mostrar_Boleta_Visita_Tecnica_Enc_Result> list = new List<mostrar_Boleta_Visita_Tecnica_Enc_Result>();
          
            var data = db.mostrar_Boleta_Visita_Tecnica_Enc(fechaIni, fechaFin, "",usuario);
            mostrar_Boleta_Visita_Tecnica_Enc_Result boletas;
            foreach (var item in data)
            {
                boletas = new mostrar_Boleta_Visita_Tecnica_Enc_Result();
                boletas = item;
                list.Add(boletas);
            }
            return PartialView(list);
        }

        // GET: BoletaVisita/Create
        public ActionResult Create(string codBoleta)
        {
            if (!ValidateSession()) { return RedirectToAction("Usuario", "Login"); }
            var obj = new mostrar_Boleta_Visita_Tecnica_Enc_Result();                      
            if (string.IsNullOrEmpty(codBoleta))
            {
                obj.fechaEmision = DateTime.Now;
                obj.fechaVisita = DateTime.Now;
                obj.usuCrea = Convert.ToInt16(Session["UserId"].ToString());
                return View(obj);
            }
            obj = db.mostrar_Boleta_Visita_Tecnica_Enc(DateTime.Now, DateTime.Now, codBoleta, 0).FirstOrDefault();
            return View(obj);
        }

        // BoletaVisita/Create
        [HttpPost]
        public JsonResult CreateBoletaEnc(mostrar_Boleta_Visita_Tecnica_Enc_Result boletaEnc)
        {
            try
            {
                if (boletaEnc.codBoleta == null)
                {
                    var data = db.insertar_Boleta_Visita_Tecnica_Enc(
                    boletaEnc.fechaVisita,
                    boletaEnc.motivoVisita,
                    Convert.ToInt16(boletaEnc.usuarioVisitaNombre),
                    boletaEnc.nitCliente,
                    boletaEnc.nombreCliente,
                    boletaEnc.direccionCliente,
                    boletaEnc.email,
                    boletaEnc.descripcionVisita,
                    Convert.ToInt16(boletaEnc.estado),
                    boletaEnc.referencia1 == null ? "" : boletaEnc.referencia1,
                    Convert.ToInt16(Session["UserID"])
                    ).FirstOrDefault();
                    return Json(data.ToString(), JsonRequestBehavior.AllowGet);
                }
                return Json(boletaEnc.codBoleta, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
           
        }


        // BoletaVisita/_CreateDetail
        public PartialViewResult _CreateDetail(string codBoleta)
        {
            mostrar_Boleta_Visita_Tecnica_Det_Result det = new mostrar_Boleta_Visita_Tecnica_Det_Result();
            det.codBoleta = codBoleta;
            return PartialView(det);
        }
        // BoletaVisita/_CreateDetail
        [HttpPost]
        public JsonResult _CreateDetail(mostrar_Boleta_Visita_Tecnica_Det_Result detalle)
        {
            try
            {
                insertar_Boleta_Visita_Tecnica_Det_Result det = db.insertar_Boleta_Visita_Tecnica_Det(
                        detalle.codBoleta,
                        detalle.tipoTarea,
                        detalle.hallazgo,
                        detalle.accion,
                        detalle.solucionRecomendacion,
                        Convert.ToInt16(Session["UserID"])
                    ).FirstOrDefault();
                return Json(det.id, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        //_GetListDetail
        public PartialViewResult _GetListDetail(string codBoleta)
        {
            if (!ValidateSession()) { return null; }

            List<mostrar_Boleta_Visita_Tecnica_Det_Result> list = new List<mostrar_Boleta_Visita_Tecnica_Det_Result>();
            if (string.IsNullOrEmpty(codBoleta))
            {
                return PartialView(list);
            }
            var data = db.mostrar_Boleta_Visita_Tecnica_Det(codBoleta);

            mostrar_Boleta_Visita_Tecnica_Det_Result result;

            foreach (var item in data)
            {
                result = new mostrar_Boleta_Visita_Tecnica_Det_Result();
                result = item;
                list.Add(result);
            }
            return PartialView(list);
        }

        //funcion para mostrar la imagenes por tarea _GetImages
        public PartialViewResult _GetImages(int idTask)
        {
            if (!ValidateSession()) { return null; }

            List<Boleta_Visita_Tecnica_Det_Img> list = new List<Boleta_Visita_Tecnica_Det_Img>();
            if (idTask == 0)
            {
                return PartialView(list);
            }
            var data = from img in db.Boleta_Visita_Tecnica_Det_Img
                       where img.idDet == idTask
                       select img;

            Boleta_Visita_Tecnica_Det_Img result;

            foreach (var item in data)
            {
                result = new Boleta_Visita_Tecnica_Det_Img();
                result = item;
                list.Add(result);
            }
            return PartialView(list);
        }

        //funcion para guardar firma  
        public JsonResult setFirma(string boletaPago,string imageData)
        {
            try
            {
                string fileNameWitPath = Path.Combine(Server.MapPath("~/Images/Firma-Clt-" + boletaPago + ".jpg"));
                if (System.IO.File.Exists(fileNameWitPath))
                {
                    System.IO.File.Delete(fileNameWitPath);
                }
                var imagen = imageData.Split(',');
                //string fileNameWitPath = Path.Combine(Server.MapPath("~/Images/" + boletaPago + DateTime.Now.ToString().Replace("/", "-").Replace(" ", "- ").Replace(":", "") + ".jpg";
                using (FileStream fs = new FileStream(fileNameWitPath, FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        byte[] data = Convert.FromBase64String(imagen[1]);//convert from base64
                        bw.Write(data);
                        bw.Close();
                    }
                }
                return Json("True", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("False", JsonRequestBehavior.AllowGet);
            }          
        }
        
        //Metodo para captura de imagenes
        [HttpPost]
        public ActionResult UploadFiles(int idTarea)
        {
            string path = Server.MapPath("~/Images/");
            HttpFileCollectionBase files = Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];
                file.SaveAs(path + file.FileName);

                int max = db.Boleta_Visita_Tecnica_Det_Img.ToList().Max(r => r.id);
                Boleta_Visita_Tecnica_Det_Img objImg = new Boleta_Visita_Tecnica_Det_Img();
                objImg.id = max + 1;

                int count = db.Boleta_Visita_Tecnica_Det_Img.ToList().Where(x => x.idDet == idTarea).Count();
                objImg.correlativo = count + 1;

                objImg.idDet = idTarea;
                objImg.servidor = path;
                var name = idTarea.ToString() + "-" + objImg.id.ToString() + "-" + objImg.correlativo.ToString();
                objImg.nombreArchivo = name;
                objImg.extensionArchivo = Path.GetExtension(file.FileName);
                objImg.firma = 0;
                objImg.comentario = "";
                objImg.fecCrea = DateTime.Now;
                objImg.usuCrea = Convert.ToInt16(Session["UserID"].ToString());


                db.Boleta_Visita_Tecnica_Det_Img.Add(objImg);
                db.SaveChanges();

                string oldFilePath = Server.MapPath("~/Images/") + file.FileName; // Full path of old file
                string newFilePath = Server.MapPath("~/Images/") + name + Path.GetExtension(file.FileName); // Full path of new file

                if (System.IO.File.Exists(newFilePath))
                {
                    System.IO.File.Delete(newFilePath);
                }
                System.IO.File.Move(oldFilePath, newFilePath);

            }
            return Json(files.Count + " Files Uploaded!");
        }

        //Metodo para descargar la imagen actual
        public ActionResult DescargaImagen(int idImg)
        {
            try
            {
                var image = db.Boleta_Visita_Tecnica_Det_Img.Where(s => s.id == idImg)
                                             .Select(s => s).FirstOrDefault();
                Boleta_Visita_Tecnica_Det_Img obj = new Boleta_Visita_Tecnica_Det_Img();
                obj = image;

                string imgPath = Server.MapPath("~/Images/") + obj.nombreArchivo + obj.extensionArchivo;
                return File(imgPath, "image/jpeg", "Img_" + obj.id.ToString() + obj.extensionArchivo);
            }
            catch (Exception ex)
            {
                ViewBag.DescargaImagen = ex.Message;
                return View();
            }
           
        }

        //Metodo para eliminar la imagen seleccionada
        public JsonResult eliminaImagen(int idImg)
        {
            try
            {
                var image = db.Boleta_Visita_Tecnica_Det_Img.Where(s => s.id == idImg)
                            .Select(s => s).FirstOrDefault();
                Boleta_Visita_Tecnica_Det_Img obj = new Boleta_Visita_Tecnica_Det_Img();
                obj = image;

                string imgPath = Server.MapPath("~/Images/") + obj.nombreArchivo + obj.extensionArchivo;
                if (System.IO.File.Exists(imgPath))
                {
                    System.IO.File.Delete(imgPath);
                }

                db.Boleta_Visita_Tecnica_Det_Img.Remove(obj);
                db.SaveChanges();

                return Json("True", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("False", JsonRequestBehavior.AllowGet);
            }           
        }

        //Metodo para eliminar la ima
        public JsonResult eliminaTarea(int idTarea) {
            try
            {
                db.eliminar_Boleta_Visita_Tecnica_Det(idTarea);
                return Json("True", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("False", JsonRequestBehavior.AllowGet);
            }         
        }

       

       



        //funcion para obtener motivos de visita
        public JsonResult getMotivosVisita()
        {
            return Json(db.Motivo_Visita_Tecnica.OrderBy(x => x.nombre).ToList(), JsonRequestBehavior.AllowGet);
        }

        //funcion para obtener estado de boleta
        public JsonResult getEstadosBoletaVisita()
        {
            return Json(db.Estado_Boleta_Visita_Tecnica.ToList(), JsonRequestBehavior.AllowGet);
        }

        //funcion para obtener estado de boleta
        public JsonResult getUsuarios()
        {
            usuarios usr;
            var data = db.usuarios.OrderBy(x => x.nombre).ToList();
            List<usuarios> usrList = new List<usuarios>();
            foreach (var item in data)
            {
                usr = new usuarios();
                usr = item;
                usrList.Add(usr);
            }
            UsuarioSeguro usrSec = new UsuarioSeguro();
            List<UsuarioSeguro> usrSecList = new List<UsuarioSeguro>();
            usrSec.id = 0;
            usrSec.nombreCompleto = "Todos los Usuarios";
            usrSecList.Add(usrSec);
            foreach (var item2 in usrList)
            {
                usrSec = new UsuarioSeguro();
                usrSec.id = item2.id_usuario;
                usrSec.nombreCompleto = item2.nombre + " " + item2.apellido;
                usrSecList.Add(usrSec);
            }
            return Json(usrSecList, JsonRequestBehavior.AllowGet);
        }

        //funcion para obtener tipos de incidencias
        public JsonResult getTiposIncidencias()
        {
            return Json(db.tipos_incidencias.OrderBy(x => x.nombre_tipo_incidencia).ToList(), JsonRequestBehavior.AllowGet);
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