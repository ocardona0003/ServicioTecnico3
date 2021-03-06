﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServicioTecnico3.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class herracentroV2Entities1 : DbContext
    {
        public herracentroV2Entities1()
            : base("name=herracentroV2Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Boleta_Visita_Tecnica_Det_Img> Boleta_Visita_Tecnica_Det_Img { get; set; }
        public virtual DbSet<Estado_Boleta_Visita_Tecnica> Estado_Boleta_Visita_Tecnica { get; set; }
        public virtual DbSet<Motivo_Visita_Tecnica> Motivo_Visita_Tecnica { get; set; }
        public virtual DbSet<tipos_incidencias> tipos_incidencias { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }
    
        public virtual int editar_levantado(string id, Nullable<System.DateTime> fecha, string referencia, Nullable<int> idTienda, Nullable<int> idUsuario, string descripcion)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("fecha", fecha) :
                new ObjectParameter("fecha", typeof(System.DateTime));
    
            var referenciaParameter = referencia != null ?
                new ObjectParameter("referencia", referencia) :
                new ObjectParameter("referencia", typeof(string));
    
            var idTiendaParameter = idTienda.HasValue ?
                new ObjectParameter("idTienda", idTienda) :
                new ObjectParameter("idTienda", typeof(int));
    
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(int));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("descripcion", descripcion) :
                new ObjectParameter("descripcion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("editar_levantado", idParameter, fechaParameter, referenciaParameter, idTiendaParameter, idUsuarioParameter, descripcionParameter);
        }
    
        public virtual int insertar_levantado(Nullable<System.DateTime> fecha, string referencia, Nullable<int> idTienda, Nullable<int> idUsuario, string descripcion)
        {
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("fecha", fecha) :
                new ObjectParameter("fecha", typeof(System.DateTime));
    
            var referenciaParameter = referencia != null ?
                new ObjectParameter("referencia", referencia) :
                new ObjectParameter("referencia", typeof(string));
    
            var idTiendaParameter = idTienda.HasValue ?
                new ObjectParameter("idTienda", idTienda) :
                new ObjectParameter("idTienda", typeof(int));
    
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(int));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("descripcion", descripcion) :
                new ObjectParameter("descripcion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertar_levantado", fechaParameter, referenciaParameter, idTiendaParameter, idUsuarioParameter, descripcionParameter);
        }
    
        public virtual ObjectResult<mostrar_lavantadoDet_Result> mostrar_lavantadoDet(string idLevantado)
        {
            var idLevantadoParameter = idLevantado != null ?
                new ObjectParameter("idLevantado", idLevantado) :
                new ObjectParameter("idLevantado", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mostrar_lavantadoDet_Result>("mostrar_lavantadoDet", idLevantadoParameter);
        }
    
        public virtual ObjectResult<mostrar_levantado_Result> mostrar_levantado(Nullable<int> anio, Nullable<int> trimestre, string parametro)
        {
            var anioParameter = anio.HasValue ?
                new ObjectParameter("anio", anio) :
                new ObjectParameter("anio", typeof(int));
    
            var trimestreParameter = trimestre.HasValue ?
                new ObjectParameter("trimestre", trimestre) :
                new ObjectParameter("trimestre", typeof(int));
    
            var parametroParameter = parametro != null ?
                new ObjectParameter("parametro", parametro) :
                new ObjectParameter("parametro", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mostrar_levantado_Result>("mostrar_levantado", anioParameter, trimestreParameter, parametroParameter);
        }
    
        public virtual ObjectResult<string> mostrar_levantado_max_id()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("mostrar_levantado_max_id");
        }
    
        public virtual ObjectResult<mostrar_tiendas_clientes_Result> mostrar_tiendas_clientes()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mostrar_tiendas_clientes_Result>("mostrar_tiendas_clientes");
        }
    
        public virtual ObjectResult<mostrar_usuarios_Result> mostrar_usuarios()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mostrar_usuarios_Result>("mostrar_usuarios");
        }
    
        public virtual ObjectResult<insertar_Boleta_Visita_Tecnica_Det_Result> insertar_Boleta_Visita_Tecnica_Det(string codBoleta, Nullable<int> tipoTarea, string hallazgo, string accion, string solucionRecomendacion, Nullable<int> usuCrea)
        {
            var codBoletaParameter = codBoleta != null ?
                new ObjectParameter("codBoleta", codBoleta) :
                new ObjectParameter("codBoleta", typeof(string));
    
            var tipoTareaParameter = tipoTarea.HasValue ?
                new ObjectParameter("tipoTarea", tipoTarea) :
                new ObjectParameter("tipoTarea", typeof(int));
    
            var hallazgoParameter = hallazgo != null ?
                new ObjectParameter("hallazgo", hallazgo) :
                new ObjectParameter("hallazgo", typeof(string));
    
            var accionParameter = accion != null ?
                new ObjectParameter("accion", accion) :
                new ObjectParameter("accion", typeof(string));
    
            var solucionRecomendacionParameter = solucionRecomendacion != null ?
                new ObjectParameter("solucionRecomendacion", solucionRecomendacion) :
                new ObjectParameter("solucionRecomendacion", typeof(string));
    
            var usuCreaParameter = usuCrea.HasValue ?
                new ObjectParameter("usuCrea", usuCrea) :
                new ObjectParameter("usuCrea", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<insertar_Boleta_Visita_Tecnica_Det_Result>("insertar_Boleta_Visita_Tecnica_Det", codBoletaParameter, tipoTareaParameter, hallazgoParameter, accionParameter, solucionRecomendacionParameter, usuCreaParameter);
        }
    
        public virtual ObjectResult<string> insertar_Boleta_Visita_Tecnica_Enc(Nullable<System.DateTime> fechaVisita, Nullable<int> motivoVisita, Nullable<int> usuarioVisita, string nitCliente, string nombreCliente, string direccionCliente, string email, string descripcionVisita, Nullable<int> estado, string referencia1, Nullable<int> idUsuarioActual)
        {
            var fechaVisitaParameter = fechaVisita.HasValue ?
                new ObjectParameter("fechaVisita", fechaVisita) :
                new ObjectParameter("fechaVisita", typeof(System.DateTime));
    
            var motivoVisitaParameter = motivoVisita.HasValue ?
                new ObjectParameter("motivoVisita", motivoVisita) :
                new ObjectParameter("motivoVisita", typeof(int));
    
            var usuarioVisitaParameter = usuarioVisita.HasValue ?
                new ObjectParameter("usuarioVisita", usuarioVisita) :
                new ObjectParameter("usuarioVisita", typeof(int));
    
            var nitClienteParameter = nitCliente != null ?
                new ObjectParameter("nitCliente", nitCliente) :
                new ObjectParameter("nitCliente", typeof(string));
    
            var nombreClienteParameter = nombreCliente != null ?
                new ObjectParameter("nombreCliente", nombreCliente) :
                new ObjectParameter("nombreCliente", typeof(string));
    
            var direccionClienteParameter = direccionCliente != null ?
                new ObjectParameter("direccionCliente", direccionCliente) :
                new ObjectParameter("direccionCliente", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var descripcionVisitaParameter = descripcionVisita != null ?
                new ObjectParameter("descripcionVisita", descripcionVisita) :
                new ObjectParameter("descripcionVisita", typeof(string));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("estado", estado) :
                new ObjectParameter("estado", typeof(int));
    
            var referencia1Parameter = referencia1 != null ?
                new ObjectParameter("referencia1", referencia1) :
                new ObjectParameter("referencia1", typeof(string));
    
            var idUsuarioActualParameter = idUsuarioActual.HasValue ?
                new ObjectParameter("idUsuarioActual", idUsuarioActual) :
                new ObjectParameter("idUsuarioActual", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("insertar_Boleta_Visita_Tecnica_Enc", fechaVisitaParameter, motivoVisitaParameter, usuarioVisitaParameter, nitClienteParameter, nombreClienteParameter, direccionClienteParameter, emailParameter, descripcionVisitaParameter, estadoParameter, referencia1Parameter, idUsuarioActualParameter);
        }
    
        public virtual ObjectResult<mostrar_Boleta_Visita_Tecnica_Det_Result> mostrar_Boleta_Visita_Tecnica_Det(string codBoleta)
        {
            var codBoletaParameter = codBoleta != null ?
                new ObjectParameter("codBoleta", codBoleta) :
                new ObjectParameter("codBoleta", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mostrar_Boleta_Visita_Tecnica_Det_Result>("mostrar_Boleta_Visita_Tecnica_Det", codBoletaParameter);
        }
    
        public virtual ObjectResult<mostrar_Boleta_Visita_Tecnica_Enc_Result> mostrar_Boleta_Visita_Tecnica_Enc(Nullable<System.DateTime> fechaIni, Nullable<System.DateTime> fechaFin, string codBoleta, Nullable<int> idUsuarioVisita)
        {
            var fechaIniParameter = fechaIni.HasValue ?
                new ObjectParameter("fechaIni", fechaIni) :
                new ObjectParameter("fechaIni", typeof(System.DateTime));
    
            var fechaFinParameter = fechaFin.HasValue ?
                new ObjectParameter("fechaFin", fechaFin) :
                new ObjectParameter("fechaFin", typeof(System.DateTime));
    
            var codBoletaParameter = codBoleta != null ?
                new ObjectParameter("codBoleta", codBoleta) :
                new ObjectParameter("codBoleta", typeof(string));
    
            var idUsuarioVisitaParameter = idUsuarioVisita.HasValue ?
                new ObjectParameter("idUsuarioVisita", idUsuarioVisita) :
                new ObjectParameter("idUsuarioVisita", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mostrar_Boleta_Visita_Tecnica_Enc_Result>("mostrar_Boleta_Visita_Tecnica_Enc", fechaIniParameter, fechaFinParameter, codBoletaParameter, idUsuarioVisitaParameter);
        }
    
        public virtual int eliminar_Boleta_Visita_Tecnica_Det(Nullable<int> idTarea)
        {
            var idTareaParameter = idTarea.HasValue ?
                new ObjectParameter("idTarea", idTarea) :
                new ObjectParameter("idTarea", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("eliminar_Boleta_Visita_Tecnica_Det", idTareaParameter);
        }
    }
}
